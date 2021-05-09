namespace Client
{
    partial class loginAndSignup
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
            this.Exit = new System.Windows.Forms.Button();
            this.OUTPUT = new System.Windows.Forms.Label();
            this.password = new System.Windows.Forms.TextBox();
            this.username = new System.Windows.Forms.TextBox();
            this.toLogin = new System.Windows.Forms.Button();
            this.toSignup = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.showPassword = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Exit
            // 
            this.Exit.BackgroundImage = global::Client.Properties.Resources.EXIT;
            this.Exit.ImageKey = "(none)";
            this.Exit.Location = new System.Drawing.Point(435, 106);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(153, 45);
            this.Exit.TabIndex = 14;
            this.Exit.UseVisualStyleBackColor = true;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // OUTPUT
            // 
            this.OUTPUT.AutoSize = true;
            this.OUTPUT.BackColor = System.Drawing.Color.Transparent;
            this.OUTPUT.Location = new System.Drawing.Point(319, 22);
            this.OUTPUT.Name = "OUTPUT";
            this.OUTPUT.Size = new System.Drawing.Size(210, 13);
            this.OUTPUT.TabIndex = 13;
            this.OUTPUT.Text = "Welcome To Avi And Shahar Trivia Project";
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(89, 81);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(340, 20);
            this.password.TabIndex = 12;
            this.password.Text = "Password";
            this.password.UseSystemPasswordChar = true;
            this.password.Click += new System.EventHandler(this.password_Click);
            // 
            // username
            // 
            this.username.Location = new System.Drawing.Point(89, 55);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(340, 20);
            this.username.TabIndex = 11;
            this.username.Text = "Username";
            this.username.Click += new System.EventHandler(this.username_Click);
            // 
            // toLogin
            // 
            this.toLogin.Image = global::Client.Properties.Resources.Login;
            this.toLogin.Location = new System.Drawing.Point(435, 55);
            this.toLogin.Name = "toLogin";
            this.toLogin.Size = new System.Drawing.Size(153, 45);
            this.toLogin.TabIndex = 10;
            this.toLogin.UseVisualStyleBackColor = true;
            this.toLogin.Click += new System.EventHandler(this.toLogin_Click);
            // 
            // toSignup
            // 
            this.toSignup.Image = global::Client.Properties.Resources.SIGNUP;
            this.toSignup.Location = new System.Drawing.Point(265, 107);
            this.toSignup.Name = "toSignup";
            this.toSignup.Size = new System.Drawing.Size(153, 45);
            this.toSignup.TabIndex = 15;
            this.toSignup.UseVisualStyleBackColor = true;
            this.toSignup.Click += new System.EventHandler(this.toSignup_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Client.Properties.Resources.Untitled;
            this.pictureBox1.Location = new System.Drawing.Point(38, 55);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(45, 46);
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // showPassword
            // 
            this.showPassword.AutoSize = true;
            this.showPassword.Location = new System.Drawing.Point(89, 107);
            this.showPassword.Name = "showPassword";
            this.showPassword.Size = new System.Drawing.Size(102, 17);
            this.showPassword.TabIndex = 17;
            this.showPassword.Text = "Show Password";
            this.showPassword.UseVisualStyleBackColor = true;
            this.showPassword.CheckedChanged += new System.EventHandler(this.checkBox_ShowPassword);
            // 
            // loginAndSignup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Client.Properties.Resources.LoginPage;
            this.ClientSize = new System.Drawing.Size(812, 487);
            this.Controls.Add(this.showPassword);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.toSignup);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.OUTPUT);
            this.Controls.Add(this.password);
            this.Controls.Add(this.username);
            this.Controls.Add(this.toLogin);
            this.MaximumSize = new System.Drawing.Size(828, 526);
            this.MinimumSize = new System.Drawing.Size(828, 526);
            this.Name = "loginAndSignup";
            this.Text = "loginAndSignup";
            this.Enter += new System.EventHandler(this.toLogin_Click);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.Label OUTPUT;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.TextBox username;
        private System.Windows.Forms.Button toLogin;
        private System.Windows.Forms.Button toSignup;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox showPassword;
    }
}