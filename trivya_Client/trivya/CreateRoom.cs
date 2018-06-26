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
    public partial class CreateRoom : Form
    {
        Client client;
        public CreateRoom(Client cl)
        {
            client = cl;
            InitializeComponent();
            username.Text = client.myName;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void back_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }

        private void send_Click(object sender, EventArgs e)
        {
            if (roomName.Text.Length > 99 || roomName.Text.Length < 1)
            {
                errorLabel.Visible = true;
                errorLabel.Text = "wrong room name";
                return;
            }
            else if (Int32.Parse(numberOfPlayers.Text) > 9 || Int32.Parse(numberOfPlayers.Text) < 1)
            {
                errorLabel.Visible = true;
                errorLabel.Text = "wrong number of players";
                return;
            }
            else if (Int32.Parse(numberOfQuestions.Text) > 99 || Int32.Parse(numberOfQuestions.Text) < 1)
            {
                errorLabel.Visible = true;
                errorLabel.Text = "wrong number of questions";
                return;
            }
            else if (Int32.Parse(time.Text) > 99 || Int32.Parse(time.Text) < 1)
            {
                errorLabel.Visible = true;
                errorLabel.Text = "wrong time";
                return;
            }
            string res = client.createRoom(roomName.Text, Int32.Parse(numberOfPlayers.Text), Int32.Parse(numberOfQuestions.Text), Int32.Parse(time.Text));
            if (res.Equals("SUCCESS"))
            {
                WaitForGame W = new WaitForGame(client, "", roomName.Text);
                W.Owner = this.Owner;
                W.Show();
                this.Close();
            }
            else
            {
                errorLabel.Visible = true;
                errorLabel.Text = res;
            }
        }


    }
}
