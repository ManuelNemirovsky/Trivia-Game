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
    public partial class MyStatus : Form
    {
        Client client;
        public MyStatus(Client cl)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            client = cl;
            username.Text = client.myName;

            double[] myStatus = client.getMyStatus();
            string[] strings = { "number of games", "number of right answers", "numer of wrong answers", "average time for answer" };
            userData.Text = "";
            for (int i = 0; i < 4; i++)
            {
                userData.Text += strings[i] + " - " + myStatus[i].ToString() + "\n";
            }



        }

        private void back_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }

        private void MyStatus_Load(object sender, EventArgs e)
        {

        }
    }
}
