#include "StatisticsManager.h"

bool StatisticsManager::isBetter(std::string first, std::string sec)
{
	//Grade will be: 80% Correct Ans From Total Answer, 15% AVGtime, 5% TotalGame
	float one = 0, two = 0;
	try {
		one = float(m_database->getNumOfCorrectAnswers(first) - m_database->getNumOfTotalAnswers(first)) * 0.8
			+ m_database->getPlayerAverageAnswerTime(first) * 0.15 + m_database->getNumOfPlayerGames(first);
	}
	catch (...){}
	try {
		two = float(m_database->getNumOfCorrectAnswers(sec) - m_database->getNumOfTotalAnswers(sec)) * 0.8
			+ m_database->getPlayerAverageAnswerTime(sec) * 0.15 + m_database->getNumOfPlayerGames(sec);
	}catch(...){}
	return one < two;
}

std::vector<std::string> StatisticsManager::sort(std::vector<std::string> arr)
{
	for (int i = 0; i < arr.size(); i++)
	{
		for (int j = 0; j < arr.size() - i - 1; j++)
		{
			if (isBetter(arr[j], arr[i]))
			{//1 2 3 4 5
				std::string temp = arr[j];
				arr[j] = arr[j + 1];
				arr[j + 1] = temp;
			}
		}
	}
	return arr;
}

StatisticsManager::StatisticsManager(IDatabase* db)
{
	m_database = db;
}

std::vector<std::string> StatisticsManager::getStatistics(std::string myPlayer)
{//return value-> num,num,num,num;player1,player2,player3,player4,player5
 //     TotalGames|TotalQ|CorQ|AVGtime  ||The best 5 players||
	std::vector<std::string> statist;
	if (!m_database->doesUserExist(myPlayer))
		throw std::invalid_argument("Player is not Exists");
	statist.push_back((std::to_string(m_database->getNumOfPlayerGames(myPlayer)) + ","
	+ std::to_string(m_database->getNumOfTotalAnswers(myPlayer)) + ","
	+ std::to_string(m_database->getNumOfCorrectAnswers(myPlayer)) + ","
	+ std::to_string(m_database->getPlayerAverageAnswerTime(myPlayer))).substr(0, statist.size() - 1));

	std::vector<std::string> usersName = m_database->getUserNames();
	sort(usersName);//sort this to loser to winner
	statist.push_back("");
	for (size_t i = 0; i < 5 && i < usersName.size(); i++)//get the first 5 
		statist[1] = statist[1] + usersName[i] + ",";
	statist[1] = statist[1].substr(0, statist[1].size() - 1);
	return statist;
}