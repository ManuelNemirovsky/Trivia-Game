#pragma once

#include <string>
#include <Windows.h>
#include "User.h"
using namespace std;

class RecievedMessage
{
private:
	SOCKET _sock;
	User* _user;

	int _messageCode;
//	string _messageContent;
	vector<string> _values;
public:
	RecievedMessage(SOCKET sock, int messageCode)
	{
		_sock = sock;
		_messageCode = messageCode;
		_user = nullptr;
	}
	
	RecievedMessage(SOCKET sock, int messageCode, vector<string> values) : RecievedMessage(sock, messageCode)
	{
		_values = values;
	}

	SOCKET getSock() { return _sock; }
	User* getUser() { return _user; }
	void setUser(User* user) { _user = user; }
	int getMessageCode() { return _messageCode; }
	//string getMessageContent() { return _messageContent; }
	vector<string>& getValues()
	{
		return _values;
	}

};