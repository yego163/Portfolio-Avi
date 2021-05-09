#pragma once
#include <iostream>
#include <vector>
#include <algorithm>
class Question
{
public:
	Question();
	Question(std::string question, std::vector<std::string> answers, int correctone);
	std::string m_question;
	std::vector<std::string> m_possivleAnswers;
	int num_correctAnswer;
	std::string getQuestion();
	std::vector<std::string> getPossibleAnswers();
	std::string getCorrectAnswer();
};

