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
    public partial class SignUp : Form
    {
        Client client;
        public SignUp(Client cl)
        {
            client = cl;
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            
        }
        private void ok_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(User.Text) || String.IsNullOrEmpty(Pass.Text) || String.IsNullOrEmpty(Email.Text))
            {
                labResSignUp.Text = "Please fill all fields";
                labResSignUp.Visible = true;
            }
            else
            {
                labResSignUp.Text = client.signUp(User.Text, Pass.Text, Email.Text);
                labResSignUp.Visible = true;
                if (String.Compare(labResSignUp.Text, "Success") == 0)
                {
                    this.Owner.Show();
                    this.Close();
                }
            }
            return;
        }
        private void back_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Close();

        }
    }
}
