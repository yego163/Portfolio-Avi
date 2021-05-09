#pragma once
#include <iostream>

class RoomData
{
	unsigned int _id;
	std::string _name;
	unsigned int _maxPlayers;
	unsigned int _timePerQuestion;
	unsigned int _questionCount;
	bool _isActive;
public:
	bool operator==(RoomData& other);
	RoomData(int id, std::string name, unsigned int maxPlayers, unsigned int questionCount, unsigned int timePerQuestion, bool Active);
	int getId();
	std::string getName();
	int getMaxPlayers();
	int getTimePerQuestion();
	bool getIsActive();
	int getQuestionCount();
	void setIsActive(bool active);
};