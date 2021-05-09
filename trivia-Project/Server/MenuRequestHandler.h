#pragma once
#include <iostream>
#include <string>
#include "Buffer.h"
#include "IRequestHandler.h"
#include "messagesCodes.h"
#include "LoggedUser.h"
#include "RequestHandlerFactory.h"

class RequestHandlerFactory;

class MenuRequestHandler : public IRequestHandler
{
private:
	LoggedUser m_user;
	RequestHandlerFactory* m_handlerFactory;
public:
	MenuRequestHandler(RequestHandlerFactory* fac, LoggedUser m_user_);
	virtual bool isRequestRelevant(RequestInfo RequestInfo) override;
	virtual RequestResult handleRequest(RequestInfo RequestInfo) override;
	RequestResult signout(RequestInfo inf);
	RequestResult getRooms(RequestInfo inf);
	RequestResult getPlayersInRoom(RequestInfo inf);
	RequestResult getStatistics(RequestInfo inf);
	RequestResult joinRoom(RequestInfo inf);
	RequestResult createRoom(RequestInfo inf);
};

