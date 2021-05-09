#include "JsonResponsePacketSerializer.h"
using json = nlohmann::json;

std::string JsonResponsePacketSerializer::complateString(std::string data, int toSize, char c)
{
	for (size_t i = data.size(); i < toSize; i++)//until this full
		data = c + data;//add the char to left
	return data;
}

std::string JsonResponsePacketSerializer::getRoomsName(std::vector<RoomData> rooms)
{
	if (rooms.size() == 0) return "";
	std::string names;
	for (int i = 0; i < rooms.size(); i++)
		names = names + rooms[i].getName() + "," + std::to_string(rooms[i].getId()) + ",";
	return names.substr(0, names.size() - 1);;//remove last comma
}

Buffer JsonResponsePacketSerializer::serializeErrorResponse(ErrorResponse respon)
{
	json j;
	j["message"] = respon.message;
	std::string message = j.dump();
	return stringToBuffer(std::string() + ERROR_CODE
		+ complateString(std::to_string(message.size()), 4, '0')
		+ message);
}

Buffer JsonResponsePacketSerializer::serializeLoginResponse(LoginResponse respon)
{
	json j;
	j["status"] = respon.status;
	std::string status = j.dump();
	return stringToBuffer(std::string() + LOGIN_CODE
		+ complateString(std::to_string(status.size()), 4, '0')
		+ status);
}

Buffer JsonResponsePacketSerializer::serializeSignUpResponse(SignupResponse respon)
{
	json j;
	j["status"] = respon.status;
	std::string status = j.dump();
	return stringToBuffer(std::string() + SIGNUP_CODE
		+ complateString(std::to_string(status.size()), 4, '0')
		+ status);
}

Buffer JsonResponsePacketSerializer::serializeLogoutResponse(LogoutResponse respon)
{
	json j;
	j["status"] = respon.status;
	std::string status = j.dump();
	return stringToBuffer(std::string() + LOGOUT_CODE
		+ complateString(std::to_string(status.size()), 4, '0')
		+ status);
}

Buffer JsonResponsePacketSerializer::serializeGetRoomResponse(GetRoomsResponse respon)
{
	json j;
	std::string strRespon = getRoomsName(respon.rooms);
	j["Rooms"] = strRespon;
	std::string status = j.dump();
	return stringToBuffer(std::string() + GET_ROOMS_CODE
		+ complateString(std::to_string(status.size()), 4, '0')
		+ status);
}

Buffer JsonResponsePacketSerializer::serializeGetPlayersInRoomResponse(GetPlayersInRoomResponse respon)
{
	json j;
	j["PlayersInRoom"] = respon.players;
	std::string status = j.dump();
	return stringToBuffer(std::string() + GET_PLAYERS_IN_ROOM_CODE
		+ complateString(std::to_string(status.size()), 4, '0')
		+ status);
}

Buffer JsonResponsePacketSerializer::serializeJoinRoomResponse(JoinRoomResponse respon)
{
	json j;
	j["status"] = respon.status;
	j["roomName"] = respon.roomName;
	j["answerTimeout"] = respon._answerTimeout;
	j["questionCount"] = respon._questionCount;
	std::string status = j.dump();
	return stringToBuffer(std::string() + JOIN_ROOM_CODE
		+ complateString(std::to_string(status.size()), 4, '0')
		+ status);
}

Buffer JsonResponsePacketSerializer::serializeCreateRoomResponse(CreateRoomResponse respon)
{
	json j;
	j["ID"] = respon.ID;
	j["status"] = respon.status;
	std::string status = j.dump();
	return stringToBuffer(std::string() + CREATE_ROOM_CODE
		+ complateString(std::to_string(status.size()), 4, '0')
		+ status);
}

Buffer JsonResponsePacketSerializer::serializeHighScoreResponse(getStatisticsResponse respon)
{
	json j;
	j["UserStatistics"] = respon.statistics[0];
	j["HighScores"] = respon.statistics[1];
	std::string status = j.dump();
	return stringToBuffer(std::string() + HIGH_SCORE_CODE
		+ complateString(std::to_string(status.size()), 4, '0')
		+ status);
}

Buffer JsonResponsePacketSerializer::serializeResponse(CloseRoomResponse response)
{
	json j;
	j["status"] = response.status;
	std::string status = j.dump();
	return stringToBuffer(std::string() + CLOSE_ROOM_CODE
		+ complateString(std::to_string(status.size()), 4, '0')
		+ status);
}

Buffer JsonResponsePacketSerializer::serializeResponse(StartGameResponse response)
{
	json j;
	j["status"] = response.status;
	std::string status = j.dump();
	return stringToBuffer(std::string() + START_GAME_CODE
		+ complateString(std::to_string(status.size()), 4, '0')
		+ status);
}

Buffer JsonResponsePacketSerializer::serializeResponse(GetRoomStateResponse response)
{
	json j;
	j["status"] = response.status;
	j["hasGameBegun"] = response.hasGameBegun;
	j["players"] = response.players;
	j["questionCount"] = response.questionCount;
	j["answerTimeout"] = response.answerTimeout;
	std::string status = j.dump();
	return stringToBuffer(std::string() + GET_ROOM_STATE_CODE
		+ complateString(std::to_string(status.size()), 4, '0')
		+ status);
}

Buffer JsonResponsePacketSerializer::serializeResponse(LeaveRoomResponse response)
{
	json j;
	j["status"] = response.status;
	std::string status = j.dump();
	return stringToBuffer(std::string() + LEAVE_ROOM_CODE
		+ complateString(std::to_string(status.size()), 4, '0')
		+ status);
}

Buffer JsonResponsePacketSerializer::serializeResponse(GetGameResultsResponse response)
{
	if (response.status == 0)
		response.results = std::vector<PlayerResults>();//clear the list if the game has'nt end yet
	json j;
	j["status"] = response.status;
	std::vector<json> PlayerResultsJson;
	json js;
	for (size_t i = 0; i < response.results.size(); i++)//create a vector of json type of all the class
	{
		js["averageAnswerTime"] = response.results[i].averageAnswerTime;
		js["correctAnswerCount"] = response.results[i].correctAnswerCount;
		js["username"] = response.results[i].username;
		js["wrongAnswerCount"] = response.results[i].wrongAnswerCount;
		PlayerResultsJson.push_back(js);
	}
	j["results"] = PlayerResultsJson;
	std::string status = j.dump();
	return stringToBuffer(std::string() + GET_GAME_RESULT_CODE
		+ complateString(std::to_string(status.size()), 4, '0')
		+ status);
}

Buffer JsonResponsePacketSerializer::serializeResponse(SubmitAnswerResponse response)
{
	json j;
	j["status"] = response.status;
	j["correctAnswerId"] = response.correctAnswerId;
	std::string status = j.dump();
	return stringToBuffer(std::string() + SUBMIT_ANSWER_CODE
		+ complateString(std::to_string(status.size()), 4, '0')
		+ status);
}

Buffer JsonResponsePacketSerializer::serializeResponse(GetQuestionResponse response)
{
	if (response.status == 0) {//if failed clear all other things
		response.question = "";
		response.answers = std::map<unsigned int, std::string>();
	}
	json j;
	j["status"] = response.status;
	j["question"] = response.question;
	j["answers"] = response.answers;
	std::string status = j.dump();
	return stringToBuffer(std::string() + GET_QUESION_CODE
		+ complateString(std::to_string(status.size()), 4, '0')
		+ status);
}

Buffer JsonResponsePacketSerializer::serializeResponse(LeaveGameResponse response)
{
	json j;
	j["status"] = response.status;
	std::string status = j.dump();
	return stringToBuffer(std::string() + LEAVE_GAME_CODE
		+ complateString(std::to_string(status.size()), 4, '0')
		+ status);
}


