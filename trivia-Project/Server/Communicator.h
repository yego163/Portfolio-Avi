#pragma once
#include "LoginRequestHandler.h"
#include <WinSock2.h>
#include <Windows.h>
#include <vector>
#include <thread>
#include "Helper.h"
#include <algorithm>
#include <mutex>
#include <fstream>
#include <map>
#include <iostream>
#include <ctime>
#include <chrono>

#include "RequestHandlerFactory.h"
#include "JsonRequestPacketDeserializer.h"
#include "JsonResponsePacketSerializer.h"
#include "RequestInfo.h"
#include "WSAInitializer.h"
#include "MenuRequestHandler.h"

class Communicator
{
public:
	Communicator(int port, RequestHandlerFactory* factory, IDatabase* db);
	~Communicator();
	void bindAndListen();
	void startHandleRequests();
	void handleNewClient();

private:
	void doStart(SOCKET clientSocket);
	void takeCare(SOCKET clientSocket);
	RequestInfo GetInfo(std::string buf);
	void clientHandler(SOCKET clientSocket);

	int _port;
	SOCKET _serverSocket;
	std::vector<std::thread> conversations;
	std::map<SOCKET, IRequestHandler*> loginUsers;
	RequestHandlerFactory* m_factory;
	IDatabase* m_database;
};

