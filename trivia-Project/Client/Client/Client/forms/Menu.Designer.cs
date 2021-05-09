namespace Client
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
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.joinRoom = new System.Windows.Forms.Button();
            this.CreateRoomButton = new System.Windows.Forms.Button();
            this.MyStatus = new System.Windows.Forms.Button();
            this.BestScores = new System.Windows.Forms.Button();
            this.OUTPUT = new System.Windows.Forms.Label();
            this.EXITbutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // joinRoom
            // 
            this.joinRoom.BackColor = System.Drawing.Color.Transparent;
            this.joinRoom.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.joinRoom.FlatAppearance.BorderSize = 6;
            this.joinRoom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.joinRoom.Font = new System.Drawing.Font("a Absolute Empire", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.joinRoom.ForeColor = System.Drawing.Color.White;
            this.joinRoom.Location = new System.Drawing.Point(267, 60);
            this.joinRoom.Name = "joinRoom";
            this.joinRoom.Size = new System.Drawing.Size(272, 55);
            this.joinRoom.TabIndex = 3;
            this.joinRoom.Text = "Join Room";
            this.joinRoom.UseVisualStyleBackColor = false;
            this.joinRoom.Click += new System.EventHandler(this.JoinRoomButton);
            // 
            // CreateRoomButton
            // 
            this.CreateRoomButton.BackColor = System.Drawing.Color.Transparent;
            this.CreateRoomButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.CreateRoomButton.FlatAppearance.BorderSize = 6;
            this.CreateRoomButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CreateRoomButton.Font = new System.Drawing.Font("a Absolute Empire", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateRoomButton.ForeColor = System.Drawing.Color.White;
            this.CreateRoomButton.Location = new System.Drawing.Point(267, 143);
            this.CreateRoomButton.Name = "CreateRoomButton";
            this.CreateRoomButton.Size = new System.Drawing.Size(272, 55);
            this.CreateRoomButton.TabIndex = 4;
            this.CreateRoomButton.Text = "Create Room ";
            this.CreateRoomButton.UseVisualStyleBackColor = false;
            this.CreateRoomButton.Click += new System.EventHandler(this.CreateRoomButton_Click);
            // 
            // MyStatus
            // 
            this.MyStatus.BackColor = System.Drawing.Color.Transparent;
            this.MyStatus.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.MyStatus.FlatAppearance.BorderSize = 6;
            this.MyStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MyStatus.Font = new System.Drawing.Font("a Absolute Empire", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MyStatus.ForeColor = System.Drawing.Color.White;
            this.MyStatus.Location = new System.Drawing.Point(267, 228);
            this.MyStatus.Name = "MyStatus";
            this.MyStatus.Size = new System.Drawing.Size(272, 55);
            this.MyStatus.TabIndex = 5;
            this.MyStatus.Text = "My status";
            this.MyStatus.UseVisualStyleBackColor = false;
            this.MyStatus.Click += new System.EventHandler(this.MyStatus_Click);
            // 
            // BestScores
            // 
            this.BestScores.BackColor = System.Drawing.Color.Transparent;
            this.BestScores.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.BestScores.FlatAppearance.BorderSize = 6;
            this.BestScores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BestScores.Font = new System.Drawing.Font("a Absolute Empire", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BestScores.ForeColor = System.Drawing.Color.White;
            this.BestScores.Location = new System.Drawing.Point(267, 316);
            this.BestScores.Name = "BestScores";
            this.BestScores.Size = new System.Drawing.Size(272, 55);
            this.BestScores.TabIndex = 6;
            this.BestScores.Text = "Best Scores";
            this.BestScores.UseVisualStyleBackColor = false;
            this.BestScores.Click += new System.EventHandler(this.BestScores_Click);
            // 
            // OUTPUT
            // 
            this.OUTPUT.AutoSize = true;
            this.OUTPUT.BackColor = System.Drawing.Color.Transparent;
            this.OUTPUT.ForeColor = System.Drawing.Color.White;
            this.OUTPUT.Location = new System.Drawing.Point(301, 24);
            this.OUTPUT.Name = "OUTPUT";
            this.OUTPUT.Size = new System.Drawing.Size(210, 13);
            this.OUTPUT.TabIndex = 8;
            this.OUTPUT.Text = "Welcome To Avi And Shahar Trivia Project";
            this.OUTPUT.Click += new System.EventHandler(this.OUTPUT_Click);
            // 
            // EXITbutton
            // 
            this.EXITbutton.BackColor = System.Drawing.Color.Transparent;
            this.EXITbutton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.EXITbutton.FlatAppearance.BorderSize = 6;
            this.EXITbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EXITbutton.Font = new System.Drawing.Font("a Absolute Empire", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EXITbutton.ForeColor = System.Drawing.Color.White;
            this.EXITbutton.Location = new System.Drawing.Point(636, 380);
            this.EXITbutton.Name = "EXITbutton";
            this.EXITbutton.Size = new System.Drawing.Size(153, 55);
            this.EXITbutton.TabIndex = 9;
            this.EXITbutton.Text = "EXIT";
            this.EXITbutton.UseVisualStyleBackColor = false;
            this.EXITbutton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Client.Properties.Resources.MenuPage;
            this.ClientSize = new System.Drawing.Size(818, 447);
            this.Controls.Add(this.EXITbutton);
            this.Controls.Add(this.OUTPUT);
            this.Controls.Add(this.BestScores);
            this.Controls.Add(this.MyStatus);
            this.Controls.Add(this.CreateRoomButton);
            this.Controls.Add(this.joinRoom);
            this.MaximumSize = new System.Drawing.Size(834, 486);
            this.MinimumSize = new System.Drawing.Size(834, 486);
            this.Name = "Menu";
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.Menu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.Button joinRoom;
        private System.Windows.Forms.Button CreateRoomButton;
        private System.Windows.Forms.Button MyStatus;
        private System.Windows.Forms.Button BestScores;
        private System.Windows.Forms.Label OUTPUT;
        private System.Windows.Forms.Button EXITbutton;
    }
}

