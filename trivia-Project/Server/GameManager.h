#pragma once
#include <iostream>
#include <map>
#include <algorithm>
#include <vector>
#include <list>
#include "Game.h"
#include "Room.h"
#include "tools.h"

class GameManager
{
private:
	IDatabase* _db;
	std::vector<Game*> m_games;
public:
	GameManager(IDatabase* db);
	Game* createGame(Room);
	void deleteGame(int);
	std::vector<Game*>& getM_games();
	bool GameExits(Game* game);
};

