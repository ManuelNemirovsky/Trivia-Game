#pragma once

#include <thread>
#include <map>
#include <mutex>
#include <WinSock2.h>
#include <Windows.h>
#include <condition_variable>
#include "User.h"
#include "DataBase.h"

#include <queue>
#include "RecivedMessage.h"

using namespace std;


class TriviaServer
{
public:
	TriviaServer();
	~TriviaServer();
	void serve();


private:

	void bindAndListen();
	void accept();
	void clientHandler(SOCKET client_socket);
	void safeDeleteUser(RecievedMessage*);


	SOCKET _socket;


	User* handleSignin(RecievedMessage*);
	bool handleSignup(RecievedMessage* msg);
	void handleSignout(RecievedMessage* msg);


	void handleLeaveGame(RecievedMessage*);
	void handleStartGame(RecievedMessage* msg);
	void handlePlayerAnswer(RecievedMessage* msg);
	bool handleCreateRoom(RecievedMessage* );
	bool handleCloseRoom(RecievedMessage* );
	bool handleJoinRoom(RecievedMessage* );
	bool handleLeaveRoom(RecievedMessage*);
	void handleGetUsersInRoom(RecievedMessage* );
	void handleGetRooms(RecievedMessage* );

	void handleGetBestScores(RecievedMessage*);
	void handleGetPersonalStatus(RecievedMessage*);

	map<SOCKET, User*> _connectedUsers;
	DataBase _db;

	static int _roomIdSequence ;
	map<int, Room*> _roomsList;

	User* getUserByName(string userName);
	User* getUserBySocket(SOCKET client_socket);
	Room* getRoomById(int roomId);
	void handleRecievedMessages();
	void addRecievedMessage(RecievedMessage* msg);
	RecievedMessage* buildRecieveMessage(SOCKET userSock, int msgCode);

	mutex _mtxRecievedMessages;
	queue<RecievedMessage*> _queRcvMessages;
	
	std::condition_variable cvQueue;
};

