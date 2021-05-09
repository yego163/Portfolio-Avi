#include "LoggedUser.h"

LoggedUser::LoggedUser()
{
	m_username = "";
}

LoggedUser::LoggedUser(std::string name)
{
	m_username = name;
}

void LoggedUser::setUserName(std::string name)
{
	m_username = name;
}

const std::string LoggedUser::getUserName() const
{
	return m_username;
}

bool LoggedUser::operator==(const LoggedUser other)
{
	return this->m_username == other.m_username;
}

bool operator<(const LoggedUser& lhs, const LoggedUser& rhs)
{
	return lhs.getUserName() < rhs.getUserName();
}
