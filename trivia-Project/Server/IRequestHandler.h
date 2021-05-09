#pragma once
#include "RequestInfo.h"
#include "RequestResult.h"
class IRequestHandler
{
public:	
	virtual bool isRequestRelevant(RequestInfo RequestInfo) = 0;
	virtual RequestResult handleRequest(RequestInfo RequestInfo) = 0;
};

