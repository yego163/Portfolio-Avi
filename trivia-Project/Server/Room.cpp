#include "Room.h"

Room::Room():m_metadata(RoomData(0,"",0,0,0,false))
{
	std::cout << "FUCKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKL";
}

Room::Room(RoomData data) : m_metadata(data)
{
}

void Room::addUser(LoggedUser user)
{
	if (std::count(m_users.begin(), m_users.end(), user))
		throw std::invalid_argument("User in the Room");
	m_users.push_back(user);
}

void Room::removeUser(LoggedUser user)
{
	if (!std::count(m_users.begin(), m_users.end(), user))
		throw std::invalid_argument("User not in the Room");
	m_users.erase(remove(m_users.begin(), m_users.end(), user));
}

RoomData& Room::getRoomData()
{
	return m_metadata;
}

std::vector<LoggedUser> Room::getAllUsers()
{
	return m_users;
}