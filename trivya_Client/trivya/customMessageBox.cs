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
    public partial class CustomMessageBox : Form
    {

        public CustomMessageBox()
        {
            InitializeComponent();

        }
        static CustomMessageBox msgBox;

        public static void Show(string msg, string caption)
        {
            msgBox = new CustomMessageBox();
            msgBox.StartPosition = FormStartPosition.CenterScreen;
            msgBox.label1.Text = msg;
            msgBox.label1.TextAlign = ContentAlignment.MiddleCenter;
            msgBox.AutoSize = true;
            msgBox.Text = caption;
            msgBox.button1.Dock = DockStyle.Bottom;

            msgBox.tableLayoutPanel.Left = (msgBox.ClientSize.Width - msgBox.tableLayoutPanel.Width) / 2;
            msgBox.tableLayoutPanel.Top = (msgBox.ClientSize.Height - msgBox.tableLayoutPanel.Height) / 2;

            msgBox.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;

            msgBox.ShowDialog();
            msgBox.BringToFront();

        }



        private void button1_Click(object sender, EventArgs e)
        {
            msgBox.Close();
        }
    }
}
