#include "MenuRequestHandler.h"

MenuRequestHandler::MenuRequestHandler(RequestHandlerFactory* fac, LoggedUser m_user_) {
	m_handlerFactory = fac;
	m_user = m_user_.getUserName();
}

bool MenuRequestHandler::isRequestRelevant(RequestInfo RequestInfo)
{
	std::string id = std::to_string(RequestInfo.id);
	return id == CREATE_ROOM_CODE || id == GET_ROOMS_CODE || id == GET_PLAYERS_IN_ROOM_CODE 
		|| id == JOIN_ROOM_CODE || id == HIGH_SCORE_CODE || id == LOGOUT_CODE;
}

RequestResult MenuRequestHandler::handleRequest(RequestInfo RequestInfo)
{
	RequestResult reqRes;
	JsonResponsePacketSerializer ResponsePacket;
	if (isRequestRelevant(RequestInfo))
	{
		switch (RequestInfo.id)
		{
		case LOGOUT_ID:
		{
			reqRes = signout(RequestInfo);
			break;
		}
		case GET_ROOMS_ID: {
			reqRes = getRooms(RequestInfo);
			break;
		}
		case GET_PLAYERS_IN_ROOM_ID: {
			reqRes = getPlayersInRoom(RequestInfo);
			break;
		}
		case HIGH_SCORE_ID: {
			reqRes = getStatistics(RequestInfo);
			break;
		}
		case JOIN_ROOM_ID: {
			reqRes = joinRoom(RequestInfo);
			break;
		}
		case CREATE_ROOM_ID: {
			reqRes = createRoom(RequestInfo);
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
		reqRes.newHandler = m_handlerFactory->createMenuRequestHandler(m_user);
		reqRes.response = ResponsePacket.serializeErrorResponse(erorr);
	}
	return reqRes;
}

RequestResult MenuRequestHandler::signout(RequestInfo inf)
{
	RequestResult reqRes;
	LogoutResponse res;
	try//try to signout
	{
		m_handlerFactory->getLoginManager().logout(m_user.getUserName());
		res.status = OK;
		reqRes.response = JsonResponsePacketSerializer::serializeLogoutResponse(res);
		reqRes.newHandler = nullptr;//end.
	}
	catch (const std::exception& e)//failed 
	{
		ErrorResponse erorr = ErrorResponse();
		erorr.message = e.what();
		res.status = ERR;//cant logout
		reqRes.response = JsonResponsePacketSerializer::serializeErrorResponse(erorr);
		reqRes.newHandler = m_handlerFactory->createMenuRequestHandler(m_user);
	}
	return reqRes;
}

RequestResult MenuRequestHandler::getRooms(RequestInfo inf)
{
	bool find = false;
	RequestResult reqRes;
	GetRoomsResponse res;
	try
	{
		res.status = OK;
		res.rooms = m_handlerFactory->getRoomManager().getRooms();
		reqRes.response = JsonResponsePacketSerializer::serializeGetRoomResponse(res);
		reqRes.newHandler = m_handlerFactory->createMenuRequestHandler(m_user); //the user dont continue the process
	}
	catch (const std::exception& e)
	{
		ErrorResponse erorr = ErrorResponse();
		erorr.message = e.what();
		res.status = ERR;
		reqRes.response = JsonResponsePacketSerializer::serializeErrorResponse(erorr);
		reqRes.newHandler = m_handlerFactory->createMenuRequestHandler(m_user);
	}
	return reqRes;
}

RequestResult MenuRequestHandler::getPlayersInRoom(RequestInfo inf)
{
	bool find = false;
	RequestResult reqRes;
	GetPlayersInRoomResponse res;
	JoinRoomRequest jm = JsonRequestPacketDeserializer::deserializeJoinRoomRequest(inf.buffer);
	try
	{
		std::map<int, Room>* rooms = m_handlerFactory->getRoomManager().getM_Rooms();
		std::map<int, Room>::iterator it;
		for (it = rooms->begin(); it != rooms->end(); it++)
		{
			if (it->first == jm.roomid)
			{
				for (size_t i = 0; i < it->second.getAllUsers().size(); i++)
					res.players.push_back(it->second.getAllUsers()[i].getUserName());
				find = true;
			}
		}
		if(find == false)
			throw std::invalid_argument("Room is not Exists");
		reqRes.response = JsonResponsePacketSerializer::serializeGetPlayersInRoomResponse(res);
		reqRes.newHandler = m_handlerFactory->createMenuRequestHandler(m_user);
	}
	catch (const std::exception& e)//failed 
	{
		ErrorResponse erorr = ErrorResponse();
		erorr.message = e.what();
		reqRes.response = JsonResponsePacketSerializer::serializeErrorResponse(erorr);
		reqRes.newHandler = m_handlerFactory->createMenuRequestHandler(m_user);
	}
	return reqRes;
}

RequestResult MenuRequestHandler::getStatistics(RequestInfo inf)
{
	RequestResult reqRes;
	getStatisticsResponse res;
	try
	{
		std::vector<std::string> Stat = m_handlerFactory->getStatisticsManager().getStatistics(m_user.getUserName());
		res.statistics.push_back(Stat[0]);
		res.statistics.push_back(Stat[1]);
		res.status = OK;
		reqRes.response = JsonResponsePacketSerializer::serializeHighScoreResponse(res);
		reqRes.newHandler = m_handlerFactory->createMenuRequestHandler(m_user);
	}
	catch (const std::exception& e)//failed 
	{
		ErrorResponse erorr = ErrorResponse();
		erorr.message = e.what();
		res.status = ERR;
		reqRes.response = JsonResponsePacketSerializer::serializeErrorResponse(erorr);
		reqRes.newHandler = m_handlerFactory->createMenuRequestHandler(m_user);
	}
	return reqRes;
}

RequestResult MenuRequestHandler::joinRoom(RequestInfo inf)
{
	bool find = false;
	RequestResult reqRes;
	JoinRoomRequest jm = JsonRequestPacketDeserializer::deserializeJoinRoomRequest(inf.buffer);
	JoinRoomResponse res;
	int roomId = 0;
	try
	{
		std::map<int, Room>* M_rooms = m_handlerFactory->getRoomManager().getM_Rooms();
		for (std::map<int, Room>::iterator it = M_rooms->begin(); it != M_rooms->end(); it++)
		{
			if (it->first == jm.roomid)
			{
				if (it->second.getAllUsers().size() < it->second.getRoomData().getMaxPlayers()) {//check if there is space in the room
					res.roomName = it->second.getRoomData().getName();
					res._answerTimeout = it->second.getRoomData().getTimePerQuestion();
					res._questionCount = it->second.getRoomData().getQuestionCount();
					it->second.addUser(m_user.getUserName());
					find = true;
				}
				else
					throw std::invalid_argument("Room is full");
			}
		}
		if (find == false)
			throw std::invalid_argument("Room is not Exists");
		res.status = OK;
		reqRes.response = JsonResponsePacketSerializer::serializeJoinRoomResponse(res);
		reqRes.newHandler = m_handlerFactory->createRoomMemberRequestHandler(m_user, (*M_rooms)[roomId]);
	}
	catch (const std::exception& e)//failed 
	{
		ErrorResponse erorr = ErrorResponse();
		erorr.message = e.what();
		res.status = ERR;
		reqRes.response = JsonResponsePacketSerializer::serializeErrorResponse(erorr);
		reqRes.newHandler = m_handlerFactory->createMenuRequestHandler(m_user);
	}
	return reqRes;
}

RequestResult MenuRequestHandler::createRoom(RequestInfo inf)
{
	RequestResult reqRes;
	try
	{
		CreateRoomRequest CR = JsonRequestPacketDeserializer::deserializeCreateRoomRequest(inf.buffer);
		std::vector<RoomData> rooms = m_handlerFactory->getRoomManager().getRooms();
		m_handlerFactory->getRoomManager().createRoom(rooms.size(), m_user, CR);
		CreateRoomResponse res;
		res.status = OK;
		res.ID = rooms.size();
		reqRes.response = JsonResponsePacketSerializer::serializeCreateRoomResponse(res);
		reqRes.newHandler = reqRes.newHandler = m_handlerFactory->createRoomAdminRequestHandler(m_user, (*m_handlerFactory->getRoomManager().getM_Rooms())[rooms.size()]);
	}
	catch (const std::exception& e)//failed 
	{
		ErrorResponse erorr = ErrorResponse();
		erorr.message = e.what();
		reqRes.response = JsonResponsePacketSerializer::serializeErrorResponse(erorr);
		reqRes.newHandler = m_handlerFactory->createMenuRequestHandler(m_user);
	}
	return reqRes;
}
