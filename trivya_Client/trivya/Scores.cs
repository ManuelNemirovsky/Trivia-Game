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
    public partial class Scores : Form
    {
        Client client;
        public Scores(Client cl)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            client = cl;
            username.Text = client.myName;
            string[] best = client.geBestScores();
            bestScores.Text = "";
            for (int i = 0; i < 6; i += 2)
            {
                bestScores.Text += best[i] + " - " + Int32.Parse(best[i + 1]).ToString() + "\n\n";
            }
           
        }

        private void back_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }
    }
}
