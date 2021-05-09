#include "RoomMemberRequestHandler.h"


RoomMemberRequestHandler::RoomMemberRequestHandler(RequestHandlerFactory* fac, LoggedUser user, Room room) : m_room(room)
{
	m_handlerFactory = fac;
	m_user = user;
}

RequestResult RoomMemberRequestHandler::leaveRoom(RequestInfo inf)
{
	RequestResult reqRes;
	LeaveRoomResponse res;
	try
	{
		m_room.removeUser(m_user);
		res.status = OK;
		reqRes.response = JsonResponsePacketSerializer::serializeResponse(res);
		reqRes.newHandler = m_handlerFactory->createMenuRequestHandler(m_user);//return to menu...
	}
	catch (const std::exception& e)//failed 
	{
		ErrorResponse erorr = ErrorResponse();
		erorr.message = e.what();
		res.status = ERR;
		reqRes.response = JsonResponsePacketSerializer::serializeErrorResponse(erorr);
		reqRes.newHandler = m_handlerFactory->createRoomMemberRequestHandler(m_user, m_room);//err == same
	}
	return reqRes;
}

RequestResult RoomMemberRequestHandler::getRoomState(RequestInfo inf)
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
				if(m_handlerFactory->getRoomManager().getRoomState(it->second).hasGameBegun)//the game started
					reqRes.newHandler = m_handlerFactory->createGameRequestHandler(m_user, m_room);
				else
					reqRes.newHandler = m_handlerFactory->createRoomMemberRequestHandler(m_user, m_room);//end.
			}
		}
	}
	catch (const std::exception& e)//failed 
	{
		ErrorResponse erorr = ErrorResponse();
		erorr.message = e.what();
		reqRes.response = JsonResponsePacketSerializer::serializeErrorResponse(erorr);
		reqRes.newHandler = m_handlerFactory->createRoomMemberRequestHandler(m_user, m_room);//end.
	}
	return reqRes;
}

bool RoomMemberRequestHandler::isRequestRelevant(RequestInfo inf)
{
	return inf.id == LEAVE_ROOM_ID || inf.id == GET_ROOM_STATE_ID;
}

RequestResult RoomMemberRequestHandler::handleRequest(RequestInfo inf)
{
	RequestResult reqRes;
	JsonResponsePacketSerializer ResponsePacket;
	if (isRequestRelevant(inf))
	{
		switch (inf.id)
		{
		case GET_ROOM_STATE_ID:
		{
			reqRes = getRoomState(inf);
			break;
		}
		case LEAVE_ROOM_ID: {
			reqRes = leaveRoom(inf);
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
		reqRes.newHandler = m_handlerFactory->createRoomMemberRequestHandler(m_user, m_room);//end.
		reqRes.response = ResponsePacket.serializeErrorResponse(erorr);
	}
	return reqRes;
}
