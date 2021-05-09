#include "RoomData.h"

bool RoomData::operator==(RoomData& other)
{
	return _id==other.getId();
}

RoomData::RoomData(int id, std::string name, unsigned int maxPlayers, unsigned int questionCount, unsigned int timePerQuestion, bool active)
{
	_id = id;
	_name = name;
	_maxPlayers = maxPlayers;
	_timePerQuestion = timePerQuestion;
	_questionCount = questionCount;
	_isActive = active;
}

int RoomData::getId()
{
	return _id;
}

std::string RoomData::getName()
{
	return _name;
}

int RoomData::getMaxPlayers()
{
	return _maxPlayers;
}

int RoomData::getTimePerQuestion()
{
	return _timePerQuestion;
}

bool RoomData::getIsActive()
{
	return _isActive;
}

int RoomData::getQuestionCount()
{
	return _questionCount;
}

void RoomData::setIsActive(const bool active)
{
	_isActive = active;
}

