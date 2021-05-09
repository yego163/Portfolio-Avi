#pragma once
#include <stdio.h>
#include <string>
#include "IDatabase.h"
#include "sqlite3.h"
#include <iostream>
#include <io.h>
#include <algorithm>
#include <list>
#include "SignupRequest.h"
#include "Question.h"
#include "tools.h"
#include <stdlib.h>
#include <time.h>
#include <iterator>
#include <random>
#include <chrono>
#include <thread>

class SqliteDatabase :
	public IDatabase
{
private:
	sqlite3* db;
	bool createTables();
	std::default_random_engine rng;
	void insertStartQuestions();
	bool command(std::string command, int callback(void* data, int argc, char** argv, char** azColName), void* data);
	bool command(std::string command);
public:
	SqliteDatabase();
	~SqliteDatabase();
	virtual bool doesUserExist(std::string userName);
	virtual bool doesPasswordMatch(std::string userName, std::string password);
	virtual void addNewUser(std::string userName, std::string password, std::string email);
	//2.0.0
	virtual std::list<Question> getQuestion(int number);
	virtual float getPlayerAverageAnswerTime(std::string player);
	virtual int getNumOfCorrectAnswers(std::string player);
	virtual int getNumOfTotalAnswers(std::string player);
	virtual int getNumOfPlayerGames(std::string player);
	virtual std::vector<std::string> getUserNames();
	//4.0.0
	virtual void setNewStatistics(int QuestionsTotal, int CorrectTotal, float AVG_Time, std::string username);
};

int getNumbers(void* data, int argc, char** argv, char** azColName);
int getQuestions(void* data, int argc, char** argv, char** azColName);
int getUsers(void* data, int argc, char** argv, char** azColName);