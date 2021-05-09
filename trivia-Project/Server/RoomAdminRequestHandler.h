#pragma once
#include "IRequestHandler.h"
#include "Room.h"
#include "LoggedUser.h"
#include "RequestHandlerFactory.h"
#include "RequestInfo.h"
#include "RequestResult.h"
#include "RoomManager.h"
#include <iostream>
#include <algorithm>
class RequestHandlerFactory;
class RoomManager;

class RoomAdminRequestHandler :
	public IRequestHandler
{
private:
	Room m_room;
	LoggedUser m_user;
	RequestHandlerFactory* m_handlerFactory;

	RequestResult closeRoom(RequestInfo inf);
	RequestResult startGame(RequestInfo inf);
	RequestResult getRoomState(RequestInfo inf);
public:
	RoomAdminRequestHandler(RequestHandlerFactory* fac, LoggedUser user, Room room);
	virtual bool isRequestRelevant(RequestInfo inf) override;
	virtual RequestResult handleRequest(RequestInfo inf) override;
};

