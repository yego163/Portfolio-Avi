#pragma once
#include "RequestInfo.h"
#include "ResponseStructs.h"
#include "Buffer.h"
#include "json.hpp"
#include <string>
#include "StatisticsManager.h"
#include "messagesCodes.h"

static class JsonResponsePacketSerializer
{
private:
	static std::string complateString(std::string data, int toSize, char c);
	static std::string getRoomsName(std::vector<RoomData>);
public:
	static Buffer serializeErrorResponse(ErrorResponse respon);
	static Buffer serializeLoginResponse(LoginResponse respon);
	static Buffer serializeSignUpResponse(SignupResponse respon);
	static Buffer serializeLogoutResponse(LogoutResponse respon);
	static Buffer serializeGetRoomResponse(GetRoomsResponse respon);
	static Buffer serializeGetPlayersInRoomResponse(GetPlayersInRoomResponse respon);
	static Buffer serializeJoinRoomResponse(JoinRoomResponse respon);
	static Buffer serializeCreateRoomResponse(CreateRoomResponse respon);
	static Buffer serializeHighScoreResponse(getStatisticsResponse respon);
	static Buffer serializeResponse(CloseRoomResponse response);
	static Buffer serializeResponse(StartGameResponse response);
	static Buffer serializeResponse(GetRoomStateResponse response);
	static Buffer serializeResponse(LeaveRoomResponse response);
	static Buffer serializeResponse(GetGameResultsResponse response);
	static Buffer serializeResponse(SubmitAnswerResponse response);
	static Buffer serializeResponse(GetQuestionResponse response);
	static Buffer serializeResponse(LeaveGameResponse response);
};
