#pragma once

#include <string>
#include <time.h>

class Question
{
private:
	std::string _question;
	std::string _answers[4];
	int _correctAnswerIndex;
	int _id;

public:
	Question(int id,  std::string question, std::string correctAnswer, std::string answer2, std::string answer3, std::string answer4)
	{
		
		_id = id;
		_question = question;

		
		_correctAnswerIndex = rand() % 4;
		_answers[_correctAnswerIndex] = correctAnswer;

		// rand the second answer index
		int firstIndex = rand() % 4;
		while (firstIndex == _correctAnswerIndex)
		{
			firstIndex = rand() % 4;
		}
		_answers[firstIndex] = answer2;

		// rand the third answer index
		int secondIndex = rand() % 4;
		while (secondIndex == _correctAnswerIndex || secondIndex == firstIndex)
		{
			secondIndex = rand() % 4;
		}
		_answers[secondIndex] = answer3;


		int thirdIndex = 6 - _correctAnswerIndex - firstIndex - secondIndex;
		_answers[thirdIndex] = answer4;
	}
	
	std::string getQuestion()
	{
		return _question;
	}

	std::string* getAnswers()
	{
		return _answers;
	}

	int getCorrectAnswerIndex()
	{
		return _correctAnswerIndex;
	}

	int getId()
	{
		return _id;
	}
};