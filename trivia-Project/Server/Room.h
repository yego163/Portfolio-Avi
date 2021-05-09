#pragma once
#include "RoomData.h"
#include "LoggedUser.h"
#include <vector>
#include <string>

class Room
{
public:
	Room();
	Room(RoomData data);
	void addUser(LoggedUser user);
	void removeUser(LoggedUser user);
	std::vector<LoggedUser> getAllUsers();
	RoomData& getRoomData();
private:
	RoomData m_metadata;
	std::vector<LoggedUser> m_users;
};
