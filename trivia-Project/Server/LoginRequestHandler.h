#pragma once

#include "IRequestHandler.h"
#include "RequestHandlerFactory.h"
#include "JsonResponsePacketSerializer.h"
#include "ResponseStructs.h"
#include "Buffer.h"
#include "MenuRequestHandler.h"
#include "JsonRequestPacketDeserializer.h"
#include "LoginRequest.h"
#include "SignupRequest.h"

#define OK 1;
#define ERR 0;

class RequestHandlerFactory;

class LoginRequestHandler : public IRequestHandler
{
public:
	LoginRequestHandler(RequestHandlerFactory* factory, IDatabase* db);
	virtual bool isRequestRelevant(RequestInfo RequestInfo) override;
	virtual RequestResult handleRequest(RequestInfo RequestInfo) override;
private:
	RequestHandlerFactory* m_handlerFactory;
	IDatabase* m_db;
	RequestResult login(RequestInfo RequestInfo);
	RequestResult signup(RequestInfo RequestInfo);
};

