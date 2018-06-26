namespace trivya
{
    partial class CreateRoom
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateRoom));
            this.label1 = new System.Windows.Forms.Label();
            this.roomName = new System.Windows.Forms.TextBox();
            this.send = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.errorLabel = new System.Windows.Forms.Label();
            this.numberOfQuestions = new System.Windows.Forms.TextBox();
            this.labNumQ = new System.Windows.Forms.Label();
            this.time = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.numberOfPlayers = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.back = new System.Windows.Forms.Button();
            this.username = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Aharoni", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "room name";
            // 
            // roomName
            // 
            this.roomName.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.roomName.Location = new System.Drawing.Point(281, 11);
            this.roomName.Name = "roomName";
            this.roomName.Size = new System.Drawing.Size(344, 38);
            this.roomName.TabIndex = 1;
            this.roomName.Text = "room_name";
            // 
            // send
            // 
            this.send.BackColor = System.Drawing.Color.White;
            this.send.Font = new System.Drawing.Font("Matura MT Script Capitals", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.send.Location = new System.Drawing.Point(393, 490);
            this.send.Name = "send";
            this.send.Size = new System.Drawing.Size(128, 47);
            this.send.TabIndex = 2;
            this.send.Text = "Send";
            this.send.UseVisualStyleBackColor = false;
            this.send.Click += new System.EventHandler(this.send_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.errorLabel);
            this.panel1.Controls.Add(this.numberOfQuestions);
            this.panel1.Controls.Add(this.labNumQ);
            this.panel1.Controls.Add(this.time);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.numberOfPlayers);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.roomName);
            this.panel1.Location = new System.Drawing.Point(97, 164);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(674, 288);
            this.panel1.TabIndex = 6;
            // 
            // errorLabel
            // 
            this.errorLabel.AutoSize = true;
            this.errorLabel.Font = new System.Drawing.Font("Aharoni", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorLabel.ForeColor = System.Drawing.Color.Red;
            this.errorLabel.Location = new System.Drawing.Point(277, 253);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(112, 20);
            this.errorLabel.TabIndex = 10;
            this.errorLabel.Text = "some error";
            this.errorLabel.Visible = false;
            // 
            // numberOfQuestions
            // 
            this.numberOfQuestions.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.numberOfQuestions.Location = new System.Drawing.Point(281, 124);
            this.numberOfQuestions.Name = "numberOfQuestions";
            this.numberOfQuestions.Size = new System.Drawing.Size(344, 38);
            this.numberOfQuestions.TabIndex = 9;
            this.numberOfQuestions.Text = "5";
            // 
            // labNumQ
            // 
            this.labNumQ.AutoSize = true;
            this.labNumQ.Font = new System.Drawing.Font("Aharoni", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labNumQ.Location = new System.Drawing.Point(3, 133);
            this.labNumQ.Name = "labNumQ";
            this.labNumQ.Size = new System.Drawing.Size(272, 27);
            this.labNumQ.TabIndex = 8;
            this.labNumQ.Text = "number of questions";
            // 
            // time
            // 
            this.time.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.time.Location = new System.Drawing.Point(281, 182);
            this.time.Name = "time";
            this.time.Size = new System.Drawing.Size(344, 38);
            this.time.TabIndex = 7;
            this.time.Text = "4";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Aharoni", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 191);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(227, 27);
            this.label5.TabIndex = 6;
            this.label5.Text = "time for question";
            // 
            // numberOfPlayers
            // 
            this.numberOfPlayers.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.numberOfPlayers.Location = new System.Drawing.Point(281, 64);
            this.numberOfPlayers.Name = "numberOfPlayers";
            this.numberOfPlayers.Size = new System.Drawing.Size(344, 38);
            this.numberOfPlayers.TabIndex = 5;
            this.numberOfPlayers.Text = "3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Aharoni", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(246, 27);
            this.label4.TabIndex = 4;
            this.label4.Text = "number of players";
            // 
            // back
            // 
            this.back.BackColor = System.Drawing.Color.White;
            this.back.Font = new System.Drawing.Font("Aharoni", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.back.ForeColor = System.Drawing.Color.DarkBlue;
            this.back.Location = new System.Drawing.Point(780, 11);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(75, 34);
            this.back.TabIndex = 38;
            this.back.Text = "back";
            this.back.UseVisualStyleBackColor = false;
            this.back.Click += new System.EventHandler(this.back_Click);
            // 
            // username
            // 
            this.username.AutoSize = true;
            this.username.Font = new System.Drawing.Font("Aharoni", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.username.ForeColor = System.Drawing.Color.White;
            this.username.Location = new System.Drawing.Point(12, 13);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(138, 27);
            this.username.TabIndex = 41;
            this.username.Text = "username";
            // 
            // CreateRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(867, 688);
            this.Controls.Add(this.username);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.back);
            this.Controls.Add(this.send);
            this.Name = "CreateRoom";
            this.Text = "Create room";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox roomName;
        private System.Windows.Forms.Button send;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button back;
        private System.Windows.Forms.TextBox time;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox numberOfPlayers;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox numberOfQuestions;
        private System.Windows.Forms.Label labNumQ;
        private System.Windows.Forms.Label errorLabel;
        private System.Windows.Forms.Label username;
    }
}