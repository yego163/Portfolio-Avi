#pragma once
#include <iostream>
#include <vector>
#include <map>
#include "RoomData.h"

struct ErrorResponse {
	std::string message;
};
struct LoginResponse {
	unsigned int status;
};
struct SignupResponse {
	unsigned int status;
};
struct LogoutResponse {
	unsigned int status;
};
struct GetRoomsResponse {
	std::vector<RoomData> rooms;
	unsigned int status;
};
struct GetPlayersInRoomResponse {
	std::vector<std::string> players;
};
struct JoinRoomResponse {
	unsigned int status;
	std::string roomName;
	unsigned int _questionCount;
	unsigned int _answerTimeout;
};
struct CreateRoomResponse {
	unsigned int status;
	unsigned int ID;
};
struct getStatisticsResponse {
	unsigned int status;
	std::vector<std::string> statistics;
};
struct CloseRoomResponse {
	unsigned int status;
};
struct StartGameResponse {
	unsigned int status;
};
struct GetRoomStateResponse {
	unsigned int status;
	bool hasGameBegun;
	std::vector<std::string> players;
	unsigned int questionCount;
	unsigned int answerTimeout;
};
struct LeaveRoomResponse {
	unsigned int status;
};

struct GetQuestionResponse {
	unsigned int status;
	std::string question;
	std::map<unsigned int, std::string> answers;
};
struct SubmitAnswerResponse {
	unsigned int status;
	unsigned int correctAnswerId;
};
struct PlayerResults {
	std::string username;
	unsigned int correctAnswerCount;
	unsigned int wrongAnswerCount;
	unsigned int averageAnswerTime;
};
struct GetGameResultsResponse {
	unsigned int status;
	std::vector<PlayerResults> results;
};
struct LeaveGameResponse {
	unsigned int status;
};