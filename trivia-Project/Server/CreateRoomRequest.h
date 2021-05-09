#pragma once
#include <iostream>

struct CreateRoomRequest
{
	std::string roomName;
	int maxUsers;
	int questionCount;
	int answerTimeout;
};
