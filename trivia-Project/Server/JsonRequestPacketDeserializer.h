#pragma once
#include <iostream>
#include "Buffer.h"
#include "LoginRequest.h"
#include "SignupRequest.h"
#include "GetPlayersInRoomRequest.h"
#include "JoinRoomRequest.h"
#include "CreateRoomRequest.h"
#include "SubmitAnswerRequest.h"
#include "json.hpp"
using json = nlohmann::json;

static class JsonRequestPacketDeserializer
{
public:
	static LoginRequest deserializeLoginRequest(Buffer);
	static SignupRequest deserializeSignupRequest(Buffer);
	static GetPlayersInRoomRequest deserializeGetPlayersRequest(Buffer);
	static JoinRoomRequest deserializeJoinRoomRequest(Buffer);
	static CreateRoomRequest deserializeCreateRoomRequest(Buffer);
	static SubmitAnswerRequest deserializeSubmitAnswer(Buffer);
};
