#include "Communicator.h"


Communicator::Communicator(int port, RequestHandlerFactory* factory, IDatabase* db) : conversations(std::vector<std::thread>()),
loginUsers(std::map<SOCKET, IRequestHandler*>()),
_port(port)
{
	m_database = db;
	m_factory = factory;
}

Communicator::~Communicator()
{
	try
	{
		for (std::map<SOCKET, IRequestHandler*>::iterator it = loginUsers.begin(); it != loginUsers.end(); it++) {
			delete (it->second);
			closesocket(it->first);//close the sockets
		}
		for (size_t i = 0; i < conversations.size(); i++)
			conversations[i].detach();//close threads
		// the only use of the destructor should be for freeing 
		// resources that was allocated in the constructor
		closesocket(_serverSocket);
	}
	catch (...) {}
}

void Communicator::bindAndListen()
{
	// this server use TCP. that why SOCK_STREAM & IPPROTO_TCP
	// if the server use UDP we will use: SOCK_DGRAM & IPPROTO_UDP
	_serverSocket = socket(AF_INET, SOCK_STREAM, IPPROTO_TCP);
	if (_serverSocket == INVALID_SOCKET)
		throw std::exception(__FUNCTION__ " - socket");
	struct sockaddr_in sa = { 0 };

	sa.sin_port = htons(_port); // port that server will listen for
	sa.sin_family = AF_INET;   // must be AF_INET
	sa.sin_addr.s_addr = INADDR_ANY;    // when there are few ip's for the machine. We will use always "INADDR_ANY"

	// again stepping out to the global namespace
	// Connects between the socket and the configuration (port and etc..)
	if (bind(_serverSocket, (struct sockaddr*) & sa, sizeof(sa)) == SOCKET_ERROR)
		throw std::exception(__FUNCTION__ " - bind");

	// Start listening for incoming requests of clients
	if (listen(_serverSocket, SOMAXCONN) == SOCKET_ERROR) {
		std::cout << WSAGetLastError();
		throw std::exception(__FUNCTION__ " - listen");
	}
	std::cout << "Listening on port " << _port << std::endl;
}

void Communicator::startHandleRequests()
{

	while (true)
	{
		// the main thread is only accepting clients 
		// and add then to the list of handlers
		std::cout << "Waiting for client connection request" << std::endl;
		handleNewClient();
	}
}

void Communicator::handleNewClient()
{
	// notice that we step out to the global namespace
	// for the resolution of the function accept

	// this accepts the client and create a specific socket from server to this client
	SOCKET client_socket = ::accept(_serverSocket, NULL, NULL);
	if (client_socket == INVALID_SOCKET)
		throw std::exception(__FUNCTION__);

	std::cout << "Client accepted. Server and client can speak" << std::endl;



	// the function that handle the conversation with the client
	conversations.push_back(std::move(std::thread(&Communicator::clientHandler, this, client_socket)));//open a conversation with the client
	conversations.back().detach();
}

void Communicator::doStart(SOCKET clientSocket)
{
	LoginRequestHandler* login = new LoginRequestHandler(m_factory, m_database);
	loginUsers.insert(std::pair<SOCKET, LoginRequestHandler*>(clientSocket, login));
	Helper::sendData(clientSocket, "Hello");//send hello to client
	std::string clientCommand = Helper::getStringPartFromSocket(clientSocket, 5);//get the hello command

	if (clientCommand != "hello")
		throw std::invalid_argument("The client doesn't polite");
}

void Communicator::takeCare(SOCKET clientSocket)
{
	std::string clientCommand = Helper::getStringPartFromSocket(clientSocket, 5);
	clientCommand = clientCommand + Helper::getStringPartFromSocket(clientSocket, stoi(clientCommand.substr(1)));
	std::cout << "CLIENT >>> " << clientCommand << std::endl;
	RequestResult ret = loginUsers[clientSocket]->handleRequest(GetInfo(clientCommand));
	std::cout << "SERVER >>> " << BufferToString(ret.response) << std::endl;
	Helper::sendData(clientSocket, BufferToString(ret.response));
	if (loginUsers[clientSocket] != ret.newHandler) {//only if the player did progress the app in anyway..
		delete loginUsers[clientSocket];
		loginUsers[clientSocket] = ret.newHandler;//set the new handler
	}
}

RequestInfo Communicator::GetInfo(std::string buf)
{
	RequestInfo inf;
	inf.id = (int)buf[0] - 48;
	inf.receivalTime = std::chrono::system_clock::to_time_t(std::chrono::system_clock::now());
	inf.buffer = stringToBuffer(buf.substr(5));
	return inf;
}

void Communicator::clientHandler(SOCKET clientSocket)
{
	try
	{
		doStart(clientSocket);//do the hello thing
		do {
			takeCare(clientSocket);
		} while (loginUsers[clientSocket] != nullptr);//null == 
	}
	catch (...)	{	}
	try {//try to leaveGame
		if (loginUsers[clientSocket] != nullptr)
			delete loginUsers[clientSocket];
	}
	catch (...) {}
	if (loginUsers[clientSocket] != nullptr) {//prevent an crash
		try {//try to leaveGame
			loginUsers[clientSocket]->handleRequest(GetInfo(std::string() + LEAVE_GAME_CODE + "0000"));//logout
		}
		catch (...) {}
		try {//try to leave room
			loginUsers[clientSocket]->handleRequest(GetInfo(std::string() + LEAVE_ROOM_CODE + "0000"));//logout
		}
		catch (...) {}
		try {//try to logout
			loginUsers[clientSocket]->handleRequest(GetInfo(std::string() + LOGOUT_CODE + "0000"));//logout
		}
		catch (...) {}
	}
	try{
		loginUsers.erase(loginUsers.find(clientSocket));//remove the client from the online users
		closesocket(clientSocket);
	}
	catch (...) {}
	std::cout << "Finish conversation" << std::endl;
}

