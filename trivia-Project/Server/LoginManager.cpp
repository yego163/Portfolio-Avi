#include "LoginManager.h"

LoginManager::LoginManager(IDatabase* db)
{
	m_database = db;
}

LoginManager::~LoginManager()
{
}

void LoginManager::signup(std::string user, std::string pass, std::string email)
{
	if (m_database->doesUserExist(user))
		throw std::invalid_argument("User already exist");
	m_database->addNewUser(user, pass, email);
	LoggedUser temp(user);
	for (std::vector<LoggedUser>::iterator it = m_loggedUsers.begin(); it != m_loggedUsers.end(); it++)
		if (it->getUserName() == user)
			throw std::invalid_argument("User is already online");
	m_loggedUsers.push_back(LoggedUser(user));
}

void LoginManager::login(std::string user, std::string pass)
{
	if (!m_database->doesPasswordMatch(user, pass))
		throw std::invalid_argument("Password doesn't match");
	LoggedUser temp(user);
	for (std::vector<LoggedUser>::iterator it = m_loggedUsers.begin(); it != m_loggedUsers.end(); it++)
		if (it->getUserName() == user)
			throw std::invalid_argument("User is already online");
	m_loggedUsers.push_back(LoggedUser(user));
}

void LoginManager::logout(std::string user)
{
	try {
		m_loggedUsers.erase(std::remove_if(m_loggedUsers.begin(), m_loggedUsers.end(), [&user](const LoggedUser& ele)->bool//remove the user
		{
			return ele.getUserName() == user;
		}), m_loggedUsers.end());
	}
	catch (...) {
		throw std::invalid_argument(user + " is offline!");
	}
}

std::vector<LoggedUser> LoginManager::getLoggedUsers()
{
	return m_loggedUsers;
}
