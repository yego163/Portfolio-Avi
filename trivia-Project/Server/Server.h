#pragma once
#include "IDatabase.h"
#include "SqliteDatabase.h"
#include "RequestHandlerFactory.h"
#include "Communicator.h"
#include <iostream>
#include <exception>
#include <thread>
#include <string>

#define PORT 1333

class Server
{
private:
	IDatabase* m_database;
	RequestHandlerFactory* m_handlerFactory;
	Communicator m_communicator;
public:
	static Server getInstance();
	Server();
	~Server();
	void run();
};
