#include "RoomManager.h"

RoomManager::RoomManager()
{
	m_rooms = new std::map<int, Room>();
}

RoomManager::~RoomManager()
{
	delete m_rooms;
}

void RoomManager::createRoom(int id, LoggedUser user, CreateRoomRequest CR)
{
	std::map<int, Room>::iterator it;
	for (it = m_rooms->begin(); it != m_rooms->end(); it++)
	{
		if(it->first == id)
			throw std::invalid_argument("The room already exists");
	}
	Room room(RoomData(id, CR.roomName, CR.maxUsers, CR.questionCount, CR.answerTimeout, false));
	room.addUser(user);
	m_rooms->insert({id,room});
}

void RoomManager::deleteRoom(int id)
{
	if (m_rooms->count(id) == 0)
	{
		throw std::invalid_argument("The room not exists");
	}
	m_rooms->erase(id);
}

GetRoomStateResponse RoomManager::getRoomState(Room r)
{
	GetRoomStateResponse res;
	res.hasGameBegun = r.getRoomData().getIsActive();
	res.answerTimeout = r.getRoomData().getTimePerQuestion();
	std::vector<LoggedUser> users = r.getAllUsers();
	for (size_t i = 0; i < users.size(); i++)
		res.players.push_back(users[i].getUserName());
	res.questionCount = r.getRoomData().getQuestionCount();
	res.status = 1;
	return res;
}

std::vector<RoomData> RoomManager::getRooms()
{
	std::vector<RoomData> RoomMetadata;
	if (m_rooms->empty()) return RoomMetadata;
	for (std::map<int, Room>::iterator it = m_rooms->begin(); it != m_rooms->end(); ++it)
		RoomMetadata.push_back(it->second.getRoomData());
	return RoomMetadata;
}

std::map<int, Room>* RoomManager::getM_Rooms()
{
	return m_rooms;
}
