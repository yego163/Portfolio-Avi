#pragma once
#include <iostream>
#include <list>
#include <vector>
#include "Question.h"

class IDatabase {
public:
	//1.0.0
	virtual bool doesUserExist(std::string userName) = 0;
	virtual bool doesPasswordMatch(std::string userName, std::string password) = 0;
	virtual void addNewUser(std::string userName, std::string password, std::string email) = 0;
	//2.0.0
	virtual std::list<Question> getQuestion(int number) = 0;
	virtual float getPlayerAverageAnswerTime(std::string player) = 0;
	virtual int getNumOfCorrectAnswers(std::string player) = 0;
	virtual int getNumOfTotalAnswers(std::string player) = 0;
	virtual int getNumOfPlayerGames(std::string player) = 0;
	virtual std::vector<std::string> getUserNames() = 0;
	//4.0.0
	virtual void setNewStatistics(int QuestionsTotal, int CorrectTotal, float AVG_Time, std::string username) = 0;
};