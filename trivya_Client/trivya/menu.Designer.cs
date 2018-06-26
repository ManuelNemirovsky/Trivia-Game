namespace trivya
{
    partial class Menu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.signIn = new System.Windows.Forms.Button();
            this.signInUser = new System.Windows.Forms.TextBox();
            this.signInPass = new System.Windows.Forms.TextBox();
            this.labUserSignIn = new System.Windows.Forms.Label();
            this.labPassSignIn = new System.Windows.Forms.Label();
            this.createRoom = new System.Windows.Forms.Button();
            this.labHello = new System.Windows.Forms.Label();
            this.quit = new System.Windows.Forms.Button();
            this.scores = new System.Windows.Forms.Button();
            this.joinRoom = new System.Windows.Forms.Button();
            this.signUp = new System.Windows.Forms.Button();
            this.labErrSignIn = new System.Windows.Forms.Label();
            this.panel = new System.Windows.Forms.Panel();
            this.username = new System.Windows.Forms.Label();
            this.myStatus = new System.Windows.Forms.Button();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // signIn
            // 
            this.signIn.BackColor = System.Drawing.Color.White;
            this.signIn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.signIn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.signIn.FlatAppearance.BorderSize = 5;
            this.signIn.Font = new System.Drawing.Font("Matura MT Script Capitals", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signIn.Location = new System.Drawing.Point(498, 15);
            this.signIn.Name = "signIn";
            this.signIn.Size = new System.Drawing.Size(151, 54);
            this.signIn.TabIndex = 1;
            this.signIn.Text = "Sign in";
            this.signIn.UseVisualStyleBackColor = false;
            this.signIn.Click += new System.EventHandler(this.signIn_Click);
            // 
            // signInUser
            // 
            this.signInUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signInUser.Location = new System.Drawing.Point(123, 15);
            this.signInUser.Name = "signInUser";
            this.signInUser.Size = new System.Drawing.Size(369, 23);
            this.signInUser.TabIndex = 2;
            this.signInUser.Text = "user";
            // 
            // signInPass
            // 
            this.signInPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signInPass.Location = new System.Drawing.Point(123, 44);
            this.signInPass.Name = "signInPass";
            this.signInPass.Size = new System.Drawing.Size(369, 23);
            this.signInPass.TabIndex = 3;
            this.signInPass.Text = "Aa12";
            this.signInPass.TextChanged += new System.EventHandler(this.signInPass_TextChanged);
            // 
            // labUserSignIn
            // 
            this.labUserSignIn.AutoSize = true;
            this.labUserSignIn.Font = new System.Drawing.Font("Aharoni", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labUserSignIn.Location = new System.Drawing.Point(8, 15);
            this.labUserSignIn.Name = "labUserSignIn";
            this.labUserSignIn.Size = new System.Drawing.Size(110, 20);
            this.labUserSignIn.TabIndex = 4;
            this.labUserSignIn.Text = "User name";
            // 
            // labPassSignIn
            // 
            this.labPassSignIn.AutoSize = true;
            this.labPassSignIn.Font = new System.Drawing.Font("Aharoni", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labPassSignIn.Location = new System.Drawing.Point(8, 39);
            this.labPassSignIn.Name = "labPassSignIn";
            this.labPassSignIn.Size = new System.Drawing.Size(101, 20);
            this.labPassSignIn.TabIndex = 5;
            this.labPassSignIn.Text = "Password";
            // 
            // createRoom
            // 
            this.createRoom.BackColor = System.Drawing.Color.White;
            this.createRoom.Cursor = System.Windows.Forms.Cursors.Hand;
            this.createRoom.Enabled = false;
            this.createRoom.Font = new System.Drawing.Font("Matura MT Script Capitals", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createRoom.Location = new System.Drawing.Point(281, 395);
            this.createRoom.Name = "createRoom";
            this.createRoom.Size = new System.Drawing.Size(304, 50);
            this.createRoom.TabIndex = 6;
            this.createRoom.Text = "Create room";
            this.createRoom.UseVisualStyleBackColor = false;
            this.createRoom.Click += new System.EventHandler(this.createRoom_Click);
            // 
            // labHello
            // 
            this.labHello.AutoSize = true;
            this.labHello.Font = new System.Drawing.Font("Aharoni", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labHello.ForeColor = System.Drawing.Color.White;
            this.labHello.Location = new System.Drawing.Point(239, 24);
            this.labHello.Name = "labHello";
            this.labHello.Size = new System.Drawing.Size(157, 34);
            this.labHello.TabIndex = 8;
            this.labHello.Text = "Hello *****";
            this.labHello.Visible = false;
            // 
            // quit
            // 
            this.quit.BackColor = System.Drawing.Color.White;
            this.quit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.quit.Font = new System.Drawing.Font("Aharoni", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quit.ForeColor = System.Drawing.Color.DarkBlue;
            this.quit.Location = new System.Drawing.Point(387, 635);
            this.quit.Name = "quit";
            this.quit.Size = new System.Drawing.Size(88, 41);
            this.quit.TabIndex = 9;
            this.quit.Text = "quit";
            this.quit.UseVisualStyleBackColor = false;
            this.quit.Click += new System.EventHandler(this.quit_Click);
            // 
            // scores
            // 
            this.scores.BackColor = System.Drawing.Color.White;
            this.scores.Cursor = System.Windows.Forms.Cursors.Hand;
            this.scores.Enabled = false;
            this.scores.Font = new System.Drawing.Font("Matura MT Script Capitals", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scores.Location = new System.Drawing.Point(281, 560);
            this.scores.Name = "scores";
            this.scores.Size = new System.Drawing.Size(303, 50);
            this.scores.TabIndex = 10;
            this.scores.Text = "Best scores";
            this.scores.UseVisualStyleBackColor = false;
            this.scores.Click += new System.EventHandler(this.scores_Click);
            // 
            // joinRoom
            // 
            this.joinRoom.BackColor = System.Drawing.Color.White;
            this.joinRoom.Cursor = System.Windows.Forms.Cursors.Hand;
            this.joinRoom.Enabled = false;
            this.joinRoom.Font = new System.Drawing.Font("Matura MT Script Capitals", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.joinRoom.Location = new System.Drawing.Point(281, 316);
            this.joinRoom.Name = "joinRoom";
            this.joinRoom.Size = new System.Drawing.Size(303, 50);
            this.joinRoom.TabIndex = 11;
            this.joinRoom.Text = "Join room";
            this.joinRoom.UseVisualStyleBackColor = false;
            this.joinRoom.Click += new System.EventHandler(this.joinRoom_Click);
            // 
            // signUp
            // 
            this.signUp.BackColor = System.Drawing.Color.White;
            this.signUp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.signUp.Font = new System.Drawing.Font("Matura MT Script Capitals", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signUp.Location = new System.Drawing.Point(282, 242);
            this.signUp.Name = "signUp";
            this.signUp.Size = new System.Drawing.Size(303, 50);
            this.signUp.TabIndex = 13;
            this.signUp.Text = "Sign up";
            this.signUp.UseVisualStyleBackColor = false;
            this.signUp.Click += new System.EventHandler(this.signUp_Click);
            // 
            // labErrSignIn
            // 
            this.labErrSignIn.AutoSize = true;
            this.labErrSignIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labErrSignIn.ForeColor = System.Drawing.Color.Red;
            this.labErrSignIn.Location = new System.Drawing.Point(253, 77);
            this.labErrSignIn.Name = "labErrSignIn";
            this.labErrSignIn.Size = new System.Drawing.Size(77, 17);
            this.labErrSignIn.TabIndex = 20;
            this.labErrSignIn.Text = "some error";
            this.labErrSignIn.Visible = false;
            // 
            // panel
            // 
            this.panel.BackColor = System.Drawing.Color.White;
            this.panel.Controls.Add(this.labHello);
            this.panel.Controls.Add(this.signInPass);
            this.panel.Controls.Add(this.signInUser);
            this.panel.Controls.Add(this.labErrSignIn);
            this.panel.Controls.Add(this.signIn);
            this.panel.Controls.Add(this.labUserSignIn);
            this.panel.Controls.Add(this.labPassSignIn);
            this.panel.Location = new System.Drawing.Point(105, 136);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(660, 100);
            this.panel.TabIndex = 21;
            // 
            // username
            // 
            this.username.AutoSize = true;
            this.username.Font = new System.Drawing.Font("Aharoni", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.username.ForeColor = System.Drawing.Color.White;
            this.username.Location = new System.Drawing.Point(12, 9);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(138, 27);
            this.username.TabIndex = 22;
            this.username.Text = "username";
            this.username.Visible = false;
            // 
            // myStatus
            // 
            this.myStatus.BackColor = System.Drawing.Color.White;
            this.myStatus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.myStatus.Enabled = false;
            this.myStatus.Font = new System.Drawing.Font("Matura MT Script Capitals", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.myStatus.Location = new System.Drawing.Point(281, 475);
            this.myStatus.Name = "myStatus";
            this.myStatus.Size = new System.Drawing.Size(303, 50);
            this.myStatus.TabIndex = 23;
            this.myStatus.Text = "My status";
            this.myStatus.UseVisualStyleBackColor = false;
            this.myStatus.Click += new System.EventHandler(this.myStatus_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(867, 688);
            this.Controls.Add(this.myStatus);
            this.Controls.Add(this.username);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.joinRoom);
            this.Controls.Add(this.signUp);
            this.Controls.Add(this.scores);
            this.Controls.Add(this.quit);
            this.Controls.Add(this.createRoom);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "Menu";
            this.Text = "Menu";
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button signIn;
        private System.Windows.Forms.TextBox signInUser;
        private System.Windows.Forms.TextBox signInPass;
        private System.Windows.Forms.Label labUserSignIn;
        private System.Windows.Forms.Label labPassSignIn;
        private System.Windows.Forms.Button createRoom;
        private System.Windows.Forms.Label labHello;
        private System.Windows.Forms.Button quit;
        private System.Windows.Forms.Button scores;
        private System.Windows.Forms.Button joinRoom;
        private System.Windows.Forms.Button signUp;
        private System.Windows.Forms.Label labErrSignIn;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Label username;
        private System.Windows.Forms.Button myStatus;
    }
}

