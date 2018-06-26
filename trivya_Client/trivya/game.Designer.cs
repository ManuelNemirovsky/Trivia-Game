namespace trivya
{
    partial class Game
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Game));
            this.labQues = new System.Windows.Forms.Label();
            this.ans1 = new System.Windows.Forms.Button();
            this.ans2 = new System.Windows.Forms.Button();
            this.ans3 = new System.Windows.Forms.Button();
            this.ans4 = new System.Windows.Forms.Button();
            this.questionNumber = new System.Windows.Forms.Label();
            this.exit = new System.Windows.Forms.Button();
            this.score = new System.Windows.Forms.Label();
            this.timeLeft = new System.Windows.Forms.Label();
            this.username = new System.Windows.Forms.Label();
            this.roomName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labQues
            // 
            this.labQues.AutoSize = true;
            this.labQues.BackColor = System.Drawing.Color.White;
            this.labQues.Font = new System.Drawing.Font("Aharoni", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labQues.ForeColor = System.Drawing.Color.DarkBlue;
            this.labQues.Location = new System.Drawing.Point(173, 204);
            this.labQues.Name = "labQues";
            this.labQues.Size = new System.Drawing.Size(624, 27);
            this.labQues.TabIndex = 0;
            this.labQues.Text = "What is the best course in Magshimim program?";
            // 
            // ans1
            // 
            this.ans1.BackColor = System.Drawing.Color.White;
            this.ans1.Font = new System.Drawing.Font("Aharoni", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ans1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ans1.Location = new System.Drawing.Point(123, 267);
            this.ans1.Name = "ans1";
            this.ans1.Size = new System.Drawing.Size(619, 50);
            this.ans1.TabIndex = 1;
            this.ans1.Text = "Advanced Programming ";
            this.ans1.UseVisualStyleBackColor = false;
            this.ans1.Click += new System.EventHandler(this.ans_Click);
            // 
            // ans2
            // 
            this.ans2.BackColor = System.Drawing.Color.White;
            this.ans2.Font = new System.Drawing.Font("Aharoni", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ans2.Location = new System.Drawing.Point(123, 349);
            this.ans2.Name = "ans2";
            this.ans2.Size = new System.Drawing.Size(619, 48);
            this.ans2.TabIndex = 2;
            this.ans2.Text = "Intorduction to programming C";
            this.ans2.UseVisualStyleBackColor = false;
            this.ans2.Click += new System.EventHandler(this.ans_Click);
            // 
            // ans3
            // 
            this.ans3.BackColor = System.Drawing.Color.White;
            this.ans3.Font = new System.Drawing.Font("Aharoni", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ans3.Location = new System.Drawing.Point(123, 438);
            this.ans3.Name = "ans3";
            this.ans3.Size = new System.Drawing.Size(619, 51);
            this.ans3.TabIndex = 3;
            this.ans3.Text = "Introduction to computers";
            this.ans3.UseVisualStyleBackColor = false;
            this.ans3.Click += new System.EventHandler(this.ans_Click);
            // 
            // ans4
            // 
            this.ans4.BackColor = System.Drawing.Color.White;
            this.ans4.Font = new System.Drawing.Font("Aharoni", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ans4.Location = new System.Drawing.Point(123, 521);
            this.ans4.Name = "ans4";
            this.ans4.Size = new System.Drawing.Size(619, 52);
            this.ans4.TabIndex = 4;
            this.ans4.Text = "Networks";
            this.ans4.UseVisualStyleBackColor = false;
            this.ans4.Click += new System.EventHandler(this.ans_Click);
            // 
            // questionNumber
            // 
            this.questionNumber.AutoSize = true;
            this.questionNumber.Font = new System.Drawing.Font("Aharoni", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.questionNumber.ForeColor = System.Drawing.Color.White;
            this.questionNumber.Location = new System.Drawing.Point(349, 155);
            this.questionNumber.Name = "questionNumber";
            this.questionNumber.Size = new System.Drawing.Size(196, 28);
            this.questionNumber.TabIndex = 7;
            this.questionNumber.Text = "Question: 3\\10";
            // 
            // exit
            // 
            this.exit.BackColor = System.Drawing.Color.Red;
            this.exit.Cursor = System.Windows.Forms.Cursors.Default;
            this.exit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.exit.Font = new System.Drawing.Font("Aharoni", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exit.Location = new System.Drawing.Point(780, 12);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(75, 23);
            this.exit.TabIndex = 9;
            this.exit.Text = "Exit Game";
            this.exit.UseVisualStyleBackColor = false;
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // score
            // 
            this.score.AutoSize = true;
            this.score.Font = new System.Drawing.Font("Aharoni", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.score.ForeColor = System.Drawing.Color.White;
            this.score.Location = new System.Drawing.Point(388, 641);
            this.score.Name = "score";
            this.score.Size = new System.Drawing.Size(137, 28);
            this.score.TabIndex = 6;
            this.score.Text = "Score: 2\\3";
            // 
            // timeLeft
            // 
            this.timeLeft.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.timeLeft.Font = new System.Drawing.Font("Aharoni", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeLeft.ForeColor = System.Drawing.Color.White;
            this.timeLeft.Location = new System.Drawing.Point(440, 599);
            this.timeLeft.Name = "timeLeft";
            this.timeLeft.Size = new System.Drawing.Size(40, 28);
            this.timeLeft.TabIndex = 44;
            this.timeLeft.Text = "10";
            // 
            // username
            // 
            this.username.AutoSize = true;
            this.username.Font = new System.Drawing.Font("Aharoni", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.username.ForeColor = System.Drawing.Color.White;
            this.username.Location = new System.Drawing.Point(12, 12);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(138, 27);
            this.username.TabIndex = 45;
            this.username.Text = "username";
            // 
            // roomName
            // 
            this.roomName.AutoSize = true;
            this.roomName.Font = new System.Drawing.Font("Aharoni", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roomName.ForeColor = System.Drawing.Color.White;
            this.roomName.Location = new System.Drawing.Point(366, 104);
            this.roomName.Name = "roomName";
            this.roomName.Size = new System.Drawing.Size(159, 27);
            this.roomName.TabIndex = 46;
            this.roomName.Text = "roomName";
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(867, 688);
            this.Controls.Add(this.roomName);
            this.Controls.Add(this.username);
            this.Controls.Add(this.timeLeft);
            this.Controls.Add(this.score);
            this.Controls.Add(this.questionNumber);
            this.Controls.Add(this.exit);
            this.Controls.Add(this.ans4);
            this.Controls.Add(this.ans3);
            this.Controls.Add(this.ans2);
            this.Controls.Add(this.ans1);
            this.Controls.Add(this.labQues);
            this.Name = "Game";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labQues;
        private System.Windows.Forms.Button ans1;
        private System.Windows.Forms.Button ans2;
        private System.Windows.Forms.Button ans3;
        private System.Windows.Forms.Button ans4;
        private System.Windows.Forms.Label questionNumber;
        private System.Windows.Forms.Button exit;
        private System.Windows.Forms.Label score;
        private System.Windows.Forms.Label timeLeft;
        private System.Windows.Forms.Label username;
        private System.Windows.Forms.Label roomName;
    }
}