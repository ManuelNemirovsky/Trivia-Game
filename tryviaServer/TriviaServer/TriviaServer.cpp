#include "TriviaServer.h"
#include "User.h"
#include "Protocol.h"
#include "Validator.h"
#include "Game.h"
#include <exception>
#include <iostream>
#include <string>

// using static const instead of macros 
static const unsigned short PORT = 8820;
static const unsigned int IFACE = 0;

int TriviaServer::_roomIdSequence = 1;

TriviaServer::TriviaServer() : _db()
{
	
	WSADATA wsa_data = {};
	if (WSAStartup(MAKEWORD(2, 2), &wsa_data) != 0)
		throw std::exception("WSAStartup Failed");


	// notice that we step out to the global namespace
	// for the resolution of the function socket
	_socket = ::socket(AF_INET, SOCK_STREAM, IPPROTO_TCP);
	if (_socket == INVALID_SOCKET)
		throw std::exception(__FUNCTION__ " - socket");
}

TriviaServer::~TriviaServer()
{
	TRACE(__FUNCTION__ " closing server");

	try
	{
		for (map<int, Room*>::iterator it = _roomsList.begin(); it != _roomsList.end(); it++)
		{
			delete it->second;
		}
		_roomsList.clear();

		// delete the users
		for (map<SOCKET, User*>::iterator it = _connectedUsers.begin(); it != _connectedUsers.end(); it++)
		{
			// free the memory of the user
			delete it->second;
		}
		_connectedUsers.clear();
		
		::closesocket(_socket);
		WSACleanup();

	}
	catch (...) {}


}

void TriviaServer::serve()
{
	bindAndListen();

	// create new thread for handling message
	std::thread tr(&TriviaServer::handleRecievedMessages, this);
	tr.detach();

	while (true)
	{
		// the main thread is only accepting clients 
		// and add then to the list of handlers
		TRACE("accepting client...");
		accept();
	}
}


// listen to connecting requests from clients
// accept them, and create thread for each client
void TriviaServer::bindAndListen()
{
	struct sockaddr_in sa = { 0 };
	sa.sin_port = htons(PORT);
	sa.sin_family = AF_INET;
	sa.sin_addr.s_addr = IFACE;
	// again stepping out to the global namespace
	if (::bind(_socket, (struct sockaddr*)&sa, sizeof(sa)) == SOCKET_ERROR)
		throw std::exception(__FUNCTION__ " - bind");
	TRACE("binded");

	if (::listen(_socket, SOMAXCONN) == SOCKET_ERROR)
		throw std::exception(__FUNCTION__ " - listen");
	TRACE("listening (Port = %d)...", PORT);
}

void TriviaServer::accept()
{
	SOCKET client_socket = ::accept(_socket, NULL, NULL);
	if (client_socket == INVALID_SOCKET)
		throw std::exception(__FUNCTION__);

	TRACE("Client accepted. Client socket = %d", client_socket);
	// create new thread for client	and detach from it
	std::thread tr(&TriviaServer::clientHandler, this, client_socket);
	tr.detach();

}

User* TriviaServer::getUserByName(string userName)
{
	map<SOCKET, User*>::iterator userIter;;

	for (userIter = _connectedUsers.begin(); userIter != _connectedUsers.end(); userIter++)
	{
		if (userIter->second->getUsername() == userName)
			return userIter->second;
	}

	return nullptr;
}


User* TriviaServer::getUserBySocket(SOCKET client_socket)
{
	map<SOCKET, User*>::iterator userIter = _connectedUsers.find(client_socket);

	if (userIter == _connectedUsers.end())
	{
		return nullptr;
	}

	return userIter->second;
}


// Msg Code: 200
// if connected successfuly return user object
// if not return null
User* TriviaServer::handleSignin(RecievedMessage* msg)
{
	SOCKET client_socket = msg->getSock();

	// get details
	vector<string> vals = msg->getValues();
	string userName = vals[0];
	string passWord = vals[1];
	
	// check if the username and password are correct 
	bool res = _db.isUserAndPassMatch(userName, passWord);
	if (!res)
	{
		Helper::sendData(client_socket, SRV_MSG_SIGN_IN_WRONG_DET); 
		TRACE("SEND: User try sign in with wrong details: username = %s, socket = %d", userName.c_str(), client_socket);
		return nullptr;
	}


	// if user already connected
	User* currUser = getUserByName(userName);
	if (currUser)
	{
		Helper::sendData(client_socket, SRV_MSG_SIGN_IN_ALREADY_CONNECTED);
		TRACE("SEND: User already connected: username = %s, socket = %d", userName.c_str(), currUser->getSocket());
		return nullptr;
	}


	// success
	// create user and add it to conntected users list
	currUser = new User(userName, client_socket);
	pair<SOCKET, User*> p(client_socket, currUser);

	TRACE("Adding new user to connected users list: socket = %d, username = %s", client_socket, userName.c_str());
	_connectedUsers.insert(p);
	

	// send success message
	currUser->send(SRV_MSG_SIGN_IN_SUCCESS);
	TRACE("SEND: User signed in successfuly: username = %s, socket = %d", userName.c_str(), client_socket);

	return (currUser);
}

// Msg Code: 203
bool TriviaServer::handleSignup(RecievedMessage* msg)
{
	SOCKET client_socket = msg->getSock();

	// get details
	vector<string> vals = msg->getValues();
	string userName = vals[0];
	string passWord = vals[1];
	string email = vals[2];

	// check if password is legal
	if (!Validator::isPasswordValid(passWord))
	{
		Helper::sendData(client_socket, SRV_MSG_SIGN_UP_PASS_ILLEGAL);
		TRACE("SEND: User signup failed. Invalid password: username = %s, socket = %d", userName.c_str(), client_socket);
		return false;
	}	

	if (!Validator::isUsernameValid(userName)) // check if username is legal
	{
		Helper::sendData(client_socket, SRV_MSG_SIGN_UP_USERNAME_ILLEGAL);
		TRACE("SEND: User signup failed. Invalid username: username = %s, socket = %d", userName.c_str(), client_socket);
		return false;

	}

	if (_db.isUserExists(userName)) // check if user already exists
	{
		Helper::sendData(client_socket, SRV_MSG_SIGN_UP_USER_EXIST);
		TRACE("SEND: User signup failed. User already exist: username = %s, socket = %d", userName.c_str(), client_socket);
		return false;

	}
	
	// try to insert the user to DB	
	bool res = _db.addNewUser(userName, passWord, email);
	
	// if didnt success to add user in DB
	if (!res)
	{
		Helper::sendData(client_socket, SRV_MSG_SIGN_UP_FAILED);
		TRACE("SEND: User signup failed. Failed insert record to DB: username = %s, socket = %d", userName.c_str(), client_socket);
		return false;
	}

	Helper::sendData(client_socket, SRV_MSG_SIGN_UP_SUCCESS);
	TRACE("SEND: User signed up successfuly: username = %s, socket = %d", userName.c_str(), client_socket);

	return (true);
}

bool TriviaServer::handleCreateRoom(RecievedMessage* msg)
{
	User* currentUser = msg->getUser();

	if (!currentUser)
		return false;

	// get details
	vector<string> vals = msg->getValues();
	string roomName = vals[0];
	int playersNo = atoi(vals[1].c_str());
	int QuestionsNo = atoi(vals[2].c_str());
	int AnswerTime = atoi(vals[3].c_str());

	int roomId = _roomIdSequence++;
	bool res = currentUser->createRoom(roomId, roomName, playersNo, QuestionsNo, AnswerTime);

	if (res)
	{
		pair<int, Room*> p(roomId, currentUser->getRoom());		
		_roomsList.insert(p);

			TRACE("Room was created: roomId=%d, roomName=%s, adminName=%s, playersNo=%d, QuestionsNo=%d, AnswerTime=%d", 
				roomId, roomName.c_str(), currentUser->getUsername().c_str(), playersNo, QuestionsNo, AnswerTime);
		}

		return res;

	}

	Room* TriviaServer::getRoomById(int roomId)
	{
		map<int, Room*>::iterator it = _roomsList.find(roomId);

		if (it == _roomsList.end())
		{
			return nullptr;
		}

		return it->second;

	}

	bool TriviaServer::handleJoinRoom(RecievedMessage* msg)
	{
		User* currentUser = msg->getUser();
		if (!currentUser)
			return false;

		int roomId = atoi(msg->getValues()[0].c_str());
		Room* currRoom = getRoomById(roomId);

		// didnt find the room
		if (!currRoom)
		{
			Helper::sendData(msg->getSock(), SRV_MSG_JOIN_ROOM_NOT_EXIST);
			TRACE("User failed to join room. Room doesnt exist. username = %s, roomId = %d", currentUser->getUsername().c_str(), roomId);
			return false;
		}

		bool res = currentUser->joinRoom(currRoom);

		if (res)
		{
			TRACE("User joined to room: roomId=%d, roomName=%s, userName=%s", roomId, currRoom->getName().c_str(), currentUser->getUsername().c_str());
		}
		return res;
	}


void TriviaServer::handlePlayerAnswer(RecievedMessage* msg)
{
	vector<string> vals = msg->getValues();
	int ansNo = atoi(vals[0].c_str());
	int time = atoi(vals[1].c_str());

	Game* g = msg->getUser()->getGame();

	if (!g)
	{
		TRACE("handlePlayerAnswer: User has no room");
		return;
	}

	// if game ended
	if (!g->handleAnswerFromUser(msg->getUser(), ansNo, time))
	{
		delete g;
		TRACE("handlePlayerAnswer: Game was ended and released from memory");
	}
}

void TriviaServer::handleStartGame(RecievedMessage* msg)
{
	TRACE("Starting Game");

	Room* rm = msg->getUser()->getRoom();

	Game* gm = nullptr;
	try
	{
		gm = new Game(rm->getUsers(), rm->getQuestionsNo(), this->_db);
	}
	catch (...)
	{
		// send fail message to admin
		msg->getUser()->send(SRV_MSG_GAME_QUESTION + Helper::getPaddedNumber(0, 1));
		TRACE("Game failed to start");
		delete gm;
		return;
	}

	// remove the room and clear its users
	int roomId = rm->getId();
	_roomsList.erase(roomId);
	TRACE("Room was removed from rooms list: roomId=%d, roomName=%s", roomId, rm->getName().c_str());
	

	gm->sendFirstQuestion();
	TRACE("Game was started");
}
void TriviaServer::handleLeaveGame(RecievedMessage* msg)
{
	User* currUser = msg->getUser();
	Game* g = currUser->getGame();

	// if game ended release the memory
	if (!currUser->leaveGame())
	{
		delete g;
		TRACE("handleLeaveGame: Game was ended and released from memory");
	}
}
bool TriviaServer::handleCloseRoom(RecievedMessage* msg)
{

	User* currentUser = msg->getUser();
	Room* rm = currentUser->getRoom();
	if (!rm)
	{
		return false;
	}

	string roomName = rm->getName();


	int roomId = currentUser->closeRoom();

	if (roomId != -1)
	{
		_roomsList.erase(roomId);
		TRACE("Room was closed: roomId=%d, roomName=%s, closingUser=%s", roomId, roomName.c_str(), currentUser->getUsername().c_str());
	}
	
	return roomId != -1;
}



bool TriviaServer::handleLeaveRoom(RecievedMessage* msg)
{
	User* currentUser = msg->getUser();
	if (!currentUser)
		return false;

	Room* rm = currentUser->getRoom();

	if (!rm)
		return false;
		
	int roomId = rm->getId();
	string roomName = rm->getName();

	currentUser->leaveRoom();
	TRACE("User left room: roomId=%d, roomName=%s, userName=%s", roomId, roomName.c_str(), currentUser->getUsername().c_str());

	return true;
}

void TriviaServer::handleGetUsersInRoom(RecievedMessage* msg)
{	
	User* currentUser = msg->getUser();

	int roomId = atoi(msg->getValues()[0].c_str());

	Room* rm = getRoomById(roomId);			

	TRACE("handleGetUsersInRoom: Get users in room id = %d", roomId);

	// if didnt find the room
	if (!rm)
	{
		// sould send 0 users
		currentUser->send(SRV_MSG_USERS_IN_ROOM + Helper::getPaddedNumber(0, 1));
		return;
	}

	// room was found
	string usersMsg = rm->getUsersListMessage();

	// send message
	currentUser->send(usersMsg);
}

void TriviaServer::handleGetRooms(RecievedMessage* msg)
{
	map<int, Room*>::iterator it;

	string roomId;
	string roomNameSize;
	string roomName;
	string content = SRV_MSG_ROOM_LIST + Helper::getPaddedNumber(_roomsList.size(), 4);
	for (it = _roomsList.begin(); it != _roomsList.end(); it++)
	{
		content += Helper::getPaddedNumber(it->second->getId(), 4);
		roomName = it->second->getName();
		content += Helper::getPaddedNumber(roomName.length(), 2) + roomName;
	}

	msg->getUser()->send(content);

}


void TriviaServer::handleGetBestScores(RecievedMessage* msg)
{
	vector<string> s = _db.getBestScores();

	string sRes = "";

	for (int i = 0; i < s.size(); i++)
	{
		sRes += s[i];
	}
	// creates the details in case there aren't 3 users
	for (int i = 0; i < 3 - s.size(); i++)
	{
		sRes += "00";
	}
	
	string res = std::to_string(SRV_MSG_REP_BEST_SCORES) + sRes;

	msg->getUser()->send(res);

}


void TriviaServer::handleGetPersonalStatus(RecievedMessage* msg)
{
	vector<string> s = _db.getPersonalStatus(msg->getUser()->getUsername());

	int games = atoi(s[0].c_str());
	int correct = atoi(s[1].c_str());
	int wrong = atoi(s[2].c_str());
	

	string sRes = Helper::getPaddedNumber(games, 4) + Helper::getPaddedNumber(correct, 6) + Helper::getPaddedNumber(wrong, 6) + s[3];


	string res = std::to_string(SRV_MSG_REP_PERSONAL_STATUS) + sRes;

	msg->getUser()->send(res);

}

void TriviaServer::addRecievedMessage(RecievedMessage* msg)
{	
	unique_lock<mutex> lck(_mtxRecievedMessages);

	//RecievedMessage* msg = new RecievedMessage(sc, messageCode);
	_queRcvMessages.push(msg);
	lck.unlock();
	cvQueue.notify_all();
	
}

RecievedMessage* TriviaServer::buildRecieveMessage(SOCKET client_socket, int msgCode)
{
	RecievedMessage* msg = nullptr;
	vector<string> values;
	if (msgCode == CLT_MSG_SIGN_IN)
	{
		int userSize = Helper::getIntPartFromSocket(client_socket, 2);
		string userName = Helper::getStringPartFromSocket(client_socket, userSize);
		int passSize = Helper::getIntPartFromSocket(client_socket, 2);
		string passWord = Helper::getStringPartFromSocket(client_socket, passSize);
		values.push_back(userName);
		values.push_back(passWord);

	}
	else if (msgCode == CLT_MSG_SIGN_UP)
	{
		int userSize = Helper::getIntPartFromSocket(client_socket, 2);
		string userName = Helper::getStringPartFromSocket(client_socket, userSize);
		int passSize = Helper::getIntPartFromSocket(client_socket, 2);
		string passWord = Helper::getStringPartFromSocket(client_socket, passSize);
		int emailSize = Helper::getIntPartFromSocket(client_socket, 2);
		string email = Helper::getStringPartFromSocket(client_socket, emailSize);
		values.push_back(userName);
		values.push_back(passWord);
		values.push_back(email);
	}
	else if (msgCode == CLT_MSG_CREATE_ROOM)
	{
		int roomNameSize = Helper::getIntPartFromSocket(client_socket, 2);
		string roomName = Helper::getStringPartFromSocket(client_socket, roomNameSize);
		string playersNo = Helper::getStringPartFromSocket(client_socket, 1);
		string QuestionsNo = Helper::getStringPartFromSocket(client_socket, 2);
		string AnswerTime = Helper::getStringPartFromSocket(client_socket, 2);
		values.push_back(roomName);
		values.push_back(playersNo);
		values.push_back(QuestionsNo);
		values.push_back(AnswerTime);
	}
	else if (msgCode == CLT_MSG_CLOSE_ROOM || msgCode == CLT_MSG_LEAVE_ROOM || msgCode == CLT_END_CONNECTION || msgCode == CLT_MSG_GET_ROOMS)
	{
		// do nothing becuase there arent another data in the recieved message (according protocol)
	}
	else if (msgCode == CLT_MSG_GET_USERS_IN_ROOM || msgCode == CLT_MSG_JOIN_ROOM)
	{
		string roomId = Helper::getStringPartFromSocket(client_socket, 4);
		values.push_back(roomId);
	}
	else if (msgCode == CLT_MSG_ANSWER)
	{
		string answerNo = Helper::getStringPartFromSocket(client_socket, 1);
		string answerTime = Helper::getStringPartFromSocket(client_socket, 2);

		values.push_back(answerNo);
		values.push_back(answerTime);

	}

	msg = new RecievedMessage(client_socket, msgCode, values);
	return msg;

}


void TriviaServer::clientHandler(SOCKET client_socket)
{
	User* currentUser = nullptr;
	RecievedMessage* currRcvMsg = nullptr;

	try
	{
		// get the message code
		int msgCode = Helper::getMessageTypeCode(client_socket);
		

		// loop will ended when there is an exception or the client sent message
		// which means to terminate the connction
		// the excpetion might occure also when the client has disconnected
		while (msgCode != CLT_END_CONNECTION && msgCode != 0)
		{
			//getMessageContent(msgCode);
			currRcvMsg = buildRecieveMessage(client_socket, msgCode);
			addRecievedMessage(currRcvMsg);
			msgCode = Helper::getMessageTypeCode(client_socket);
		}

		currRcvMsg = buildRecieveMessage(client_socket, CLT_END_CONNECTION);
		addRecievedMessage(currRcvMsg);
		
	}
	catch (const std::exception& e)
	{
		std::cout << "Exception was catch in function clientHandler. socket=" << client_socket << ", what=" << e.what() << std::endl;
		currRcvMsg = buildRecieveMessage(client_socket, CLT_END_CONNECTION);
		addRecievedMessage(currRcvMsg);
	}
}

void TriviaServer::handleRecievedMessages()
{
	RecievedMessage* currRcvMessage = nullptr;
	int msgCode;
	User* currUser = nullptr;
	SOCKET client_socket = 0;
	while (true)
	{

//		while (!_queRcvMessages.empty())
		{
			try
			{
				unique_lock<mutex> lck(_mtxRecievedMessages);
				
				if (_queRcvMessages.empty())
					cvQueue.wait(lck);

				// in case the queue is empty...
				if (_queRcvMessages.empty())
					continue;

				currRcvMessage = _queRcvMessages.front();
				_queRcvMessages.pop();
				lck.unlock();

//				unique_lock<mutex> lck(_mtxRecievedMessages);
//				currRcvMessage = _queRcvMessages.front();
//				_queRcvMessages.pop();
//				lck.unlock();

				client_socket = currRcvMessage->getSock();
				currUser = getUserBySocket(client_socket);
				currRcvMessage->setUser(currUser);
				msgCode = currRcvMessage->getMessageCode();

				TRACE("--------------------------------------");
				TRACE("handleRecievedMessages: msgCode = %d, client_socket: %d", msgCode, client_socket);

				if (msgCode == CLT_MSG_SIGN_IN) // Sign in
				{
					handleSignin(currRcvMessage);
				}
				else if (msgCode == CLT_MSG_SIGN_UP) // Sign up
				{
					handleSignup(currRcvMessage);
				}
				else if (msgCode == CLT_MSG_SIGN_OUT)
				{
					handleSignout(currRcvMessage);
				}
				else if (msgCode == CLT_MSG_CREATE_ROOM)
				{
					handleCreateRoom(currRcvMessage);
				}
				else if (msgCode == CLT_MSG_CLOSE_ROOM)
				{
					handleCloseRoom(currRcvMessage);
				}
				else if (msgCode == CLT_MSG_JOIN_ROOM)
				{
					handleJoinRoom(currRcvMessage);
				}
				else if (msgCode == CLT_MSG_LEAVE_ROOM)
				{
					handleLeaveRoom(currRcvMessage);

				}
				else if (msgCode == CLT_MSG_GET_ROOMS)
				{
					handleGetRooms(currRcvMessage);
				}
				else if (msgCode == CLT_MSG_GET_USERS_IN_ROOM)
				{
					handleGetUsersInRoom(currRcvMessage);
				}
				else if (msgCode == CLT_MSG_START_GAME)
				{
					handleStartGame(currRcvMessage);
				}
				else if (msgCode == CLT_MSG_ANSWER)
				{
					handlePlayerAnswer(currRcvMessage);
				}
				else if (msgCode == CLT_MSG_LEAVE_GAME)
				{
					handleLeaveGame(currRcvMessage);
				}
				else if (msgCode == CLT_END_CONNECTION)
				{
					// close the connection with the user
					safeDeleteUser(currRcvMessage);

				}			
				else if (msgCode == CLT_MSG_REP_BEST_SCORES)
				{
					handleGetBestScores(currRcvMessage);
				}
				else if (msgCode == CLT_MSG_REP_PERSONAL_STATUS)
				{
					handleGetPersonalStatus(currRcvMessage);
				}
				else // unknown message
				{
					// close the connection with the user
					safeDeleteUser(currRcvMessage);
				}
			}
			catch (const std::exception& e)
			{
				std::cout << "Exception was catch in function handleRecievedMessages. socket=" << client_socket << ", what=" << e.what() << std::endl;
				safeDeleteUser(currRcvMessage);
			
			}

			TRACE("--------------------------------------");

		}
	}
}

void TriviaServer::handleSignout(RecievedMessage* msg)
{
	User* currUser = msg->getUser();

	if (!currUser)
		return;
	SOCKET id = msg->getSock();

	// remove user from the queue
	TRACE("Erase user from connected users list: username = %s, socket = %d", currUser->getUsername().c_str(), id)
	_connectedUsers.erase(id);

	// in case the user is admin of room or in room
	handleCloseRoom(msg);
	handleLeaveRoom(msg);
	handleLeaveGame(msg);
	TRACE("User had signedout: username = %s, socket = %d", currUser->getUsername().c_str(), id)
}
// remove the user from connected users list
void TriviaServer::safeDeleteUser(RecievedMessage* msg)
{
	try
	{
		SOCKET id = msg->getSock();
		
		handleSignout(msg);

		TRACE("Closing socket = %d", id)
		closesocket(id);
		TRACE("User has disconnected: socket = %d", id);
	}
	catch (...) {}
}



