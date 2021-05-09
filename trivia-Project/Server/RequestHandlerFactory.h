#pragma once
#include<iostream>
#include <mutex>
#include "LoginManager.h"
#include "LoginRequestHandler.h"
#include "IDatabase.h"
#include "Buffer.h"
#include "MenuRequestHandler.h"
#include "RoomManager.h"
#include "StatisticsManager.h"
#include "RoomAdminRequestHandler.h"
#include "RoomMemberRequestHandler.h"
#include "GameRequestHandler.h"
#include "GameManager.h"



class IDatabase;
class LoginRequestHandler;
class StatisticsManager;
class MenuRequestHandler;
class RoomAdminRequestHandler;
class RoomMemberRequestHandler;
class RoomManager;
class GameManager;
class GameRequestHandler;

class RequestHandlerFactory
{
private:
	std::mutex GamesMutex;
	GameManager m_gameManager;
	RoomManager m_roomManager;
	StatisticsManager m_statisticsManager;
	LoginManager m_loginManager;
	IDatabase* m_database;
	std::map<int,Game*> Games;

public:
	RequestHandlerFactory(IDatabase* m_database);
	LoginRequestHandler* createLoginRequestHandler();
	LoginManager& getLoginManager();
	//2.0.0
	MenuRequestHandler* createMenuRequestHandler(LoggedUser m_user);
	StatisticsManager& getStatisticsManager();
	RoomManager& getRoomManager();
	//3.0.0
	RoomAdminRequestHandler* createRoomAdminRequestHandler(LoggedUser user, Room room);
	RoomMemberRequestHandler* createRoomMemberRequestHandler(LoggedUser user, Room room);
	//4.0.0
	GameRequestHandler* createGameRequestHandler(LoggedUser user, Room room);
	GameManager& getGameManager();

	IDatabase* getDb();
};

