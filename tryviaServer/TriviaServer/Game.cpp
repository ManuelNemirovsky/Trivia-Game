#include "Game.h"
Game::Game(const vector<User*>& players, int questionsNo, DataBase& db) : _db(db)
{
	_currQuestionIndex = 0;
	_questionsNo = questionsNo;

	if (!insertGameToDB())
	{
		throw exception("Insert new game into db failed");
	}

	initQuestionsFromDB();

	int i;
	for (i = 0; i < players.size(); ++i)
	{
		_players.push_back(players[i]);
		pair<string, int> p(players[i]->getUsername(), 0);
		_results.insert(p);

		_players[i]->setGame(this);
	}
}

void Game::sendQuestionToAllUsers()
{
	vector<User*>::iterator it;
	User* currUser;

	string qst = _questions[_currQuestionIndex]->getQuestion();
	string msg = SRV_MSG_GAME_QUESTION + Helper::getPaddedNumber(qst.length(), 3) + qst;

	string* ans = _questions[_currQuestionIndex]->getAnswers();
	msg += Helper::getPaddedNumber(ans[0].length(), 3) + ans[0];
	msg += Helper::getPaddedNumber(ans[1].length(), 3) + ans[1];
	msg += Helper::getPaddedNumber(ans[2].length(), 3) + ans[2];
	msg += Helper::getPaddedNumber(ans[3].length(), 3) + ans[3];

	_currentTurnAnswers = 0;

	TRACE("sending question to all players (%d/%d)", _currQuestionIndex + 1, _questions.size());
	for (it = _players.begin(); it != _players.end(); it++)
	{
		currUser = *it;

		// send question to player
		try
		{
			currUser->send(msg);
		}
		catch (...)
		{
			TRACE("Sending Error (Game::sendQuestionToAllUsers): cant send message to %s", currUser->getUsername().c_str());
		}
	}
}
void Game::handleFinishGame()
{
	_db.updateGameStatus(this->_id);

	// no players left
	if (_players.size() == 0)
		return;

	string msg = SRV_MSG_GAME_FINISH + Helper::getPaddedNumber(_results.size(), 1);

	map<string, int>::iterator it;
	for (it = _results.begin(); it != _results.end(); it++)
	{
		msg += Helper::getPaddedNumber(it->first.length(), 2) + it->first + Helper::getPaddedNumber(it->second, 2);
	}

	TRACE("Send finish game to all players");
	for (int i = 0; i < _players.size(); ++i)
	{
		try
		{
			_players[i]->setGame(nullptr);
			_players[i]->send(msg);
		}
		catch (...)
		{
			TRACE("Sending Error (Game::handleFinishGame): cant send message to %s", _players[i]->getUsername().c_str());
		}
	}

}


bool Game::insertGameToDB()
{
	// insert record to DB
	_id = _db.insertNewGame();
	
	return _id != -1;
}

void Game::initQuestionsFromDB()
{
	_questions  = _db.initQuestions(_questionsNo);

}

// return true if game still on
// false - if game ended
bool Game::leaveGame(User* currUser)
{
	vector<User*>::iterator it= std::find(_players.begin(), _players.end(), currUser);
	if (it != _players.end())
	{
		_players.erase(it);
		
		// if game finished
		return handleNextTurn();
	}

	return true;
}

int Game::getID()
{
	return _id;
}
bool Game::handleNextTurn()
{
	if (_players.size() == 0)
	{
		handleFinishGame();
		return false;
	}

	if (_currentTurnAnswers == _players.size())
	{
		if (_questions.size() - 1 == _currQuestionIndex)
		{
			// Game Over
			handleFinishGame();
			return false;
		}
		else
		{
			// Next question
			_currQuestionIndex++;
			sendQuestionToAllUsers();
		}
	}

	return true;
}

// return true if game still on
// false - if game ended
bool Game::handleAnswerFromUser(User* user, int answerNo, int time)
{
	_currentTurnAnswers++;

	string result = "0";
	bool res = false;
	int correctAns = _questions[_currQuestionIndex]->getCorrectAnswerIndex();

	TRACE("AnswerNo=%d, time=%d, CorrectAnswer=%d", answerNo, time, correctAns + 1);

	if (answerNo - 1 == correctAns)
	{
		result = "1";
		res = true;
		_results[user->getUsername()] ++;
	}


	string ans = "";
	
	// if answer=5 it means the user didnt answer within the time
	if (answerNo <= 4)
		ans = _questions[_currQuestionIndex]->getAnswers()[answerNo - 1];
	

	_db.addAnwerToPlayer(_id, user->getUsername(), _questions[_currQuestionIndex]->getId(), ans , res, time);

	// send indication to user
	TRACE("Sending answer indiction to user.");
	TRACE("CurrentPlayersNo=%d, CurrentQuestionIndex=%d, TotalQuestionsNo=%d, CurrentTurnAnswres=%d", _players.size(), _currQuestionIndex, _questions.size(), _currentTurnAnswers);
	user->send(SRV_MSG_GAME_ANSWER_IND + result);

	return handleNextTurn();
}

void Game::sendFirstQuestion()
{
	sendQuestionToAllUsers();
}

Game::~Game()
{
	vector<Question*>::iterator it;

	for (it = _questions.begin(); it != _questions.end(); it++)
	{
		delete *it;
	}

	_questions.clear();
	_players.clear();
}
