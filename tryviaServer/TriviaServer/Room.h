#pragma once

#include <vector>

#include "User.h"
#include "Protocol.h"
#include "Helper.h"
#include <iomanip>
#include <mutex>

class User;

class Room
{
private:
	std::vector<User*> _users;
	User* _admin;
	int _maxUsers;
	int _questionTime;
	int _questionsNo;
	string _name;
	int _id;


	string getUsersAsString(vector<User*> usersList, User* excludeUser);
	void sendMessage(string message);
	void sendMessage(User* excludeUser, string message);


public:
	Room(int id, User* admin, string name, int maxUsers, int questionsNo, int quiestionTime);
	bool joinRoom(User* user);
	void leaveRoom(User* user);
	int closeRoom(User* user);
	vector<User*> getUsers();
	string getUsersListMessage();
	int getQuestionsNo();
	
	int getId();
	string getName();

};