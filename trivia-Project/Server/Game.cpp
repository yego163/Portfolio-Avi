#include "Game.h"

int Game::numOfGame = 0;//init the variable

Game::Game(std::map<LoggedUser, GameData> players, std::vector<Question> questions)
{
	m_players = players;
	m_questions = questions;
	_id = numOfGame;
	numOfGame++;
	for (std::map<LoggedUser, GameData>::iterator it = players.begin(); it != players.end(); it++)//set the start timer
		_timeForQ[it->first] = std::chrono::high_resolution_clock::now();
}

void Game::getQuestionForUser(LoggedUser user)
{//will change in the vector
	size_t i = 0;
	for (i = 0; i < m_questions.size() && m_players[user].correntQuestion.num_correctAnswer != -10; i++)//get the idx of the question
		if (m_questions[i].getQuestion() == m_players[user].correntQuestion.getQuestion())//supposed to be only one qustion
			break;
	if (i + 1== m_questions.size() && m_players[user].correntQuestion.num_correctAnswer != -10)//if the user in the last question and ask for the next one
		throw std::invalid_argument("player answer on all quesions");//for status 0 - player already answer on al questions
	if (m_players[user].correntQuestion.num_correctAnswer == -10)//if the player get his first Q
		m_players[user] = { m_questions[0], 0 , 0, 0 };//set the first question
	else
		m_players[user].correntQuestion = m_questions[i + 1];//set the next question
	_timeForQ[user] = std::chrono::high_resolution_clock::now();//start count for the next question
}

void Game::submitAnswer(LoggedUser user, int idOfAnswer)
{
	if (idOfAnswer == m_players[user].correntQuestion.num_correctAnswer)//if the user was right
		m_players[user].correctAnswerCount++;
	else//if the user was wrong
		m_players[user].wrongAnswerCount++;
	auto t1 = std::chrono::high_resolution_clock::now();
	float timeForQ = std::chrono::duration_cast<std::chrono::seconds> (t1 - _timeForQ[user]).count();
	m_players[user].averangeAnswerTime =
		((m_players[user].averangeAnswerTime * (m_players[user].wrongAnswerCount + m_players[user].correctAnswerCount - 1))//the old sum of Time
			+ timeForQ)//add the new param
		/ m_players[user].correctAnswerCount + m_players[user].wrongAnswerCount;//divide by the new sum of Q
}

void Game::removePlayer(LoggedUser user)
{
	GameData save = m_players[user];
	std::map<LoggedUser, GameData>::iterator it = m_players.find(user);
	m_players.erase(it);//remove the user
	m_removedPlayers[user] = save;//save the data from removedPlayers
}

int Game::getId() const
{
	return _id;
}

std::map<LoggedUser, GameData>& Game::getPlayers()
{
	std::map<LoggedUser, GameData> allPlayers = std::map<LoggedUser, GameData>();
	allPlayers.insert(m_players.begin(), m_players.end());
	allPlayers.insert(m_removedPlayers.begin(), m_removedPlayers.end());//combine the online users and the left users
	return m_players;
}
