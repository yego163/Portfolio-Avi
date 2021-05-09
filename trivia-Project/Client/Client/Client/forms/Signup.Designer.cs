namespace Client
{
    partial class Signup
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
            this.email = new System.Windows.Forms.TextBox();
            this.Password = new System.Windows.Forms.TextBox();
            this.Username = new System.Windows.Forms.TextBox();
            this.SignupButton = new System.Windows.Forms.Button();
            this.OUTPUT = new System.Windows.Forms.Label();
            this.ShowPassword = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // email
            // 
            this.email.Location = new System.Drawing.Point(12, 135);
            this.email.Name = "email";
            this.email.Size = new System.Drawing.Size(340, 20);
            this.email.TabIndex = 22;
            this.email.Text = "email@gmail.com";
            this.email.Click += new System.EventHandler(this.email_Click);
            // 
            // Password
            // 
            this.Password.Location = new System.Drawing.Point(12, 109);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(340, 20);
            this.Password.TabIndex = 21;
            this.Password.Text = "Password";
            this.Password.UseSystemPasswordChar = true;
            this.Password.Click += new System.EventHandler(this.Password_Click);
            // 
            // Username
            // 
            this.Username.Location = new System.Drawing.Point(12, 84);
            this.Username.Name = "Username";
            this.Username.Size = new System.Drawing.Size(340, 20);
            this.Username.TabIndex = 20;
            this.Username.Text = "Username";
            this.Username.Click += new System.EventHandler(this.Username_Click);
            // 
            // SignupButton
            // 
            this.SignupButton.BackColor = System.Drawing.Color.Transparent;
            this.SignupButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.SignupButton.FlatAppearance.BorderSize = 6;
            this.SignupButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SignupButton.Font = new System.Drawing.Font("a Absolute Empire", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SignupButton.ForeColor = System.Drawing.Color.Black;
            this.SignupButton.Location = new System.Drawing.Point(12, 161);
            this.SignupButton.Name = "SignupButton";
            this.SignupButton.Size = new System.Drawing.Size(154, 41);
            this.SignupButton.TabIndex = 19;
            this.SignupButton.Text = "Signup";
            this.SignupButton.UseVisualStyleBackColor = false;
            this.SignupButton.Click += new System.EventHandler(this.SignupButton_Click);
            // 
            // OUTPUT
            // 
            this.OUTPUT.AutoSize = true;
            this.OUTPUT.Location = new System.Drawing.Point(13, 65);
            this.OUTPUT.Name = "OUTPUT";
            this.OUTPUT.Size = new System.Drawing.Size(0, 13);
            this.OUTPUT.TabIndex = 23;
            // 
            // ShowPassword
            // 
            this.ShowPassword.AutoSize = true;
            this.ShowPassword.Location = new System.Drawing.Point(172, 161);
            this.ShowPassword.Name = "ShowPassword";
            this.ShowPassword.Size = new System.Drawing.Size(102, 17);
            this.ShowPassword.TabIndex = 24;
            this.ShowPassword.Text = "Show Password";
            this.ShowPassword.UseVisualStyleBackColor = true;
            this.ShowPassword.CheckedChanged += new System.EventHandler(this.ShowPassword_CheckedChanged);
            // 
            // Signup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Client.Properties.Resources.NewSignUp;
            this.ClientSize = new System.Drawing.Size(800, 487);
            this.Controls.Add(this.ShowPassword);
            this.Controls.Add(this.OUTPUT);
            this.Controls.Add(this.email);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.Username);
            this.Controls.Add(this.SignupButton);
            this.Cursor = System.Windows.Forms.Cursors.PanWest;
            this.MaximumSize = new System.Drawing.Size(816, 526);
            this.MinimumSize = new System.Drawing.Size(816, 526);
            this.Name = "Signup";
            this.Text = "Signup";
            this.Enter += new System.EventHandler(this.SignupButton_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox email;
        private System.Windows.Forms.TextBox Password;
        private System.Windows.Forms.TextBox Username;
        private System.Windows.Forms.Button SignupButton;
        private System.Windows.Forms.Label OUTPUT;
        private System.Windows.Forms.CheckBox ShowPassword;
    }
}