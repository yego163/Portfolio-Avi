#pragma once
#include "Question.h"

struct GameData {
	Question correntQuestion;
	unsigned int correctAnswerCount;
	unsigned int wrongAnswerCount;
	unsigned int averangeAnswerTime;
};