#include "GameRequestHandler.h"


GameRequestHandler::GameRequestHandler(RequestHandlerFactory* fac, LoggedUser user, Game* game, Room room) : m_game(game), m_room(room) 
{
	m_handlerFactory = fac;
	m_user = user;
	/*std::thread t(&GameRequestHandler::checkPlayersInGame, this);
	t.detach();*/
}

GameRequestHandler::~GameRequestHandler()
{
}

bool GameRequestHandler::isRequestRelevant(RequestInfo inf)
{
	return inf.id == LEAVE_GAME_ID || inf.id == GET_QUESION_ID || inf.id == SUBMIT_ANSWER_ID || inf.id == GET_GAME_RESULT_ID || inf.id == CLOSE_GAME_ID;
}
RequestResult GameRequestHandler::handleRequest(RequestInfo inf)
{
	RequestResult reqRes;
	JsonResponsePacketSerializer ResponsePacket;
	if (isRequestRelevant(inf))
	{
		switch (inf.id)
		{
		case GET_GAME_RESULT_ID:
		{
			reqRes = getGameResults(inf);
			break;
		}
		case GET_QUESION_ID: {
			reqRes = getQuestion(inf);
			break;
		}
		case SUBMIT_ANSWER_ID: {
			reqRes = submitAnswer(inf);
			break;
		}
		case LEAVE_GAME_ID: {
			reqRes = leaveGame(inf);
			break;
		}
		case CLOSE_GAME_ID: {
			reqRes = deleteGameAndRoom();
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

Room GameRequestHandler::getGameRoom()
{
	return m_room;
}

RequestResult GameRequestHandler::getGameResults(RequestInfo inf)
{
	RequestResult reqRes;
	GetGameResultsResponse res;
	int thisUserAnswerOnAllQuesions = 0;
	try
	{
		std::vector<PlayerResults> PlayersRes;
		std::vector<Game*> games = m_handlerFactory->getGameManager().getM_games();
		std::map<LoggedUser, GameData> players = games.at(m_game->getId())->getPlayers(); 
		for (std::map<LoggedUser, GameData>::iterator it1 = players.begin(); it1 != players.end(); it1++)
		{
			try
			{
				games.at(m_game->getId())->getQuestionForUser(it1->first);
			}
			catch (const std::invalid_argument& e)
			{
				if (std::string(e.what()) == "player answer on all quesions")
				{
					thisUserAnswerOnAllQuesions++;
					PlayersRes.push_back(PlayerResults{ it1->first.getUserName(), it1->second.correctAnswerCount, it1->second.wrongAnswerCount, it1->second.averangeAnswerTime });
				}
			}
		}
		if (thisUserAnswerOnAllQuesions == players.size())
		{
			for (auto var : players)
			{
				m_handlerFactory->getDb()->setNewStatistics(m_room.getRoomData().getQuestionCount(), var.second.correctAnswerCount, var.second.averangeAnswerTime, var.first.getUserName());//set the result answers
			}
			res.status = OK;
			res.results = PlayersRes;
			reqRes.newHandler = this;

		}
		else
		{
			reqRes.newHandler = this;
			res.status = ERR;
			res.results = std::vector<PlayerResults>();
		}
		reqRes.response = JsonResponsePacketSerializer::serializeResponse(res);
	}
	catch (const std::exception& e)//failed 
	{
		ErrorResponse erorr = ErrorResponse();
		erorr.message = e.what();
		reqRes.response = JsonResponsePacketSerializer::serializeErrorResponse(erorr);
		reqRes.newHandler = this;
	}
	return reqRes;
}

RequestResult GameRequestHandler::getQuestion(RequestInfo inf)
{
	RequestResult reqRes;
	GetQuestionResponse res;
	try
	{
		m_game->getQuestionForUser(m_user);
		std::map<LoggedUser, GameData> players = m_game->getPlayers();
		for (std::map<LoggedUser, GameData>::iterator it1 = players.begin(); it1 != players.end(); it1++)
			if (it1->first.getUserName() == m_user.getUserName())
			{
				res.question = it1->second.correntQuestion.getQuestion();
				std::vector<std::string> PossibleAnswers = it1->second.correntQuestion.getPossibleAnswers();
				for (size_t i = 0; i < PossibleAnswers.size(); i++)
 					res.answers.insert(res.answers.begin(), std::pair<unsigned int, std::string>(i, PossibleAnswers[i]));
			}
		res.status = OK;
		reqRes.newHandler = this;
		reqRes.response = JsonResponsePacketSerializer::serializeResponse(res);
	}
	catch (const std::exception& e)//failed 
	{
		if (std::strcmp(e.what(), "player answer on all quesions") == 0) // if the game end Properly
		{
			GameData dataOnUser = m_game->getPlayers()[m_user.getUserName()];
			res.status = ERR;
			res.question = "";
			res.answers = std::map<unsigned int, std::string>();
			reqRes.newHandler = this;
			reqRes.response = JsonResponsePacketSerializer::serializeResponse(res);
		}
		else // if the game Crash
		{
			ErrorResponse erorr = ErrorResponse();
			erorr.message = e.what();
			reqRes.response = JsonResponsePacketSerializer::serializeErrorResponse(erorr);
			reqRes.newHandler = m_handlerFactory->createMenuRequestHandler(m_user);
		}
	}
	return reqRes;
}

RequestResult GameRequestHandler::submitAnswer(RequestInfo inf)
{
	RequestResult reqRes;
	SubmitAnswerResponse res;
	try
	{
		SubmitAnswerRequest ans = JsonRequestPacketDeserializer::deserializeSubmitAnswer(inf.buffer);
		std::map<LoggedUser, GameData> players = m_game->getPlayers();
		for (std::map<LoggedUser, GameData>::iterator it = players.begin(); it != players.end(); it++)
			if (it->first.getUserName() == m_user.getUserName())
				res.correctAnswerId = it->second.correntQuestion.num_correctAnswer;
		m_game->submitAnswer(m_user, ans.answerId);
		res.status = OK;
		reqRes.response = JsonResponsePacketSerializer::serializeResponse(res);
	}
	catch (const std::exception& e)//failed 
	{
		ErrorResponse erorr = ErrorResponse();
		erorr.message = e.what();
		res.status = ERR;
		reqRes.response = JsonResponsePacketSerializer::serializeErrorResponse(erorr);
	}
	reqRes.newHandler = this;
	return reqRes;
}

RequestResult GameRequestHandler::leaveGame(RequestInfo inf)
{
	RequestResult reqRes;
	LeaveGameResponse res;
	try
	{
		m_game->removePlayer(m_user);
		res.status = OK;
		reqRes.response = JsonResponsePacketSerializer::serializeResponse(res);
	}
	catch (const std::exception& e)//failed 
	{
		ErrorResponse erorr = ErrorResponse();
		erorr.message = e.what();
		res.status = ERR;
		reqRes.response = JsonResponsePacketSerializer::serializeErrorResponse(erorr);
	}
	reqRes.newHandler = m_handlerFactory->createMenuRequestHandler(m_user);
	return reqRes;
}
RequestResult GameRequestHandler::deleteGameAndRoom()
{
	RequestResult reqRes;
	CloseRoomResponse res;
	res.status = OK;
	m_handlerFactory->getGameManager().deleteGame(m_game->getId());
	m_handlerFactory->getRoomManager().deleteRoom(m_room.getRoomData().getId());
	reqRes.newHandler = m_handlerFactory->createMenuRequestHandler(m_user);
	reqRes.response = JsonResponsePacketSerializer::serializeResponse(res);
	return reqRes;
}



