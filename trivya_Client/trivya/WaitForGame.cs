using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Threading;


namespace trivya
{
    public partial class WaitForGame : Form
    {
        Client client;
        string roomID;

        string[] users;

        bool adminStartedGame = false;
        bool exitRoom = false;
        Thread roomListUpdateThread;

        //first item in users will be the code , so we can know what message the user got
        public void updateUsersList()
        {
            users = client.recieveUsers();

            if (users.Length != 1 && !users[0].Equals(Codes.SERVER_QUESTION))
            {
                if (playersList.InvokeRequired)
                    Invoke((MethodInvoker)delegate { playersList.Items.Clear(); });
                else
                    playersList.Items.Clear();
                string code = users[0];
                for (int i = 1; i < users.Length; i++)
                {
                    if (playersList.InvokeRequired)
                        Invoke((MethodInvoker)delegate { playersList.Items.Add(users[i]); });
                    else
                        playersList.Items.Add(users[i]);
                }
            }
        }

        public void listenToUpdates()
        {
            //while (running && (users[0].Equals("error")) || (users.Length != 1 && !clientClosedRoom))
            while (!users[0].Equals(Codes.SERVER_QUESTION) && !users[0].Equals(Codes.CLOSE_ROOM_ANS) && !adminStartedGame && !exitRoom)
            {
                updateUsersList();
            }
            if (users[0].Equals(Codes.SERVER_QUESTION))//if room was closed or user left the room we will just finish
            {
                Invoke((MethodInvoker)delegate { string[] question = new string[5]; for (int i = 0; i < 5; i++) { question[i] = users[i + 1]; } Game g = new Game(client, question); g.Owner = this.Owner; g.Show(); });
                Invoke((MethodInvoker)delegate { this.Close(); });
                return;
            }
            else if (users[0].Equals(Codes.CLOSE_ROOM_ANS))
            {
                Invoke((MethodInvoker)delegate { err.Visible = true;  err.Text = "The admin closed the room press OK to continue"; });
                leaveRoom.Text = "OK";
                
                return;
            }

        }
        public WaitForGame(Client cl,string roomId,string roomName)
        {
            roomID = roomId;
            client = cl;
            InitializeComponent();
            username.Text = client.myName;
            this.roomName.Text = client.myRoom;
            if (client.numberOfPlayers>0)
            roomDetails.Text = "max_number_players:" + client.numberOfPlayers.ToString() + "  number_of_questions:" + client.numberOfQuestions.ToString() + "  time_per_question:" + client.timePerQuestion.ToString();
            else
                roomDetails.Text = "number_of_questions:" + client.numberOfQuestions.ToString() + "  time_per_question:" + client.timePerQuestion.ToString();
            this.StartPosition = FormStartPosition.CenterScreen;
            if (roomID.Equals(""))
            {
                leaveRoom.Text = "Close Room";
                startGame.Visible = true;
                playersList.Items.Add(client.myName);
                // doing this only because the thread checks out users
                users = new string[2];
                users[0] = Codes.GET_USERS_ANS;
                users[1] = client.myName;
            }
            else
            {
                client.askForUsers(roomId);
                updateUsersList();
            }

            header.Text = "You are connected to room " + roomName;
            roomListUpdateThread = new Thread(listenToUpdates);
            roomListUpdateThread.Start();
        }
        private void startGame_Click(object sender, EventArgs e)
        {
            adminStartedGame = true;
            System.Threading.Thread.Sleep(200);
            Game g= new Game(client,null);
            g.Owner = this.Owner;
            g.Show();
            this.Close();
        }

        private void leaveRoom_Click(object sender, EventArgs e)
        {
            exitRoom = true;
            //if room was not closed by admin we do this
            if (!"OK".Equals(leaveRoom.Text))
            {
                System.Threading.Thread.Sleep(200);
                if (roomID.Equals(""))
                {
                    client.sendCloseRoom();
                    string res = client.recvCloseRoom();
                }
                else
                {
                    client.leaveRoom(roomID);

                }
            }
            this.Owner.Show();
            this.Close();
        }
    }
}
