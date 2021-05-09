#pragma once
#include <iostream>
#include <map>
#include "LoggedUser.h"
#include "RoomData.h"
#include "Room.h"
#include <vector>
#include "JsonRequestPacketDeserializer.h"
#include "ResponseStructs.h"

class RoomManager
{
public:
	RoomManager();
	~RoomManager();
	void createRoom(int id, LoggedUser, CreateRoomRequest CR);
	void deleteRoom(int ID);
	GetRoomStateResponse getRoomState(Room r);
	std::vector<RoomData> getRooms();
	std::map<int, Room>* getM_Rooms();
private:
	std::map<int, Room>* m_rooms;
};