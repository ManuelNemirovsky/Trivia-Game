using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.Net.Sockets;

using System.Windows.Forms;

using System.Diagnostics;


namespace trivya
{
    public class Client : Codes
    {
        static IPAddress ipAddress;
        static IPEndPoint remoteEP;
        static Socket client;

        public int numberOfQuestions=0;
        public int timePerQuestion=0;
        public int numberOfPlayers=0;

        int sumQuestions = 0;
        int sumTime = 0;
        int sumRight = 0;
        int sumWrong = 0;

        public string myName = "";
        public string myRoom = "";

        //Settng the connection with the server
        private void setConnection()
        {
            //object that reads the file that keeps all of the configuration
            System.IO.StreamReader sr = new System.IO.StreamReader("config.txt");
            //after openning the file, we need to split the data and get the
            //ip address and the port 
            string ip = sr.ReadLine().Split('=')[1];
            int port = Int32.Parse(sr.ReadLine().Split('=')[1]);
            bool encrypt = Convert.ToBoolean(sr.ReadLine().Split('=')[1]);
            ipAddress = System.Net.IPAddress.Parse(ip);
            remoteEP = new IPEndPoint(ipAddress, port);
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            DialogResult result = DialogResult.OK;
            while (true)
            {
                try
                {
                    //setting the connection
                    client.Connect(remoteEP);
                    break;
                }
                catch
                {
                    //if we found an error, we pr
                    string message = "You do not have a server running\n\n Ok - try again. \n Cancel - close client. ";
                    string caption = "Error Detected";
                    MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
                    result = MessageBox.Show(message, caption, buttons);
                    if (result == DialogResult.Cancel)
                    {
                        System.Environment.Exit(1);
                        break;
                    }
                    else
                    {
                        System.Threading.Thread.Sleep(1000);
                    }
                }
            }

        }

        //The constractor needs to set the connection
        public Client()
        {
            setConnection();
        }

        //Adding the padding of the messages to the message that we will send to the server.
        //gets: input - source message that we want to add
        //numOfChars - num of charechters to copy from the input string.
        //dstOffset - num of charechters to copy from the input string.
        //res - the destination that we will input the string to.
        //returns: void.    
        public void addToMsg(string input, int numOfChars, int dstOffset, ref byte[] res)
        {
            string len = input.Length.ToString();
            if (input.Length < 10)
                len = "0" + len;
            System.Buffer.BlockCopy(Encoding.ASCII.GetBytes(len), 0, res, dstOffset, numOfChars);
            System.Buffer.BlockCopy(Encoding.ASCII.GetBytes(input), 0, res, dstOffset + numOfChars, input.Length);
            return;
        }

        //Creating client sign in request for the server.
        //Gets: two strings, user name and password of the registration.
        //returns: answer from the server, if the user managed to get in.
        public string signIn(string userName, string pass)
        {
            byte[] msg = new byte[CODE_LEN + USERLEN + userName.Length + PASSLEN + pass.Length];
            System.Buffer.BlockCopy(Encoding.ASCII.GetBytes(SIGN_IN), 0, msg, 0, CODE_LEN);

            //send to the addToMsg pointer to the msg for adding the padding 
            //of the message.
            addToMsg(userName, USERLEN, CODE_LEN, ref msg);
            addToMsg(pass, PASSLEN, CODE_LEN + USERLEN + userName.Length, ref msg);

            //The client sends the name and the password of the user and wait for the server's respone.
            //Meanwhile, the server checks if the user exist in the DB.
            client.Send(msg);

            //Getting answer back from the server.
            byte[] ans = new byte[4];
            int bytesRec = client.Receive(ans);

            //converting the code from the server to string.
            string code = System.Text.Encoding.Default.GetString(ans, 0, 3);
            //Check if the code is not equal to what we should get from the server.
            if (!code.Equals(SIGN_IN_ANS, StringComparison.Ordinal))
                return "ERROR";

            //now we convert the respone to chars and we read the messages accurding the language
            //between the server and the client.
            char res = Convert.ToChar(ans[3]);
            if (res == '0')
            {
                myName = userName;
                return "Success";
            }
            else if (res == '1')
                return "Wrong details";
            else if (res == '2')
                return "User is already connected";
            else
                return "ERROR";
        }

        //Creating client sign up request for the server.
        //Gets: three strings, user name and password and email of the registration.
        //returns: answer from the server, if the user managed to get in.
        public string signUp(string userName, string pass, string email)
        {
            //Creating message in the size of the sign up message.
            byte[] msg = new byte[CODE_LEN + USERLEN + userName.Length + PASSLEN + pass.Length + EMAILLEN + email.Length];
            System.Buffer.BlockCopy(Encoding.ASCII.GetBytes(SIGN_UP), 0, msg, 0, CODE_LEN);

            //as we made before, adding the user name, pass and email to the message for checking with the server.
            addToMsg(userName, USERLEN, CODE_LEN, ref msg);
            addToMsg(pass, PASSLEN, CODE_LEN + USERLEN + userName.Length, ref msg);
            addToMsg(email, EMAILLEN, CODE_LEN + USERLEN + userName.Length + PASSLEN + pass.Length, ref msg);
            client.Send(msg);

            //making all of the process with taking out the charachters
            byte[] ans = new byte[4];
            int bytesRec = client.Receive(ans);

            string code = System.Text.Encoding.Default.GetString(ans, 0, 3);
            if (!code.Equals(SIGN_UP_ANS, StringComparison.Ordinal))
                return "ERROR";

            //checking answers from the server to make sure everything is ok.
            char res = Convert.ToChar(ans[3]);
            if (res == '0')
                return "Success";
            else if (res == '1')
                return "Pass Illegal";
            else if (res == '2')
                return "Username is lready exists";
            else if (res == '3')
                return "Username is illegal";
            else if (res == '4')
                return "Other";
            else
                return "ERROR";
        }

        //Close the program.
        public void signOut()
        {
            byte[] msg = new byte[CODE_LEN];
            System.Buffer.BlockCopy(Encoding.ASCII.GetBytes(SIGN_OUT), 0, msg, 0, CODE_LEN);
            client.Send(msg);
        }
        
        //sening the server request for getting all of the rooms
        //send string of the msg code accurding to the protocol.
        public string[] getRooms()
        {
            string[] res;
            byte[] msg = new byte[CODE_LEN];
            System.Buffer.BlockCopy(Encoding.ASCII.GetBytes(GET_ROOMS), 0, msg, 0, CODE_LEN);
            client.Send(msg);

            byte[] ans = new byte[200000];
            int bytesRec = client.Receive(ans);
            string code = System.Text.Encoding.Default.GetString(ans, 0, 3);
            if (!code.Equals(GET_ROOMS_ANS, StringComparison.Ordinal))
            {
                res = new string[1];
                res[0] = code;
                return res;
            }
            int numOfRooms = Int32.Parse(System.Text.Encoding.Default.GetString(ans, 3, 4));
            res = new string[numOfRooms * 2];
            int nameLen, offset = 0;
            for (int i = 0; i < numOfRooms * 2; i += 2)
            {
                res[i] = System.Text.Encoding.Default.GetString(ans, 7 + offset, 4);
                nameLen = Int32.Parse(System.Text.Encoding.Default.GetString(ans, 7 + offset + 4, 2));
                res[i + 1] = System.Text.Encoding.Default.GetString(ans, 7 + offset + 4 + 2, nameLen);
                offset += 4 + 2 + nameLen;

            }
            return res;

        }

        //Sends request for getting the users in the room (207)
        public void askForUsers(string roomId)
        {
            byte[] msg = new byte[CODE_LEN + ROOM_ID_LEN];
            System.Buffer.BlockCopy(Encoding.ASCII.GetBytes(GET_USERS), 0, msg, 0, CODE_LEN);
            while (roomId.Length < ROOM_ID_LEN)
            {
                roomId = "0" + roomId;
            }
            System.Buffer.BlockCopy(Encoding.ASCII.GetBytes(roomId), 0, msg, 3, ROOM_ID_LEN);
            client.Send(msg);
        }

        // when we call this function we may get the first question.
        // it happens if the admin started his game
        public string[] recieveUsers()
        {
            string[] res;
            byte[] ans = new byte[10000]; 

            //try getting updates with timeout
            client.ReceiveTimeout = 100;
            try
            {
                int bytesRec = client.Receive(ans);
            }
            catch
            {
                client.ReceiveTimeout = -1;
                res = new string[1];
                res[0] = "error";
                return res;
            }
            client.ReceiveTimeout = -1;


            string code = System.Text.Encoding.Default.GetString(ans, 0, 3);
            int offset;

            //first question recieved from server
            if (code.Equals(SERVER_QUESTION))
            //add check for fail if (Int32.Parse(System.Text.Encoding.Default.GetString(ans, 3 , 3))==0) 
            {
                int len;
                offset = 3;
                res = new string[6];
                res[0] = code;
                for (int i = 1; i < 6; i++)
                {
                    len = Int32.Parse(System.Text.Encoding.Default.GetString(ans, offset, 3));
                    res[i] = System.Text.Encoding.Default.GetString(ans, offset + 3, len);
                    offset += 3 + len;
                }
                return res;
            }

            //admin closed room
            if (code.Equals(CLOSE_ROOM_ANS))
            {
                res = new string[1];
                res[0] = CLOSE_ROOM_ANS;
                return res;
            }
            int numOfUsers = Int32.Parse(System.Text.Encoding.Default.GetString(ans, 3, 1));
            res = new string[numOfUsers + 1];
            res[0] = code;
            int nameLen;
            offset = 0;
            for (int i = 1; i < numOfUsers + 1; i++)
            {
                nameLen = Int32.Parse(System.Text.Encoding.Default.GetString(ans, 4 + offset, 2));
                res[i] = System.Text.Encoding.Default.GetString(ans, 4 + offset + 2, nameLen);
                offset += 2 + nameLen;

            }
            return res;
        }

        //ask for the users list
        public string[] getUsers(string roomId)
        {
            askForUsers(roomId);
            return recieveUsers();
        }

        //sends name of a user and ID of room and put the user inside the room
        public string joinRoom(string roomId, string roomName)
        {
            myRoom = roomName;
            byte[] msg = new byte[CODE_LEN + ROOM_ID_LEN];
            System.Buffer.BlockCopy(Encoding.ASCII.GetBytes(JOIN_ROOM), 0, msg, 0, CODE_LEN);
            while (roomId.Length < ROOM_ID_LEN)
            {
                roomId = "0" + roomId;
            }
            System.Buffer.BlockCopy(Encoding.ASCII.GetBytes(roomId), 0, msg, 3, ROOM_ID_LEN);
            client.Send(msg);

            byte[] ans = new byte[8];
            int bytesRec = client.Receive(ans);
            string code = System.Text.Encoding.Default.GetString(ans, 0, 3);
            if (!code.Equals(JOIN_ROOM_ANS))
            {
                return "ERROR";
            }
            int status = Int32.Parse(System.Text.Encoding.Default.GetString(ans, 3, 1));
            if (status == 2)
                return "ROOM NOT EXIST OR OTHER ERROR";
            else if (status == 1)
                return "ROOM IS FULL";
            else if (status == 0)
            {
                numberOfQuestions = Int32.Parse(System.Text.Encoding.Default.GetString(ans, 4, 2));
                if (numberOfQuestions < 1 || numberOfQuestions > 99)
                    return "wrong number of questions recieved from server";
                timePerQuestion = Int32.Parse(System.Text.Encoding.Default.GetString(ans, 6, 2));
                if (timePerQuestion < 1 || timePerQuestion > 99)
                    return "wrong time recieved recieved from server";
                return "SUCCESS";
            }
            return "UNKNOWN ERROR";
        }

        //takes the room ID and sends to the server for leaving the room
        public string leaveRoom(string roomId)
        {
            byte[] msg = new byte[CODE_LEN];
            System.Buffer.BlockCopy(Encoding.ASCII.GetBytes(LEAVE_ROOM), 0, msg, 0, CODE_LEN);
            client.Send(msg);
            byte[] ans = new byte[4];
            int bytesRec = client.Receive(ans);
            string code = System.Text.Encoding.Default.GetString(ans, 0, 3);
            int status = Int32.Parse(System.Text.Encoding.Default.GetString(ans, 3, 1));
            if (!code.Equals(LEAVE_ROOM_ANS) || status != 0)
            {
                return "error: got massage code: " + code;
            }
            return "success";
        }

        //convert number to string
        public string numToString(int num, int requesteLen)
        {
            string strNum = num.ToString();
            while (strNum.Length < requesteLen)
            {
                strNum = "0" + strNum;
            }
            return strNum;
        }

        //create room and sends the name of the room, the number of players that 
        //can get into the room and the number of questions, and the time for a question
        //gets in return if the room has been created or not.
        public string createRoom(string roomName, int playersNumber, int questionsNumber, int questionTime)
        {
            numberOfQuestions = questionsNumber;
            timePerQuestion = questionTime;
            numberOfPlayers = playersNumber;
            myRoom = roomName;

            byte[] msg = new byte[CODE_LEN + ROOM_NAME_LEN + roomName.Length + PLAYERS_LEN + QUESTIONS_NUM_LEN + TIME_PER_QUESTION_LEN];
            System.Buffer.BlockCopy(Encoding.ASCII.GetBytes(CREATE_ROOM), 0, msg, 0, CODE_LEN);
            addToMsg(roomName, ROOM_NAME_LEN, CODE_LEN, ref msg);
            System.Buffer.BlockCopy(Encoding.ASCII.GetBytes(numToString(playersNumber, 1)), 0, msg, CODE_LEN + ROOM_NAME_LEN + roomName.Length, 1);
            System.Buffer.BlockCopy(Encoding.ASCII.GetBytes(numToString(questionsNumber, 2)), 0, msg, CODE_LEN + ROOM_NAME_LEN + roomName.Length + 1, 2);
            System.Buffer.BlockCopy(Encoding.ASCII.GetBytes(numToString(timePerQuestion, 2)), 0, msg, CODE_LEN + ROOM_NAME_LEN + roomName.Length + 3, 2);

            client.Send(msg);

            byte[] ans = new byte[4];
            int bytesRec = client.Receive(ans);
            string code = System.Text.Encoding.Default.GetString(ans, 0, 3);
            if (!code.Equals(CREATE_ROOM_ANS))
            {
                return "error: got massage code: " + code;
            }
            int status = Int32.Parse(System.Text.Encoding.Default.GetString(ans, 3, 1));
            if (status == 0)
                return "SUCCESS";
            else
            {
                return "create romm failed, code msg: " + code + status.ToString();
            }

        }

        //sends msg to close specific room.
        public void sendCloseRoom()
        {
            byte[] msg = new byte[CODE_LEN];
            System.Buffer.BlockCopy(Encoding.ASCII.GetBytes(CLOSE_ROOM), 0, msg, 0, CODE_LEN);
            client.Send(msg);
        }

        //gets room to close
        public string recvCloseRoom()
        {
            byte[] ans = new byte[3];
            int bytesRec = client.Receive(ans);
            string code = System.Text.Encoding.Default.GetString(ans, 0, 3);
            if (!code.Equals(CLOSE_ROOM_ANS, StringComparison.Ordinal))
            {
                return "close error";
            }
            else
            {
                return "success";
            }
        }

        //starting the game with the msg from the protocol
        public void startGame()
        {
            byte[] msg = new byte[CODE_LEN];
            System.Buffer.BlockCopy(Encoding.ASCII.GetBytes(START_GAME), 0, msg, 0, CODE_LEN);
            client.Send(msg);
        }
        
        //get question from the DB
        public string[] getQuestion()
        {
            string[] res;
            byte[] ans = new byte[10000];
            int bytesRec = client.Receive(ans);
            string code = System.Text.Encoding.Default.GetString(ans, 0, 3);

            if (code.Equals(SERVER_QUESTION))
            //add check for fail if (Int32.Parse(System.Text.Encoding.Default.GetString(ans, 3 , 3))==0) 
            {
                int len, offset = 3;
                res = new string[5];
                for (int i = 0; i < 5; i++)
                {
                    len = Int32.Parse(System.Text.Encoding.Default.GetString(ans, offset, 3));
                    res[i] = System.Text.Encoding.Default.GetString(ans, offset + 3, len);
                    offset += 3 + len;
                }
            }
            else if (code.Equals(GAME_OVER))
            {
                int len, offset = 4;
                int usersNumber = Int32.Parse(System.Text.Encoding.Default.GetString(ans, 3, 1));
                res = new string[usersNumber * 2];
                for (int i = 0; i < usersNumber*2; i += 2)
                {
                    len = Int32.Parse(System.Text.Encoding.Default.GetString(ans, offset, 2));
                    res[i] = System.Text.Encoding.Default.GetString(ans, offset + 2, len); //username
                    res[i + 1] = System.Text.Encoding.Default.GetString(ans, offset + 2 + len, 2); //score
                    offset += 2 + len + 2;
                }
            }
            else
            {
                res = new string[1];
                res[0] = "error";
            }

            return res;

        }

        //send answer accurding to the protocol msg
        public void sendAnswer(char answer, int time)
        {
            byte[] msg = new byte[CODE_LEN + 1 + 2];
            System.Buffer.BlockCopy(Encoding.ASCII.GetBytes(SEND_ANSWER), 0, msg, 0, CODE_LEN);
            msg[CODE_LEN] = Convert.ToByte(answer);

            System.Buffer.BlockCopy(Encoding.ASCII.GetBytes(numToString(time, 2)), 0, msg, CODE_LEN + 1, 2);
            client.Send(msg);
            sumQuestions++;
            sumTime += time;
        }

        //sends respone to the question from the server.
        public string[] sendAnswerResponse()
        {
            string[] res;
            byte[] ans = new byte[10000];
            int bytesRec = client.Receive(ans);
            string code = System.Text.Encoding.Default.GetString(ans, 0, 3);
            if (code.Equals(SEND_ANSWER_ANS, StringComparison.Ordinal))
            {
                res = new string[1];
                res[0] = System.Text.Encoding.Default.GetString(ans, 3, 1);
                if (res[0].Equals("1"))
                    sumRight++;
                else if (res[0].Equals("0"))
                    sumWrong++;

            }
            else
            {
                res = new string[1];
                res[0] = "error";
            }

            return res;
        }

        //Leaving specific game
        public void LeaveGame()
        {
            byte[] msg = new byte[CODE_LEN];
            System.Buffer.BlockCopy(Encoding.ASCII.GetBytes(LEAVE_GANE), 0, msg, 0, CODE_LEN);
            client.Send(msg);
        }

        //getting the best scores from the DB
        public string[] geBestScores()
        {
            byte[] msg = new byte[CODE_LEN];
            System.Buffer.BlockCopy(Encoding.ASCII.GetBytes(GET_BEST_SCORES), 0, msg, 0, CODE_LEN);
            client.Send(msg);

            string[] res;
            byte[] ans = new byte[1000];
            int bytesRec = client.Receive(ans);
            string code = System.Text.Encoding.Default.GetString(ans, 0, 3);
            if (!code.Equals(BEST_SCORES_ANS))
            {
                res = new string[1];
                res[0] = "error";
            }
            else
            {
                int nameLen, offset = 3;
                res = new string[3 * 2];
                for (int i = 0; i < 6; i += 2)
                {
                    nameLen = Int32.Parse(System.Text.Encoding.Default.GetString(ans, offset, 2));
                    res[i] = System.Text.Encoding.Default.GetString(ans, offset + 2, nameLen); //username
                    res[i + 1] = System.Text.Encoding.Default.GetString(ans, offset + 2 + nameLen, 6); //score
                    offset += 2 + nameLen + 6;
                }
            }

            return res;
        }

        //ask for the specific status of the user that got entered to the game
        public double[] getMyStatus()
        {
            byte[] msg = new byte[CODE_LEN];
            System.Buffer.BlockCopy(Encoding.ASCII.GetBytes(GET_MY_STATUS), 0, msg, 0, CODE_LEN);
            client.Send(msg);

            double[] res;
            byte[] ans = new byte[3 + 4 + 6 + 6 + 4];
            int bytesRec = client.Receive(ans);
            string code = System.Text.Encoding.Default.GetString(ans, 0, 3);
            if (!code.Equals(MY_STATUS_ANS, StringComparison.Ordinal))
            {
                res = new double[1];
                res[0] = -1;
            }
            else
            {
                res = new double[4];
                res[0] = Int32.Parse(System.Text.Encoding.Default.GetString(ans, 3, 4));    //numberOfGames 
                res[1] = Int32.Parse(System.Text.Encoding.Default.GetString(ans, 7, 6));    //numberOfRightAns
                res[2] = Int32.Parse(System.Text.Encoding.Default.GetString(ans, 13, 6));   //numerOfWrongAns 
                res[3] = Int32.Parse(System.Text.Encoding.Default.GetString(ans, 19, 4))/100.0;   //avgTimeForAns
            }

            return res;
        }

        //getting out of the app (sends to the server so the server will know that the app closed)
        public void quitApp(string request)
        {
            byte[] msg = new byte[CODE_LEN];
            System.Buffer.BlockCopy(Encoding.ASCII.GetBytes(QUIT), 0, msg, 0, CODE_LEN);
            client.Send(msg);
            client.Close();
            Application.Exit();
            Environment.Exit(0);
        }
    }
}
