#pragma once
#include <iostream>
#include <algorithm>
#include <string>
#include "IDatabase.h"
#include "LoggedUser.h"
#include <vector>
#include "tools.h"

struct LoggedUserIsBetter;


class StatisticsManager
{
private:
	IDatabase* m_database;
	bool isBetter(std::string first, std::string sec);
	std::vector<std::string> sort(std::vector<std::string> arr);
public:
	StatisticsManager(IDatabase* db);
	std::vector<std::string> getStatistics(std::string myPlayer);
};


