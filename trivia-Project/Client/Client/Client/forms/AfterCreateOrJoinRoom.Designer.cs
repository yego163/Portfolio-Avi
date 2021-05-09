namespace Client
{
    partial class AfterCreateOrJoinRoom
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
            this.components = new System.ComponentModel.Container();
            this.Room_Name = new System.Windows.Forms.Label();
            this.MaxPlayers = new System.Windows.Forms.Label();
            this.Num_Of_Questions = new System.Windows.Forms.Label();
            this.TimePerQustion = new System.Windows.Forms.Label();
            this.CloseRoomButton = new System.Windows.Forms.Button();
            this.StartGameButton = new System.Windows.Forms.Button();
            this.leaveButton = new System.Windows.Forms.Button();
            this.currentPlayers = new System.Windows.Forms.ListBox();
            this.updateTimer = new System.Windows.Forms.Timer(this.components);
            this.PlayersLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Room_Name
            // 
            this.Room_Name.AutoSize = true;
            this.Room_Name.BackColor = System.Drawing.Color.Transparent;
            this.Room_Name.Cursor = System.Windows.Forms.Cursors.Default;
            this.Room_Name.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Room_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Room_Name.ForeColor = System.Drawing.Color.Red;
            this.Room_Name.Location = new System.Drawing.Point(24, 9);
            this.Room_Name.Name = "Room_Name";
            this.Room_Name.Size = new System.Drawing.Size(188, 36);
            this.Room_Name.TabIndex = 0;
            this.Room_Name.Text = "Room_Name";
            // 
            // MaxPlayers
            // 
            this.MaxPlayers.AutoSize = true;
            this.MaxPlayers.BackColor = System.Drawing.Color.Transparent;
            this.MaxPlayers.Cursor = System.Windows.Forms.Cursors.Default;
            this.MaxPlayers.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaxPlayers.ForeColor = System.Drawing.Color.Red;
            this.MaxPlayers.Location = new System.Drawing.Point(24, 164);
            this.MaxPlayers.Name = "MaxPlayers";
            this.MaxPlayers.Size = new System.Drawing.Size(170, 36);
            this.MaxPlayers.TabIndex = 1;
            this.MaxPlayers.Text = "MaxPlayers";
            // 
            // Num_Of_Questions
            // 
            this.Num_Of_Questions.AutoSize = true;
            this.Num_Of_Questions.BackColor = System.Drawing.Color.Transparent;
            this.Num_Of_Questions.Cursor = System.Windows.Forms.Cursors.Default;
            this.Num_Of_Questions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Num_Of_Questions.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Num_Of_Questions.ForeColor = System.Drawing.Color.Red;
            this.Num_Of_Questions.Location = new System.Drawing.Point(24, 59);
            this.Num_Of_Questions.Name = "Num_Of_Questions";
            this.Num_Of_Questions.Size = new System.Drawing.Size(275, 36);
            this.Num_Of_Questions.TabIndex = 2;
            this.Num_Of_Questions.Text = "Num_Of_Questions";
            // 
            // TimePerQustion
            // 
            this.TimePerQustion.AutoSize = true;
            this.TimePerQustion.BackColor = System.Drawing.Color.Transparent;
            this.TimePerQustion.Cursor = System.Windows.Forms.Cursors.Default;
            this.TimePerQustion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TimePerQustion.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimePerQustion.ForeColor = System.Drawing.Color.Red;
            this.TimePerQustion.Location = new System.Drawing.Point(24, 112);
            this.TimePerQustion.Name = "TimePerQustion";
            this.TimePerQustion.Size = new System.Drawing.Size(228, 36);
            this.TimePerQustion.TabIndex = 3;
            this.TimePerQustion.Text = "TimePerQustion";
            // 
            // CloseRoomButton
            // 
            this.CloseRoomButton.BackColor = System.Drawing.Color.Transparent;
            this.CloseRoomButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseRoomButton.Font = new System.Drawing.Font("Gill Sans Ultra Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CloseRoomButton.ForeColor = System.Drawing.Color.White;
            this.CloseRoomButton.Location = new System.Drawing.Point(362, 405);
            this.CloseRoomButton.Name = "CloseRoomButton";
            this.CloseRoomButton.Size = new System.Drawing.Size(121, 30);
            this.CloseRoomButton.TabIndex = 6;
            this.CloseRoomButton.Text = "Close Room";
            this.CloseRoomButton.UseVisualStyleBackColor = false;
            this.CloseRoomButton.Click += new System.EventHandler(this.CloseRoomButton_Click);
            // 
            // StartGameButton
            // 
            this.StartGameButton.BackColor = System.Drawing.Color.Transparent;
            this.StartGameButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StartGameButton.Font = new System.Drawing.Font("Gill Sans Ultra Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartGameButton.ForeColor = System.Drawing.Color.White;
            this.StartGameButton.Location = new System.Drawing.Point(362, 441);
            this.StartGameButton.Name = "StartGameButton";
            this.StartGameButton.Size = new System.Drawing.Size(121, 30);
            this.StartGameButton.TabIndex = 7;
            this.StartGameButton.Text = "StartGame";
            this.StartGameButton.UseVisualStyleBackColor = false;
            this.StartGameButton.Click += new System.EventHandler(this.StartGameButton_Click);
            // 
            // leaveButton
            // 
            this.leaveButton.BackColor = System.Drawing.Color.Transparent;
            this.leaveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.leaveButton.Font = new System.Drawing.Font("Gill Sans Ultra Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.leaveButton.ForeColor = System.Drawing.Color.White;
            this.leaveButton.Location = new System.Drawing.Point(362, 405);
            this.leaveButton.Name = "leaveButton";
            this.leaveButton.Size = new System.Drawing.Size(121, 30);
            this.leaveButton.TabIndex = 8;
            this.leaveButton.Text = "Leave";
            this.leaveButton.UseVisualStyleBackColor = false;
            this.leaveButton.Click += new System.EventHandler(this.leaveButton_Click);
            // 
            // currentPlayers
            // 
            this.currentPlayers.FormattingEnabled = true;
            this.currentPlayers.Location = new System.Drawing.Point(315, 278);
            this.currentPlayers.Name = "currentPlayers";
            this.currentPlayers.Size = new System.Drawing.Size(201, 121);
            this.currentPlayers.TabIndex = 9;
            // 
            // updateTimer
            // 
            this.updateTimer.Enabled = true;
            this.updateTimer.Interval = 1000;
            this.updateTimer.Tick += new System.EventHandler(this.updateTimer_Tick);
            // 
            // PlayersLabel
            // 
            this.PlayersLabel.AutoSize = true;
            this.PlayersLabel.BackColor = System.Drawing.Color.Transparent;
            this.PlayersLabel.Font = new System.Drawing.Font("a Absolute Empire", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlayersLabel.ForeColor = System.Drawing.Color.Red;
            this.PlayersLabel.Location = new System.Drawing.Point(358, 253);
            this.PlayersLabel.Name = "PlayersLabel";
            this.PlayersLabel.Size = new System.Drawing.Size(123, 22);
            this.PlayersLabel.TabIndex = 10;
            this.PlayersLabel.Text = "Players:";
            // 
            // AfterCreateOrJoinRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Client.Properties.Resources.AfterCreateOrJoin;
            this.ClientSize = new System.Drawing.Size(833, 579);
            this.Controls.Add(this.PlayersLabel);
            this.Controls.Add(this.currentPlayers);
            this.Controls.Add(this.leaveButton);
            this.Controls.Add(this.StartGameButton);
            this.Controls.Add(this.CloseRoomButton);
            this.Controls.Add(this.TimePerQustion);
            this.Controls.Add(this.Num_Of_Questions);
            this.Controls.Add(this.MaxPlayers);
            this.Controls.Add(this.Room_Name);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximumSize = new System.Drawing.Size(853, 622);
            this.MinimumSize = new System.Drawing.Size(853, 622);
            this.Name = "AfterCreateOrJoinRoom";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "AfterCreateRoom";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Room_Name;
        private System.Windows.Forms.Label MaxPlayers;
        private System.Windows.Forms.Label Num_Of_Questions;
        private System.Windows.Forms.Label TimePerQustion;
        private System.Windows.Forms.Button CloseRoomButton;
        private System.Windows.Forms.Button StartGameButton;
        private System.Windows.Forms.Button leaveButton;
        private System.Windows.Forms.ListBox currentPlayers;
        private System.Windows.Forms.Timer updateTimer;
        private System.Windows.Forms.Label PlayersLabel;
    }
}