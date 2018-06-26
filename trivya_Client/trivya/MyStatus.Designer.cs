namespace trivya
{
    partial class MyStatus
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MyStatus));
            this.username = new System.Windows.Forms.Label();
            this.back = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.userData = new System.Windows.Forms.Label();
            this.playersHeader = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // username
            // 
            this.username.AutoSize = true;
            this.username.Font = new System.Drawing.Font("Aharoni", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.username.ForeColor = System.Drawing.Color.White;
            this.username.Location = new System.Drawing.Point(11, 10);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(138, 27);
            this.username.TabIndex = 47;
            this.username.Text = "username";
            // 
            // back
            // 
            this.back.BackColor = System.Drawing.Color.White;
            this.back.Font = new System.Drawing.Font("Aharoni", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.back.ForeColor = System.Drawing.Color.DarkBlue;
            this.back.Location = new System.Drawing.Point(756, 10);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(75, 34);
            this.back.TabIndex = 44;
            this.back.Text = "back";
            this.back.UseVisualStyleBackColor = false;
            this.back.Click += new System.EventHandler(this.back_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.userData);
            this.panel1.Controls.Add(this.playersHeader);
            this.panel1.Location = new System.Drawing.Point(34, 126);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(797, 466);
            this.panel1.TabIndex = 43;
            // 
            // userData
            // 
            this.userData.Font = new System.Drawing.Font("Aharoni", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userData.Location = new System.Drawing.Point(0, 106);
            this.userData.Name = "userData";
            this.userData.Size = new System.Drawing.Size(797, 209);
            this.userData.TabIndex = 4;
            this.userData.Text = "user data";
            this.userData.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // playersHeader
            // 
            this.playersHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.playersHeader.Font = new System.Drawing.Font("Aharoni", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playersHeader.Location = new System.Drawing.Point(3, 25);
            this.playersHeader.Name = "playersHeader";
            this.playersHeader.Size = new System.Drawing.Size(794, 39);
            this.playersHeader.TabIndex = 2;
            this.playersHeader.Text = "My performances:";
            this.playersHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MyStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(867, 688);
            this.Controls.Add(this.username);
            this.Controls.Add(this.back);
            this.Controls.Add(this.panel1);
            this.Name = "MyStatus";
            this.Text = "MyStatus";
            this.Load += new System.EventHandler(this.MyStatus_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label username;
        private System.Windows.Forms.Button back;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label userData;
        private System.Windows.Forms.Label playersHeader;
    }
}