namespace trivya
{
    partial class WaitForGame
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WaitForGame));
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.header = new System.Windows.Forms.Label();
            this.playersList = new System.Windows.Forms.ListBox();
            this.startGame = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.roomDetails = new System.Windows.Forms.Label();
            this.err = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.leaveRoom = new System.Windows.Forms.Button();
            this.username = new System.Windows.Forms.Label();
            this.roomName = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Aharoni", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(833, 1231);
            this.label2.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(330, 34);
            this.label2.TabIndex = 5;
            this.label2.Text = "Waiting for admin...";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.Font = new System.Drawing.Font("Matura MT Script Capitals", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(1007, 1456);
            this.button2.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(621, 140);
            this.button2.TabIndex = 6;
            this.button2.Text = "Start game";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // header
            // 
            this.header.AutoSize = true;
            this.header.Font = new System.Drawing.Font("Aharoni", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.header.ForeColor = System.Drawing.Color.Blue;
            this.header.Location = new System.Drawing.Point(28, 14);
            this.header.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.header.Name = "header";
            this.header.Size = new System.Drawing.Size(587, 39);
            this.header.TabIndex = 7;
            this.header.Text = "You are connected to room ****";
            // 
            // playersList
            // 
            this.playersList.Font = new System.Drawing.Font("Aharoni", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playersList.FormattingEnabled = true;
            this.playersList.ItemHeight = 20;
            this.playersList.Location = new System.Drawing.Point(253, 137);
            this.playersList.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.playersList.Name = "playersList";
            this.playersList.Size = new System.Drawing.Size(315, 124);
            this.playersList.TabIndex = 8;
            // 
            // startGame
            // 
            this.startGame.BackColor = System.Drawing.Color.White;
            this.startGame.Font = new System.Drawing.Font("Matura MT Script Capitals", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startGame.Location = new System.Drawing.Point(303, 590);
            this.startGame.Name = "startGame";
            this.startGame.Size = new System.Drawing.Size(249, 63);
            this.startGame.TabIndex = 9;
            this.startGame.Text = "Start Game";
            this.startGame.UseVisualStyleBackColor = false;
            this.startGame.Visible = false;
            this.startGame.Click += new System.EventHandler(this.startGame_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.roomDetails);
            this.panel1.Controls.Add(this.err);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.header);
            this.panel1.Controls.Add(this.playersList);
            this.panel1.Location = new System.Drawing.Point(17, 163);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(827, 321);
            this.panel1.TabIndex = 10;
            // 
            // roomDetails
            // 
            this.roomDetails.Font = new System.Drawing.Font("Aharoni", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roomDetails.ForeColor = System.Drawing.Color.Red;
            this.roomDetails.Location = new System.Drawing.Point(3, 53);
            this.roomDetails.Name = "roomDetails";
            this.roomDetails.Size = new System.Drawing.Size(824, 20);
            this.roomDetails.TabIndex = 11;
            this.roomDetails.Text = "room details";
            this.roomDetails.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // err
            // 
            this.err.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.err.ForeColor = System.Drawing.Color.Red;
            this.err.Location = new System.Drawing.Point(12, 287);
            this.err.Name = "err";
            this.err.Size = new System.Drawing.Size(816, 25);
            this.err.TabIndex = 10;
            this.err.Text = "error massage";
            this.err.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.err.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Aharoni", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(247, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(321, 27);
            this.label1.TabIndex = 9;
            this.label1.Text = "Current participants are:";
            // 
            // leaveRoom
            // 
            this.leaveRoom.BackColor = System.Drawing.Color.White;
            this.leaveRoom.Font = new System.Drawing.Font("Matura MT Script Capitals", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.leaveRoom.Location = new System.Drawing.Point(311, 513);
            this.leaveRoom.Name = "leaveRoom";
            this.leaveRoom.Size = new System.Drawing.Size(230, 53);
            this.leaveRoom.TabIndex = 11;
            this.leaveRoom.Text = "Leave room";
            this.leaveRoom.UseVisualStyleBackColor = false;
            this.leaveRoom.Click += new System.EventHandler(this.leaveRoom_Click);
            // 
            // username
            // 
            this.username.AutoSize = true;
            this.username.Font = new System.Drawing.Font("Aharoni", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.username.ForeColor = System.Drawing.Color.White;
            this.username.Location = new System.Drawing.Point(12, 9);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(138, 27);
            this.username.TabIndex = 42;
            this.username.Text = "username";
            // 
            // roomName
            // 
            this.roomName.AutoSize = true;
            this.roomName.Font = new System.Drawing.Font("Aharoni", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roomName.ForeColor = System.Drawing.Color.White;
            this.roomName.Location = new System.Drawing.Point(368, 104);
            this.roomName.Name = "roomName";
            this.roomName.Size = new System.Drawing.Size(159, 27);
            this.roomName.TabIndex = 47;
            this.roomName.Text = "roomName";
            // 
            // WaitForGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(19F, 38F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(867, 688);
            this.Controls.Add(this.roomName);
            this.Controls.Add(this.username);
            this.Controls.Add(this.leaveRoom);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.startGame);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.Name = "WaitForGame";
            this.Text = "WaitForGame";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label header;
        private System.Windows.Forms.ListBox playersList;
        private System.Windows.Forms.Button startGame;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button leaveRoom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label err;
        private System.Windows.Forms.Label username;
        private System.Windows.Forms.Label roomName;
        private System.Windows.Forms.Label roomDetails;

    }
}