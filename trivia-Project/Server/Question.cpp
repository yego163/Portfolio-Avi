#include "Question.h"

Question::Question()
{
}

Question::Question(std::string question, std::vector<std::string> answers, int correctone)
{
	m_question = question;
	m_possivleAnswers = std::vector<std::string>(answers);
	num_correctAnswer = correctone;
}
std::string Question::getQuestion()
{
	return m_question;
}

std::vector<std::string> Question::getPossibleAnswers()
{
	return m_possivleAnswers;
}

std::string Question::getCorrectAnswer()
{
	return m_possivleAnswers[num_correctAnswer];
}