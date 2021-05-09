#pragma once
#include "IRequestHandler.h"
#include "LoggedUser.h"
#include "RequestHandlerFactory.h"
#include "RequestInfo.h"
#include "RequestResult.h"
#include "GameManager.h"
#include "Game.h"
#include <iostream>
#include <algorithm>
class RequestHandlerFactory;
class RoomManager;


class GameRequestHandler :
	public IRequestHandler
{
private:
	Game* m_game;
	LoggedUser m_user;
	RequestHandlerFactory* m_handlerFactory;
	Room m_room;

	RequestResult getGameResults(RequestInfo inf);
	RequestResult getQuestion(RequestInfo inf);
	RequestResult submitAnswer(RequestInfo inf);
	RequestResult leaveGame(RequestInfo inf);
	RequestResult deleteGameAndRoom();

public:
	GameRequestHandler(RequestHandlerFactory* fac, LoggedUser user, Game* game, Room room);
	~GameRequestHandler();
	virtual bool isRequestRelevant(RequestInfo inf) override;
	virtual RequestResult handleRequest(RequestInfo inf) override;
	Room getGameRoom();
};
