#pragma once

#include "RequestInfo.h"
#include "IRequestHandler.h"
#include "Buffer.h"
class IRequestHandler;

struct RequestResult
{
public:
	IRequestHandler* newHandler;
	Buffer response;
};
