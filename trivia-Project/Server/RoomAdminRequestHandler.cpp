#include "RoomAdminRequestHandler.h"


RoomAdminRequestHandler::RoomAdminRequestHandler(RequestHandlerFactory* fac, LoggedUser user, Room room) : m_room(room)
{
	m_handlerFactory = fac;
	m_user = user;
}

bool RoomAdminRequestHandler::isRequestRelevant(RequestInfo inf)
{
	return  inf.id == CLOSE_ROOM_ID || inf.id == START_GAME_ID || inf.id == GET_ROOM_STATE_ID;
}

RequestResult RoomAdminRequestHandler::handleRequest(RequestInfo inf)
{
	RequestResult reqRes;
	JsonResponsePacketSerializer ResponsePacket;
	if (isRequestRelevant(inf))
	{
		switch (inf.id)
		{
		case CLOSE_ROOM_ID:
		{
			reqRes = closeRoom(inf);
			break;
		}
		case START_GAME_ID: {
			reqRes = startGame(inf);
			break;
		}
		case GET_ROOM_STATE_ID: {
			reqRes = getRoomState(inf);
			break;
		}
		default:
			break;
		}
	}
	else
	{
		ErrorResponse erorr = ErrorResponse();
		erorr.message = "The Request is not Relevant";
		reqRes.newHandler = m_handlerFactory->createRoomAdminRequestHandler(m_user, m_room);
		reqRes.response = ResponsePacket.serializeErrorResponse(erorr);
	}
	return reqRes;
}

RequestResult RoomAdminRequestHandler::closeRoom(RequestInfo inf)
{
	RequestResult reqRes;
	CloseRoomResponse res;
	try
	{
		for (size_t i = 0; i < m_room.getAllUsers().size(); i++)//leave the users in the room(they dont have access in anymore...)
		{
			m_room.removeUser(m_room.getAllUsers()[i]);
		}
		m_handlerFactory->getRoomManager().deleteRoom(m_room.getRoomData().getId());//remove the room
		res.status = OK;
		reqRes.response = JsonResponsePacketSerializer::serializeResponse(res);
		reqRes.newHandler = m_handlerFactory->createMenuRequestHandler(m_user);//end.
	}
	catch (const std::exception& e)//failed 
	{
		ErrorResponse erorr = ErrorResponse();
		erorr.message = e.what();
		res.status = ERR;
		reqRes.response = JsonResponsePacketSerializer::serializeErrorResponse(erorr);
		reqRes.newHandler = m_handlerFactory->createRoomAdminRequestHandler(m_user, m_room);
	}
	return reqRes;
}

RequestResult RoomAdminRequestHandler::startGame(RequestInfo inf)
{
	RequestResult reqRes;
	StartGameResponse res;
	try
	{
		std::map<int, Room>* M_rooms = m_handlerFactory->getRoomManager().getM_Rooms();
		for (std::map<int, Room>::iterator it = M_rooms->begin(); it != M_rooms->end(); it++)
		{
			if (it->first == m_room.getRoomData().getId())
			{
				it->second.getRoomData().setIsActive(true);
				reqRes.newHandler = m_handlerFactory->createGameRequestHandler(m_user, it->second);
			}
		}
		res.status = OK;
		reqRes.response = JsonResponsePacketSerializer::serializeResponse(res);
	}
	catch (const std::exception& e)//failed 
	{
		ErrorResponse erorr = ErrorResponse();
		erorr.message = e.what();
		res.status = ERR;
		reqRes.response = JsonResponsePacketSerializer::serializeErrorResponse(erorr);
		reqRes.newHandler = m_handlerFactory->createRoomAdminRequestHandler(m_user, m_room);
	}
	return reqRes;
}

RequestResult RoomAdminRequestHandler::getRoomState(RequestInfo inf)
{
	RequestResult reqRes;
	try
	{
		std::vector<RoomData> arr = m_handlerFactory->getRoomManager().getRooms();
		if (!roomInVector(arr, m_room.getRoomData()))
			throw std::exception("Room has been cloesed");
		std::map<int, Room>* M_rooms = m_handlerFactory->getRoomManager().getM_Rooms();
		for (std::map<int, Room>::iterator it = M_rooms->begin(); it != M_rooms->end(); it++)
		{
			if (it->first == m_room.getRoomData().getId())
			{
				reqRes.response = JsonResponsePacketSerializer::serializeResponse(m_handlerFactory->getRoomManager().getRoomState(it->second));
			}
		}
	}
	catch (const std::exception& e)//failed 
	{
		ErrorResponse erorr = ErrorResponse();
		erorr.message = e.what();
		reqRes.response = JsonResponsePacketSerializer::serializeErrorResponse(erorr);
	}
	reqRes.newHandler = m_handlerFactory->createRoomAdminRequestHandler(m_user, m_room);//doesn't change anything about the progress
	return reqRes;
}
