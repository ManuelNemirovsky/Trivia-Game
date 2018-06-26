namespace trivya
{
    partial class SignUp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SignUp));
            this.labResSignUp = new System.Windows.Forms.Label();
            this.labEmail = new System.Windows.Forms.Label();
            this.Email = new System.Windows.Forms.TextBox();
            this.labPass = new System.Windows.Forms.Label();
            this.labUser = new System.Windows.Forms.Label();
            this.Pass = new System.Windows.Forms.TextBox();
            this.User = new System.Windows.Forms.TextBox();
            this.ok = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.back = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labResSignUp
            // 
            this.labResSignUp.AutoSize = true;
            this.labResSignUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labResSignUp.ForeColor = System.Drawing.Color.Red;
            this.labResSignUp.Location = new System.Drawing.Point(229, 135);
            this.labResSignUp.Name = "labResSignUp";
            this.labResSignUp.Size = new System.Drawing.Size(127, 25);
            this.labResSignUp.TabIndex = 28;
            this.labResSignUp.Text = "sign up result";
            this.labResSignUp.Visible = false;
            // 
            // labEmail
            // 
            this.labEmail.AutoSize = true;
            this.labEmail.Font = new System.Drawing.Font("Aharoni", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labEmail.Location = new System.Drawing.Point(11, 102);
            this.labEmail.Name = "labEmail";
            this.labEmail.Size = new System.Drawing.Size(82, 27);
            this.labEmail.TabIndex = 27;
            this.labEmail.Text = "email";
            // 
            // Email
            // 
            this.Email.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Email.Location = new System.Drawing.Point(157, 102);
            this.Email.Name = "Email";
            this.Email.Size = new System.Drawing.Size(383, 30);
            this.Email.TabIndex = 26;
            this.Email.Text = "user@gmail.com";
            // 
            // labPass
            // 
            this.labPass.AutoSize = true;
            this.labPass.Font = new System.Drawing.Font("Aharoni", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labPass.Location = new System.Drawing.Point(11, 56);
            this.labPass.Name = "labPass";
            this.labPass.Size = new System.Drawing.Size(138, 27);
            this.labPass.TabIndex = 25;
            this.labPass.Text = "Password";
            // 
            // labUser
            // 
            this.labUser.AutoSize = true;
            this.labUser.Font = new System.Drawing.Font("Aharoni", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labUser.Location = new System.Drawing.Point(11, 20);
            this.labUser.Name = "labUser";
            this.labUser.Size = new System.Drawing.Size(148, 27);
            this.labUser.TabIndex = 24;
            this.labUser.Text = "User name";
            // 
            // Pass
            // 
            this.Pass.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Pass.Location = new System.Drawing.Point(157, 56);
            this.Pass.Name = "Pass";
            this.Pass.Size = new System.Drawing.Size(383, 30);
            this.Pass.TabIndex = 23;
            this.Pass.Text = "Aa12";
            this.Pass.TextChanged += new System.EventHandler(this.ok_Click);
            // 
            // User
            // 
            this.User.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.User.Location = new System.Drawing.Point(157, 20);
            this.User.Name = "User";
            this.User.Size = new System.Drawing.Size(383, 30);
            this.User.TabIndex = 22;
            this.User.Text = "user";
            // 
            // ok
            // 
            this.ok.BackColor = System.Drawing.Color.White;
            this.ok.Font = new System.Drawing.Font("Matura MT Script Capitals", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ok.Location = new System.Drawing.Point(393, 401);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(129, 58);
            this.ok.TabIndex = 30;
            this.ok.Text = "OK";
            this.ok.UseVisualStyleBackColor = false;
            this.ok.Click += new System.EventHandler(this.ok_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.Pass);
            this.panel1.Controls.Add(this.User);
            this.panel1.Controls.Add(this.labUser);
            this.panel1.Controls.Add(this.labResSignUp);
            this.panel1.Controls.Add(this.labPass);
            this.panel1.Controls.Add(this.labEmail);
            this.panel1.Controls.Add(this.Email);
            this.panel1.Location = new System.Drawing.Point(166, 178);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(559, 164);
            this.panel1.TabIndex = 31;
            // 
            // back
            // 
            this.back.BackColor = System.Drawing.Color.White;
            this.back.Font = new System.Drawing.Font("Aharoni", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.back.ForeColor = System.Drawing.Color.DarkBlue;
            this.back.Location = new System.Drawing.Point(780, 12);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(75, 34);
            this.back.TabIndex = 34;
            this.back.Text = "back";
            this.back.UseVisualStyleBackColor = false;
            this.back.Click += new System.EventHandler(this.back_Click);
            // 
            // SignUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(867, 688);
            this.Controls.Add(this.back);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ok);
            this.Name = "SignUp";
            this.Text = "signUp";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labResSignUp;
        private System.Windows.Forms.Label labEmail;
        private System.Windows.Forms.TextBox Email;
        private System.Windows.Forms.Label labPass;
        private System.Windows.Forms.Label labUser;
        private System.Windows.Forms.TextBox Pass;
        private System.Windows.Forms.TextBox User;
        private System.Windows.Forms.Button ok;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button back;
    }
}