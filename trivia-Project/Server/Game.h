#pragma once
#include <iostream>
#include <map>
#include <vector>
#include <list>
#include "GameData.h"
#include "LoggedUser.h"
#include "Question.h"
#include <chrono>

class Game
{
private:
	static int numOfGame;//count how many game objects were created
	int _id;
	std::vector<Question> m_questions;
	std::map<LoggedUser, GameData> m_players;
	std::map<LoggedUser, GameData> m_removedPlayers;
	std::map<LoggedUser, std::chrono::steady_clock::time_point> _timeForQ;
public:
	Game(std::map<LoggedUser, GameData> players, std::vector<Question> questions);
	void getQuestionForUser(LoggedUser);
	void submitAnswer(LoggedUser user, int idOfAnswer);
	void removePlayer(LoggedUser user);

	int getId() const;
	std::map<LoggedUser, GameData>& getPlayers();
};

