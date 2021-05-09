namespace Client
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
            this.BackButton = new System.Windows.Forms.Button();
            this.CreateButton = new System.Windows.Forms.Button();
            this.RoomName = new System.Windows.Forms.TextBox();
            this.NumOfPlayers = new System.Windows.Forms.TextBox();
            this.NumOfQuestions = new System.Windows.Forms.TextBox();
            this.TimeForQeustion = new System.Windows.Forms.TextBox();
            this.ErrorTextBox = new System.Windows.Forms.Label();
            this.RoomNameLabel = new System.Windows.Forms.Label();
            this.NumOfPlayersLabel = new System.Windows.Forms.Label();
            this.NumOfQuestionsLabel = new System.Windows.Forms.Label();
            this.TimeForQeustionLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BackButton
            // 
            this.BackButton.BackColor = System.Drawing.Color.Transparent;
            this.BackButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BackButton.Font = new System.Drawing.Font("Sitka Small", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BackButton.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.BackButton.Location = new System.Drawing.Point(12, 12);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(75, 34);
            this.BackButton.TabIndex = 4;
            this.BackButton.Text = "Back";
            this.BackButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BackButton.UseVisualStyleBackColor = false;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // CreateButton
            // 
            this.CreateButton.BackColor = System.Drawing.Color.Transparent;
            this.CreateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CreateButton.Font = new System.Drawing.Font("Sitka Small", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateButton.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.CreateButton.Location = new System.Drawing.Point(400, 153);
            this.CreateButton.Name = "CreateButton";
            this.CreateButton.Size = new System.Drawing.Size(67, 34);
            this.CreateButton.TabIndex = 5;
            this.CreateButton.Text = "Create";
            this.CreateButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CreateButton.UseVisualStyleBackColor = false;
            this.CreateButton.Click += new System.EventHandler(this.CreateButton_Click);
            // 
            // RoomName
            // 
            this.RoomName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.RoomName.Location = new System.Drawing.Point(24, 91);
            this.RoomName.Multiline = true;
            this.RoomName.Name = "RoomName";
            this.RoomName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.RoomName.Size = new System.Drawing.Size(192, 33);
            this.RoomName.TabIndex = 0;
            this.RoomName.Text = "Room1";
            this.RoomName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // NumOfPlayers
            // 
            this.NumOfPlayers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.NumOfPlayers.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.NumOfPlayers.Location = new System.Drawing.Point(230, 91);
            this.NumOfPlayers.Multiline = true;
            this.NumOfPlayers.Name = "NumOfPlayers";
            this.NumOfPlayers.Size = new System.Drawing.Size(192, 33);
            this.NumOfPlayers.TabIndex = 1;
            this.NumOfPlayers.Text = "5";
            this.NumOfPlayers.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // NumOfQuestions
            // 
            this.NumOfQuestions.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.NumOfQuestions.Location = new System.Drawing.Point(440, 91);
            this.NumOfQuestions.Multiline = true;
            this.NumOfQuestions.Name = "NumOfQuestions";
            this.NumOfQuestions.Size = new System.Drawing.Size(192, 33);
            this.NumOfQuestions.TabIndex = 2;
            this.NumOfQuestions.Text = "5";
            this.NumOfQuestions.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TimeForQeustion
            // 
            this.TimeForQeustion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.TimeForQeustion.Location = new System.Drawing.Point(650, 91);
            this.TimeForQeustion.Multiline = true;
            this.TimeForQeustion.Name = "TimeForQeustion";
            this.TimeForQeustion.Size = new System.Drawing.Size(192, 33);
            this.TimeForQeustion.TabIndex = 3;
            this.TimeForQeustion.Text = "30";
            this.TimeForQeustion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ErrorTextBox
            // 
            this.ErrorTextBox.AutoSize = true;
            this.ErrorTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.ErrorTextBox.ForeColor = System.Drawing.Color.Crimson;
            this.ErrorTextBox.Location = new System.Drawing.Point(297, 246);
            this.ErrorTextBox.Name = "ErrorTextBox";
            this.ErrorTextBox.Size = new System.Drawing.Size(0, 20);
            this.ErrorTextBox.TabIndex = 6;
            // 
            // RoomNameLabel
            // 
            this.RoomNameLabel.AutoSize = true;
            this.RoomNameLabel.BackColor = System.Drawing.Color.Transparent;
            this.RoomNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RoomNameLabel.ForeColor = System.Drawing.Color.Black;
            this.RoomNameLabel.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.RoomNameLabel.Location = new System.Drawing.Point(57, 72);
            this.RoomNameLabel.Name = "RoomNameLabel";
            this.RoomNameLabel.Size = new System.Drawing.Size(108, 18);
            this.RoomNameLabel.TabIndex = 7;
            this.RoomNameLabel.Text = "Room Name:";
            // 
            // NumOfPlayersLabel
            // 
            this.NumOfPlayersLabel.AutoSize = true;
            this.NumOfPlayersLabel.BackColor = System.Drawing.Color.Transparent;
            this.NumOfPlayersLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumOfPlayersLabel.ForeColor = System.Drawing.Color.Black;
            this.NumOfPlayersLabel.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.NumOfPlayersLabel.Location = new System.Drawing.Point(246, 72);
            this.NumOfPlayersLabel.Name = "NumOfPlayersLabel";
            this.NumOfPlayersLabel.Size = new System.Drawing.Size(132, 18);
            this.NumOfPlayersLabel.TabIndex = 8;
            this.NumOfPlayersLabel.Text = "Num Of Players:";
            // 
            // NumOfQuestionsLabel
            // 
            this.NumOfQuestionsLabel.AutoSize = true;
            this.NumOfQuestionsLabel.BackColor = System.Drawing.Color.Transparent;
            this.NumOfQuestionsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumOfQuestionsLabel.ForeColor = System.Drawing.Color.Black;
            this.NumOfQuestionsLabel.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.NumOfQuestionsLabel.Location = new System.Drawing.Point(447, 72);
            this.NumOfQuestionsLabel.Name = "NumOfQuestionsLabel";
            this.NumOfQuestionsLabel.Size = new System.Drawing.Size(153, 18);
            this.NumOfQuestionsLabel.TabIndex = 9;
            this.NumOfQuestionsLabel.Text = "Num Of Questions:";
            // 
            // TimeForQeustionLabel
            // 
            this.TimeForQeustionLabel.AutoSize = true;
            this.TimeForQeustionLabel.BackColor = System.Drawing.Color.Transparent;
            this.TimeForQeustionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimeForQeustionLabel.ForeColor = System.Drawing.Color.Black;
            this.TimeForQeustionLabel.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.TimeForQeustionLabel.Location = new System.Drawing.Point(655, 72);
            this.TimeForQeustionLabel.Name = "TimeForQeustionLabel";
            this.TimeForQeustionLabel.Size = new System.Drawing.Size(154, 18);
            this.TimeForQeustionLabel.TabIndex = 10;
            this.TimeForQeustionLabel.Text = "Time For Qeustion:";
            // 
            // CreateRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Client.Properties.Resources.CreateRoom;
            this.ClientSize = new System.Drawing.Size(854, 584);
            this.Controls.Add(this.TimeForQeustionLabel);
            this.Controls.Add(this.NumOfQuestionsLabel);
            this.Controls.Add(this.NumOfPlayersLabel);
            this.Controls.Add(this.RoomNameLabel);
            this.Controls.Add(this.ErrorTextBox);
            this.Controls.Add(this.CreateButton);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.TimeForQeustion);
            this.Controls.Add(this.NumOfQuestions);
            this.Controls.Add(this.NumOfPlayers);
            this.Controls.Add(this.RoomName);
            this.Name = "CreateRoom";
            this.Text = "CreateRoom";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Button CreateButton;
        private System.Windows.Forms.TextBox RoomName;
        private System.Windows.Forms.TextBox NumOfPlayers;
        private System.Windows.Forms.TextBox NumOfQuestions;
        private System.Windows.Forms.TextBox TimeForQeustion;
        private System.Windows.Forms.Label ErrorTextBox;
        private System.Windows.Forms.Label RoomNameLabel;
        private System.Windows.Forms.Label NumOfPlayersLabel;
        private System.Windows.Forms.Label NumOfQuestionsLabel;
        private System.Windows.Forms.Label TimeForQeustionLabel;
    }
}