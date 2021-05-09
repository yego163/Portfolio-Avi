#include "Server.h"

Server Server::getInstance()
{
	return Server();
}

Server::Server() : m_database(new SqliteDatabase()) 
					,m_handlerFactory(new RequestHandlerFactory(m_database))
					,m_communicator(Communicator(PORT, m_handlerFactory, m_database))
{
}

Server::~Server()
{
	delete m_handlerFactory;
	delete m_database;
}

void Server::run()
{
	WSAInitializer wsaInit;
	m_communicator.bindAndListen();
	std::thread serverServe(&Communicator::startHandleRequests, &m_communicator);//serve the clients
	serverServe.detach();//dont wait...
	std::string command = "";
	do {//enter command in parallel
		std::cout << "Enter Command:" << std::endl;
		std::cin >> command;
	} while (command != "EXIT");
}
