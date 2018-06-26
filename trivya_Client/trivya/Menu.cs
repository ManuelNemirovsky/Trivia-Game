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
    public partial class Menu : Form
    {
        public static Client client;
        
        public Menu()
        {
            client = new Client();
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void signIn_Click(object sender, EventArgs e)
        {

            if (String.IsNullOrEmpty(signInUser.Text) || String.IsNullOrEmpty(signInPass.Text))
            {
                labErrSignIn.Text = "Please fill all fields";
                labErrSignIn.Visible = true;
                return;
            }
            
            string res = client.signIn(signInUser.Text, signInPass.Text);

            if (String.Compare(res, "Success") != 0)
            {
                labErrSignIn.Visible = true;
                labErrSignIn.Text = res;
                return;
            }

            //sign in text and lables
            signIn.Visible = false;
            labPassSignIn.Visible = false;
            labUserSignIn.Visible = false;
            signInUser.Visible=false;
            signInPass.Visible = false;
            labErrSignIn.Visible = false;
            panel.BackColor = System.Drawing.Color.Black;

            labHello.Visible = true;
            labHello.Text = "Hello "+ signInUser.Text;
            
            signUp.Text = "Sign out";

            myStatus.Enabled = true;
            joinRoom.Enabled = true;
            createRoom.Enabled = true;
            scores.Enabled = true;
            username.Visible = true;
            username.Text = client.myName;

        }

        private void signUp_Click(object sender, EventArgs e)
        {
            if (String.Compare(signUp.Text, "Sign out") == 0)
            {
                client.signOut();

                labHello.Visible = false;

                //sign in text and lables
                //sign in text and lables
                signIn.Visible = true;
                labPassSignIn.Visible = true;
                labUserSignIn.Visible = true;
                signInUser.Visible = true;
                signInPass.Visible = true;

                panel.BackColor = System.Drawing.Color.White; 
                signInUser.Text = "";
                signInPass.Text = "";

                signUp.Text = "Sign up";

                myStatus.Enabled = false;
                joinRoom.Enabled = false;
                createRoom.Enabled = false;
                scores.Enabled = false;
                username.Visible = false;
                return;
            }

            SignUp signUpForm = new SignUp(client);
            signUpForm.Owner = this;
            this.Hide();
            signUpForm.Show();
        }


        private void quit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void createRoom_Click(object sender, EventArgs e)
        {
            this.Hide();
            CreateRoom createRoomForm = new CreateRoom(client);
            createRoomForm.Owner = this;
            createRoomForm.Show();
        }


        private void joinRoom_Click(object sender, EventArgs e)
        {
            this.Hide();
            JoinRoom joinRoomForm = new JoinRoom(client);
            joinRoomForm.Owner = this;
            joinRoomForm.Show();
        }

        private void scores_Click(object sender, EventArgs e)
        {
            this.Hide();
            Scores sc = new Scores(client);
            sc.Owner = this;
            sc.Show();
        }

        private void myStatus_Click(object sender, EventArgs e)
        {
            this.Hide();
            MyStatus sc = new MyStatus(client);
            sc.Owner = this;
            sc.Show();
        }

        private void signInPass_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
