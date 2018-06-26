#define _CRT_SECURE_NO_WARNINGS
#include "Room.h"
#include <iostream>

using namespace std;

Room::Room(int id, User* admin, string name, int maxUsers, int questionsNo, int quiestionTime)
{
	_id = id;
	_name = name;
	_maxUsers = maxUsers;
	_questionsNo = questionsNo;
	_questionTime = quiestionTime;
	_admin = admin;

	_users.push_back(admin);

}


string Room::getUsersAsString(vector<User*> usersList, User* excludeUser)
{
	vector<User*>::iterator it;
	User* tmp = nullptr;
	string res = "";
	for (it = usersList.begin(); it != usersList.end(); it++)
	{
		tmp = *it;

		if (tmp != excludeUser)
			res += "[" + tmp->getUsername() + "]";
	}

	return res;

}


string Room::getUsersListMessage()
{
	User* tmp;
	vector<User*>::iterator it;
	string res = "";
	string currUsername;
	
	

	for (it = _users.begin(); it != _users.end(); it++)
	{
		tmp = *it;

		currUsername = tmp->getUsername();
		res += Helper::getPaddedNumber(currUsername.size(), 2) + currUsername;
	}

	string msg = SRV_MSG_USERS_IN_ROOM + Helper::getPaddedNumber(_users.size(), 1) + res;
	
	return msg;
}

void Room::sendMessage(string message)
{
	sendMessage(nullptr, message);
}

void Room::sendMessage(User* excludeUser, string message)
{
	vector<User*>::iterator it;
	User* tmp = nullptr;

	try
	{

		TRACE("SEND: Room sending message to %d users (%s): message = %s", _users.size(), getUsersAsString(_users, excludeUser).c_str(), message.c_str());

		for (it = _users.begin(); it != _users.end(); it++)
		{
			tmp = *it;

			if (tmp != excludeUser)
			{
				tmp->send(message);
			}
		}
	}

	catch (exception e)
	{
		// if send failed not throw the exception because it not sure that the error came from the same user thread 
		// (becuase it is spread message)
		std::cout << "Sending Error (Room::sendMessage): cant send message to " << tmp->getUsername() << std::endl;
	}
}



string Room::getName()
{
	return _name;
}

int Room::getId()
{
	return _id;
}

bool Room::joinRoom(User* user)
{
	// room is full
	if (_users.size() == _maxUsers)
	{
		user->send(SRV_MSG_JOIN_ROOM_FULL);
		return false;
	}

	_users.push_back(user);

	// send success message to the new user
	string m = SRV_MSG_JOIN_ROOM_SUCCESS + Helper::getPaddedNumber(this->_questionsNo, 2) + Helper::getPaddedNumber(this->_questionTime, 2);
	user->send(m);

	// send the users list message to all the users in the room
	sendMessage(getUsersListMessage());

	return true;
}

void Room::leaveRoom(User* user)
{
	bool flag = false;
	vector<User*>::iterator it;

	for (it = _users.begin(); it != _users.end() && !flag; it++)
	{
		if (*it == user)
			flag = true;

	}

	if (flag)
	{
		--it;
		_users.erase(it);
	}

	TRACE("User has left room: roomId=%d, roomName=%s, user=%s", _id, _name.c_str(), user->getUsername().c_str());

	// send success message to the user that left
	user->send(SRV_MSG_LEAVE_ROOM_SUCCESS);
	
	// send the users list message to all the users in the room
	sendMessage(getUsersListMessage());

}

// return the id of the room
// if failed return -1
int Room::closeRoom(User* user)
{
	// only admin can close the room
	if (_admin != user)
		return -1;

	// send closing message to all the users in the room
	sendMessage(SRV_MSG_CLOSE_ROOM);
	
	// set the room of the users (exept the admin) to be null
	for (int i = 0; i < _users.size(); ++i)
	{
		if (_users[i] != _admin)
			_users[i]->clearRoom();
	}

	_users.clear();

	return _id;
}

vector<User*> Room::getUsers()
{
	return _users;
}

int Room::getQuestionsNo()
{
	return _questionsNo;
}
