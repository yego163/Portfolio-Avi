#pragma once
#include <iostream>
#include "IDatabase.h"	
class LoggedUser
{
private:
	std::string m_username;
public:
	LoggedUser();
	LoggedUser(std::string name);
	void setUserName(std::string name);
	const std::string getUserName() const;
	bool operator==(const LoggedUser other);
	friend bool operator<(const LoggedUser& lhs, const LoggedUser& rhs);
};

