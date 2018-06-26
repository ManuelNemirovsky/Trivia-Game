#pragma once

#include <string>
#include "Room.h"
#include "Game.h"
#include "Helper.h"
#include <Windows.h>

using namespace std;

class Room;
class Game;

class User
{
private:
	string _username;
	Room* _currRoom; 
	Game* _currGame;
	SOCKET _sock;

public:
	User(string username, SOCKET sock);
	void send(string message);
	
	string getUsername();
	SOCKET getSocket();
	Room* getRoom();
	Game* getGame();
	void setGame(Game*);
	void clearRoom();

	bool createRoom(int roomId, string roomName, int maxUsers, int questionsNo, int quiestionTime);
	bool joinRoom(Room* newRoom);
	void leaveRoom();
	int closeRoom();

	bool leaveGame();
};