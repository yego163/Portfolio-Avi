#pragma once
#include <iostream>
#include "LoggedUser.h"
#include <vector>
#include "IDatabase.h"
#include "SqliteDatabase.h"
#include <algorithm>

class LoginManager
{
private:
	IDatabase* m_database;
	std::vector<LoggedUser> m_loggedUsers;
public:
	LoginManager(IDatabase* db);
	~LoginManager();
	void signup(std::string user, std::string pass, std::string email);
	void login(std::string user, std::string pass);
	void logout(std::string user);
	std::vector<LoggedUser> getLoggedUsers();
};

