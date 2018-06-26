

#pragma once

#include <string>
#include <vector>
#include "Helper.h"
#include "sqlite3.h"
#include "Question.h"
using namespace std;

class DataBase
{
private:
	sqlite3* _sqlite;

	static int callbackCount(void* notUsed, int argc, char** argv, char** azCol)
	{
		int*  res = (int*)notUsed;
		*res = atoi(argv[0]);

		return 0;

	}


	static int callbackQuestions(void* notUsed, int argc, char** argv, char** azCol)
	{
		vector<Question*>*  res = (vector<Question*>*)notUsed;

		Question* currQuest;

		currQuest = new Question(atoi(argv[0]), argv[1], argv[2], argv[3], argv[4], argv[5]);
		res->push_back(currQuest);

		return 0;

	}

	static int callbackBestScores(void* notUsed, int argc, char** argv, char** azCol)
	{
		vector<std::string>* res = (vector<std::string>*)notUsed;

		std::string username = argv[0];
		int count = atoi(argv[1]);

		std::string s = Helper::getPaddedNumber(username.length(), 2) + username + Helper::getPaddedNumber(count, 6);
		res->push_back(s);

		return 0;
	}

	static int callbackPersonalStatus(void* notUsed, int argc, char** argv, char** azCol)
	{
		vector<std::string>* res = (vector<std::string>*)notUsed;

		// if user has no data
		string s1 = argv[0];
		if (s1 == "0")
		{
			res->push_back("0"); // total games
			res->push_back("0"); // correct answers
			res->push_back("0"); // wrongs answers
			res->push_back("0"); // average answer time

		}
		else
		{
			res->push_back(argv[0]); // total games
			res->push_back(argv[1]); // correct answers
			res->push_back(argv[2]); // wrongs answers

			string avg = argv[3];

			char buffer[50];
			sprintf(buffer, "%.2f", atof(avg.c_str()));

			int i = atoi(buffer);
			string s = "";
			if (i < 10)
			{
				s = "0";
				s += buffer[0];
				s += buffer[2];
				s += buffer[3];
			}
			else
			{
				s = buffer[0];
				s += buffer[1];
				s += buffer[3];
				s += buffer[4];
			}
			

			

			res->push_back(s); // average answer time
		}
		return 0;
	}
public:
	DataBase()
	{
		sqlite3_open("trivia.db", &_sqlite);

		// should check if succeeded
	}

	~DataBase()
	{
		sqlite3_close(_sqlite);
		_sqlite = nullptr;

	}

	bool isUserExists(string username)
	{
		std::string sql = "select count(*) from t_users where username = \'" + username + "\'";
		int res = 0;

		char *zErrMsg = 0;
		int m = sqlite3_exec(_sqlite, sql.c_str(), callbackCount, &res, &zErrMsg);

		if (m != SQLITE_OK)
		{
			TRACE("DB::isUserExists failed:  err_msg=%s, sql=%s", zErrMsg, sql.c_str());
			sqlite3_free(zErrMsg);
			return false;
		}
		return res != 0;
	}

	bool addNewUser(string username, string password, string email)
	{
		std::string sql = "insert into t_users (username, password, email) values(\'" + username + "\', \'" + password + "\', \'" + email + "\')";
		char *zErrMsg = 0;
		int m = sqlite3_exec(_sqlite, sql.c_str(), nullptr, nullptr, &zErrMsg);

		if (m != SQLITE_OK)
		{
			TRACE("DB::addNewUser failed:  err_msg=%s, sql=%s", zErrMsg, sql.c_str());
			sqlite3_free(zErrMsg);
			return false;
		}

		return true;
	}

	bool isUserAndPassMatch(string username, string password)
	{
		std::string sql = "select count(*) from t_users where username = \'" + username + "\' and password = \'" + password + "\'";
		int res = 0;

		char *zErrMsg = 0;
		int m = sqlite3_exec(_sqlite, sql.c_str(), callbackCount, &res, &zErrMsg);

		if (m != SQLITE_OK)
		{
			TRACE("DB::isUserAndPassMatch failed:  err_msg=%s, sql=%s", zErrMsg, sql.c_str());
			sqlite3_free(zErrMsg);
			return false;
		}


		return res == 1;
	}

	vector<Question*> initQuestions(int questionsNo)
	{
		std::string sql = "select question_id, question, correct_ans, ans2, ans3, ans4 from t_questions order by random() limit " + to_string(questionsNo);

		vector<Question*> res;

		char *zErrMsg = 0;
		int m = sqlite3_exec(_sqlite, sql.c_str(), callbackQuestions, &res, &zErrMsg);

		if (m != SQLITE_OK)
		{
			TRACE("DB::initQuestions failed:  err_msg=%s, sql=%s", zErrMsg, sql.c_str());
			sqlite3_free(zErrMsg);
		}


		return res;
	}

	vector<string> getBestScores()
	{
		std::string sql = "select username, sum(is_correct) as ans from t_players_answers group by username order by ans DESC limit 3";

		vector<std::string> res;

		char *zErrMsg = 0;
		int m = sqlite3_exec(_sqlite, sql.c_str(), callbackBestScores, &res, &zErrMsg);

		if (m != SQLITE_OK)
		{
			TRACE("DB::getBestScores failed:  err_msg=%s, sql=%s", zErrMsg, sql.c_str());
			sqlite3_free(zErrMsg);
		}


		return res;
	}

	vector<string> getPersonalStatus(string username)
	{
		std::string sql = "select  count(distinct game_id), sum(is_correct) as  correct, count(*) - sum(is_correct), avg(answer_time) from t_players_answers where username = '" + username + "'";

		vector<std::string> res;

		char *zErrMsg = 0;
		int m = sqlite3_exec(_sqlite, sql.c_str(), callbackPersonalStatus, &res, &zErrMsg);

		if (m != SQLITE_OK)
		{
			TRACE("DB::getPersonalStatus failed:  err_msg=%s, sql=%s", zErrMsg, sql.c_str());
			sqlite3_free(zErrMsg);
		}


		return res;
	}
	int insertNewGame()
	{
		std::string sql = "insert into t_games (status, start_time) values(0, DATETIME(\'now\'))";
		char *zErrMsg = 0;
		int m = sqlite3_exec(_sqlite, sql.c_str(), nullptr, nullptr, &zErrMsg);

		if (m != SQLITE_OK)
		{
			TRACE("DB::insertNewGame failed:  err_msg=%s, sql=%s", zErrMsg, sql.c_str());
			sqlite3_free(zErrMsg);
			return -1;
		}

		sql = "select last_insert_rowid()";
		int res = 0;

		m = sqlite3_exec(_sqlite, sql.c_str(), callbackCount, &res, &zErrMsg);

		if (m != SQLITE_OK)
		{
			TRACE("DB::insertNewGame failed:  err_msg=%s, sql=%s", zErrMsg, sql.c_str());
			sqlite3_free(zErrMsg);
			return -1;
		}

		return res;
	}

	bool updateGameStatus(int id)
	{
		std::string sql = "update t_games set status=1, end_time=DATETIME(\'now\') where game_id = " + to_string(id);
		char *zErrMsg = 0;
		int m = sqlite3_exec(_sqlite, sql.c_str(), nullptr, nullptr, &zErrMsg);

		if (m != SQLITE_OK)
		{
			TRACE("DB::updateGameStatus failed:  err_msg=%s, sql=%s", zErrMsg, sql.c_str());
			sqlite3_free(zErrMsg);
			return false;
		}

		return true;
	}

	bool addAnwerToPlayer(int gameId, string username, int questionId, string answer, bool isCorrect, int answerTime)
	{
		std::string sql = "insert into t_players_answers (game_id, username, question_id, player_answer, is_correct, answer_time) values(" + to_string(gameId) + ", \'" + username + "\', " + to_string(questionId) +
			", \'" + answer + "\', " + to_string(isCorrect ? 1 : 0) + ", " + to_string(answerTime) + ")";

		char *zErrMsg = 0;
		int m = sqlite3_exec(_sqlite, sql.c_str(), nullptr, nullptr, &zErrMsg);

		if (m != SQLITE_OK)
		{
			TRACE("DB::addAnwerToPlayer failed:  err_msg=%s, sql=%s", zErrMsg, sql.c_str());
			sqlite3_free(zErrMsg);
			return false;
		}

		return true;

	}
};

