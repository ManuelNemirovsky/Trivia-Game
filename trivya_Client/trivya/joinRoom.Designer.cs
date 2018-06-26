namespace trivya
{
    partial class JoinRoom
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JoinRoom));
            this.label1 = new System.Windows.Forms.Label();
            this.roomsList = new System.Windows.Forms.ListBox();
            this.playersHeader = new System.Windows.Forms.Label();
            this.playersList = new System.Windows.Forms.ListBox();
            this.join = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.available = new System.Windows.Forms.Label();
            this.errorLabel = new System.Windows.Forms.Label();
            this.back = new System.Windows.Forms.Button();
            this.refresh = new System.Windows.Forms.Button();
            this.username = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Aharoni", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(206, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 34);
            this.label1.TabIndex = 0;
            this.label1.Text = "Rooms list:";
            // 
            // roomsList
            // 
            this.roomsList.Font = new System.Drawing.Font("Aharoni", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roomsList.FormattingEnabled = true;
            this.roomsList.ItemHeight = 32;
            this.roomsList.Location = new System.Drawing.Point(67, 71);
            this.roomsList.Name = "roomsList";
            this.roomsList.Size = new System.Drawing.Size(460, 68);
            this.roomsList.TabIndex = 1;
            this.roomsList.SelectedIndexChanged += new System.EventHandler(this.roomsList_SelectedIndexChanged);
            // 
            // playersHeader
            // 
            this.playersHeader.AutoSize = true;
            this.playersHeader.Font = new System.Drawing.Font("Aharoni", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playersHeader.Location = new System.Drawing.Point(94, 185);
            this.playersHeader.Name = "playersHeader";
            this.playersHeader.Size = new System.Drawing.Size(380, 34);
            this.playersHeader.TabIndex = 2;
            this.playersHeader.Text = "Selected room players:";
            this.playersHeader.Visible = false;
            // 
            // playersList
            // 
            this.playersList.Font = new System.Drawing.Font("Aharoni", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playersList.FormattingEnabled = true;
            this.playersList.ItemHeight = 32;
            this.playersList.Location = new System.Drawing.Point(159, 231);
            this.playersList.Name = "playersList";
            this.playersList.Size = new System.Drawing.Size(232, 68);
            this.playersList.TabIndex = 3;
            this.playersList.Visible = false;
            // 
            // join
            // 
            this.join.BackColor = System.Drawing.Color.White;
            this.join.Enabled = false;
            this.join.Font = new System.Drawing.Font("Matura MT Script Capitals", 35F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.join.Location = new System.Drawing.Point(340, 584);
            this.join.Name = "join";
            this.join.Size = new System.Drawing.Size(205, 94);
            this.join.TabIndex = 5;
            this.join.Text = "Join";
            this.join.UseVisualStyleBackColor = false;
            this.join.Click += new System.EventHandler(this.join_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkRed;
            this.panel1.Controls.Add(this.available);
            this.panel1.Controls.Add(this.errorLabel);
            this.panel1.Controls.Add(this.playersList);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.roomsList);
            this.panel1.Controls.Add(this.playersHeader);
            this.panel1.Location = new System.Drawing.Point(138, 124);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(598, 362);
            this.panel1.TabIndex = 6;
            // 
            // available
            // 
            this.available.AutoSize = true;
            this.available.Font = new System.Drawing.Font("Aharoni", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.available.ForeColor = System.Drawing.Color.Red;
            this.available.Location = new System.Drawing.Point(197, 151);
            this.available.Name = "available";
            this.available.Size = new System.Drawing.Size(190, 20);
            this.available.TabIndex = 5;
            this.available.Text = "no available rooms";
            this.available.Visible = false;
            // 
            // errorLabel
            // 
            this.errorLabel.Font = new System.Drawing.Font("Aharoni", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorLabel.ForeColor = System.Drawing.Color.Red;
            this.errorLabel.Location = new System.Drawing.Point(3, 320);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(595, 20);
            this.errorLabel.TabIndex = 4;
            this.errorLabel.Text = "some error";
            this.errorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.errorLabel.Visible = false;
            // 
            // back
            // 
            this.back.BackColor = System.Drawing.Color.White;
            this.back.Font = new System.Drawing.Font("Aharoni", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.back.ForeColor = System.Drawing.Color.DarkBlue;
            this.back.Location = new System.Drawing.Point(780, 12);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(75, 34);
            this.back.TabIndex = 35;
            this.back.Text = "back";
            this.back.UseVisualStyleBackColor = false;
            this.back.Click += new System.EventHandler(this.back_Click);
            // 
            // refresh
            // 
            this.refresh.BackColor = System.Drawing.Color.White;
            this.refresh.Font = new System.Drawing.Font("Matura MT Script Capitals", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.refresh.Location = new System.Drawing.Point(367, 512);
            this.refresh.Name = "refresh";
            this.refresh.Size = new System.Drawing.Size(159, 55);
            this.refresh.TabIndex = 38;
            this.refresh.Text = "refresh";
            this.refresh.UseVisualStyleBackColor = false;
            this.refresh.Click += new System.EventHandler(this.refresh_Click);
            // 
            // username
            // 
            this.username.AutoSize = true;
            this.username.Font = new System.Drawing.Font("Aharoni", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.username.ForeColor = System.Drawing.Color.White;
            this.username.Location = new System.Drawing.Point(12, 12);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(138, 27);
            this.username.TabIndex = 39;
            this.username.Text = "username";
            // 
            // JoinRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(867, 688);
            this.Controls.Add(this.username);
            this.Controls.Add(this.refresh);
            this.Controls.Add(this.back);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.join);
            this.Name = "JoinRoom";
            this.Text = "Form4";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox roomsList;
        private System.Windows.Forms.Label playersHeader;
        private System.Windows.Forms.ListBox playersList;
        private System.Windows.Forms.Button join;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button back;
        private System.Windows.Forms.Label errorLabel;
        private System.Windows.Forms.Label available;
        private System.Windows.Forms.Button refresh;
        private System.Windows.Forms.Label username;
    }
}