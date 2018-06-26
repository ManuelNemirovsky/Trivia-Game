using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace trivya
{
    public partial class JoinRoom : Form
    {
        Client client;
        string[] roomsIdAndName;
        string[] users;


        public JoinRoom(Client cl)
        {
            client = cl;
            InitializeComponent();
            username.Text = client.myName;
            
            updateRoomsList();
            if (roomsIdAndName.Length == 0)
            {
                available.Visible = true;
                join.Enabled = false;
            }

            this.StartPosition = FormStartPosition.CenterScreen;

        }


        public void updateRoomsList()
        {
            playersHeader.Visible = false;
            playersList.Visible = false;
            roomsIdAndName = client.getRooms();
            if (roomsIdAndName.Length > 0)
                available.Visible = false;
            else
                available.Visible = true;
            roomsList.Items.Clear();
            for (int i = 0; i < roomsIdAndName.Length; i += 2)
            {
                roomsList.Items.Add(roomsIdAndName[i + 1]);
            }
        }

        //first item in users will be the code , so we can know what message the user got
        public bool updateUsersList()
        {
            if (roomsList.SelectedIndex < 0) //wrong click
                return false;
            users = client.getUsers(roomsIdAndName[roomsList.SelectedIndex * 2]);
            playersList.Items.Clear();
            string code = users[0];
            for (int i = 1; i < users.Length; i++)
            {
                playersList.Items.Add(users[i]);
            }
            return true;
        }





        private void roomsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updateUsersList())
            {
                join.Enabled = true;
                playersHeader.Visible = true;
                playersList.Visible = true;
            }

        }


        private void join_Click(object sender, EventArgs e)
        {
            string res = client.joinRoom(roomsIdAndName[roomsList.SelectedIndex * 2], roomsIdAndName[roomsList.SelectedIndex * 2 + 1]);
            if (res.Equals("SUCCESS"))
            {
                WaitForGame W = new WaitForGame(client, roomsIdAndName[roomsList.SelectedIndex * 2], roomsIdAndName[roomsList.SelectedIndex * 2+1]);
                W.Owner = this.Owner;
                W.Show();
                this.Close();

            }
            else
            {
                errorLabel.Text = res;
                errorLabel.Visible = true;
            }

        }

        private void back_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }

        private void refresh_Click(object sender, EventArgs e)
        {
            updateRoomsList();
            join.Enabled = false;
        }

    }
}
