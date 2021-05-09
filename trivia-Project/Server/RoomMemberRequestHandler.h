#pragma once
#include <algorithm>
#include <iostream>
#include "IRequestHandler.h"
#include "Room.h"
#include "LoggedUser.h"
#include "RequestHandlerFactory.h"
#include "RequestInfo.h"
#include "RequestResult.h"
#include "tools.h"

class RoomManager;

class RoomMemberRequestHandler : public IRequestHandler
{
private:
	Room m_room;
	LoggedUser m_user;
	RequestHandlerFactory* m_handlerFactory;

	RequestResult leaveRoom(RequestInfo inf);
	RequestResult getRoomState(RequestInfo inf);
public:
	RoomMemberRequestHandler(RequestHandlerFactory* fac, LoggedUser user, Room room);
	virtual bool isRequestRelevant(RequestInfo inf) override;
	virtual RequestResult handleRequest(RequestInfo inf) override;
};

