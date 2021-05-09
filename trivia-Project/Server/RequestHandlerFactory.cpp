#include "RequestHandlerFactory.h"

RequestHandlerFactory::RequestHandlerFactory(IDatabase* database) : m_loginManager(database), m_statisticsManager(database), m_roomManager(), m_gameManager(database)
{
	m_database = database;
}

LoginRequestHandler* RequestHandlerFactory::createLoginRequestHandler()
{
	return new LoginRequestHandler(this, m_database);
}

LoginManager& RequestHandlerFactory::getLoginManager()
{
	return m_loginManager;
}

MenuRequestHandler* RequestHandlerFactory::createMenuRequestHandler(LoggedUser m_user)
{
	return new MenuRequestHandler(this, m_user);;
}

StatisticsManager& RequestHandlerFactory::getStatisticsManager()
{
	return m_statisticsManager;
}

RoomManager& RequestHandlerFactory::getRoomManager()
{
	return m_roomManager;
}

RoomAdminRequestHandler* RequestHandlerFactory::createRoomAdminRequestHandler(LoggedUser user, Room room)
{
	return new RoomAdminRequestHandler(this, user, room);
}

RoomMemberRequestHandler* RequestHandlerFactory::createRoomMemberRequestHandler(LoggedUser user, Room room)
{
	return new RoomMemberRequestHandler(this, user, room);
}

GameRequestHandler* RequestHandlerFactory::createGameRequestHandler(LoggedUser user, Room room)
{
	GamesMutex.lock();
	Game* usersGame = nullptr;
	if (Games.find(room.getRoomData().getId()) != Games.end()){
		usersGame = Games[room.getRoomData().getId()];//game already exist
	}
	else {
		usersGame = m_gameManager.createGame(room);//create new game
		Games.insert(std::pair<int, Game*>(room.getRoomData().getId(), usersGame));
	}
	GamesMutex.unlock();
	return new GameRequestHandler(this, user, usersGame, room);
}

GameManager& RequestHandlerFactory::getGameManager()
{
	return m_gameManager;
}

IDatabase* RequestHandlerFactory::getDb()
{
	return m_database;
}

