#pragma once

#include <vector>
#include "User.h"
#include <map>
#include "Question.h"
#include <string>
#include "DataBase.h"

class User;

class Game
{
private:
	std::vector<Question*> _questions;
	std::vector<User*> _players;
	int _questionsNo;
	int _currQuestionIndex;
	int _id;
	DataBase& _db;
	std::map<std::string, int> _results;
	int _currentTurnAnswers; // the number of player that answer to the question in the current turn (so we know then to move to the next question)

	bool insertGameToDB();
	void initQuestionsFromDB();
	void sendQuestionToAllUsers();

public:

	// throw exception if didnt success
	Game(const std::vector<User*>& players, int questionsNo, DataBase& db);

	void sendFirstQuestion();
	void handleFinishGame();
	bool handleNextTurn();
	bool handleAnswerFromUser(User* user, int answerIndex, int time);	
	bool leaveGame(User*);
	int getID();
	~Game();

};
