#include "User.h"

User::User(string username, SOCKET sock) : _username(username), _sock(sock)
{
	_currRoom = nullptr;
	_currGame = nullptr;

}

void User::send(string message)
{
	Helper::sendData(_sock, message);
	TRACE("Message sent to user: %s, msg: %s", _username.c_str(), message.c_str());
}

string User::getUsername()
{
	return _username;
}

SOCKET User::getSocket()
{
	return _sock;
}

Room* User::getRoom()
{
	return _currRoom;
}

Game* User::getGame()
{
	return _currGame;
}

void User::setGame(Game* gm)
{
	_currRoom = nullptr;
	_currGame = gm;
}

bool User::createRoom(int roomId, string roomName, int maxUsers, int questionsNo, int quiestionTime)
{
	// cant create room if the user in room
	if (_currRoom)
	{
		this->send(SRV_MSG_CREATE_ROOM_FAILED);
		return false;
	}
	
	_currRoom = new Room(roomId, this, roomName, maxUsers, questionsNo, quiestionTime);
	this->send(SRV_MSG_CREATE_ROOM_SUCCESS);

	return true;
}

bool User::joinRoom(Room* newRoom)
{
	// cant join room if the user in room
	if (_currRoom)
		return false;

	
	bool res = newRoom->joinRoom(this);

	if (res)
		_currRoom = newRoom;

	return res;
}


bool User::leaveGame()
{
	if (!_currGame)
		return false;

	TRACE("User left game:  userName=%s, gameId=%d", _username.c_str(), _currGame->getID());
	bool res = _currGame->leaveGame(this);
	this->_currGame = nullptr;

	return res;
}

void User::leaveRoom()
{
	// if not in room
	if (!_currRoom)
		return;

	_currRoom->leaveRoom(this);
	_currRoom = nullptr;
}

// return the id of the room
// if failed return -1
int User::closeRoom()
{
	// if not in room
	if (!_currRoom)
		return -1;

	int res = _currRoom->closeRoom(this);
	if (res != -1)
	{
		delete _currRoom;
		_currRoom = nullptr;
	}

	return res;
}

void User::clearRoom()
{
	_currRoom = nullptr;
}

