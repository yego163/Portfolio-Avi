namespace Client
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
            this.JoinButton = new System.Windows.Forms.Button();
            this.BackButton = new System.Windows.Forms.Button();
            this.refreshButton = new System.Windows.Forms.Button();
            this.ErrorTextBox = new System.Windows.Forms.Label();
            this.BottomToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.TopToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.RightToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.LeftToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.ContentPanel = new System.Windows.Forms.ToolStripContentPanel();
            this.roomsList = new System.Windows.Forms.ListBox();
            this.PlayersInRoomsList = new System.Windows.Forms.ListBox();
            this.RoomListlabel = new System.Windows.Forms.Label();
            this.PlayersInroomlabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // JoinButton
            // 
            this.JoinButton.BackColor = System.Drawing.Color.Transparent;
            this.JoinButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.JoinButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.JoinButton.Location = new System.Drawing.Point(224, 291);
            this.JoinButton.Name = "JoinButton";
            this.JoinButton.Size = new System.Drawing.Size(158, 44);
            this.JoinButton.TabIndex = 1;
            this.JoinButton.Text = "Join";
            this.JoinButton.UseVisualStyleBackColor = false;
            this.JoinButton.Click += new System.EventHandler(this.JoinButton_Click);
            // 
            // BackButton
            // 
            this.BackButton.BackColor = System.Drawing.Color.Transparent;
            this.BackButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BackButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BackButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BackButton.Location = new System.Drawing.Point(12, 12);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(124, 44);
            this.BackButton.TabIndex = 2;
            this.BackButton.Text = "Back";
            this.BackButton.UseVisualStyleBackColor = false;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // refreshButton
            // 
            this.refreshButton.BackColor = System.Drawing.Color.Transparent;
            this.refreshButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.refreshButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.refreshButton.Location = new System.Drawing.Point(418, 291);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(158, 44);
            this.refreshButton.TabIndex = 3;
            this.refreshButton.Text = "refresh";
            this.refreshButton.UseVisualStyleBackColor = false;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // ErrorTextBox
            // 
            this.ErrorTextBox.AutoSize = true;
            this.ErrorTextBox.BackColor = System.Drawing.Color.Transparent;
            this.ErrorTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.ErrorTextBox.ForeColor = System.Drawing.Color.White;
            this.ErrorTextBox.Location = new System.Drawing.Point(263, 254);
            this.ErrorTextBox.Name = "ErrorTextBox";
            this.ErrorTextBox.Size = new System.Drawing.Size(149, 20);
            this.ErrorTextBox.TabIndex = 4;
            this.ErrorTextBox.Text = "No available Rooms";
            // 
            // BottomToolStripPanel
            // 
            this.BottomToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.BottomToolStripPanel.Name = "BottomToolStripPanel";
            this.BottomToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.BottomToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.BottomToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // TopToolStripPanel
            // 
            this.TopToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.TopToolStripPanel.Name = "TopToolStripPanel";
            this.TopToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.TopToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.TopToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // RightToolStripPanel
            // 
            this.RightToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.RightToolStripPanel.Name = "RightToolStripPanel";
            this.RightToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.RightToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.RightToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // LeftToolStripPanel
            // 
            this.LeftToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.LeftToolStripPanel.Name = "LeftToolStripPanel";
            this.LeftToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.LeftToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.LeftToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // ContentPanel
            // 
            this.ContentPanel.Size = new System.Drawing.Size(150, 150);
            // 
            // roomsList
            // 
            this.roomsList.FormattingEnabled = true;
            this.roomsList.Location = new System.Drawing.Point(267, 104);
            this.roomsList.Name = "roomsList";
            this.roomsList.Size = new System.Drawing.Size(259, 147);
            this.roomsList.TabIndex = 5;
            this.roomsList.Click += new System.EventHandler(this.roomsList_Click);
            // 
            // PlayersInRoomsList
            // 
            this.PlayersInRoomsList.FormattingEnabled = true;
            this.PlayersInRoomsList.Location = new System.Drawing.Point(541, 109);
            this.PlayersInRoomsList.Name = "PlayersInRoomsList";
            this.PlayersInRoomsList.Size = new System.Drawing.Size(140, 95);
            this.PlayersInRoomsList.TabIndex = 6;
            // 
            // RoomListlabel
            // 
            this.RoomListlabel.AutoSize = true;
            this.RoomListlabel.BackColor = System.Drawing.Color.Transparent;
            this.RoomListlabel.Font = new System.Drawing.Font("a Absolute Empire", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RoomListlabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.RoomListlabel.Location = new System.Drawing.Point(262, 73);
            this.RoomListlabel.Name = "RoomListlabel";
            this.RoomListlabel.Size = new System.Drawing.Size(186, 28);
            this.RoomListlabel.TabIndex = 7;
            this.RoomListlabel.Text = "Room List:";
            // 
            // PlayersInroomlabel
            // 
            this.PlayersInroomlabel.AutoSize = true;
            this.PlayersInroomlabel.BackColor = System.Drawing.Color.Transparent;
            this.PlayersInroomlabel.Font = new System.Drawing.Font("a Absolute Empire", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlayersInroomlabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.PlayersInroomlabel.Location = new System.Drawing.Point(539, 89);
            this.PlayersInroomlabel.Name = "PlayersInroomlabel";
            this.PlayersInroomlabel.Size = new System.Drawing.Size(130, 12);
            this.PlayersInroomlabel.TabIndex = 8;
            this.PlayersInroomlabel.Text = "Players in Room:";
            // 
            // JoinRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Client.Properties.Resources.CreateRoom;
            this.ClientSize = new System.Drawing.Size(800, 489);
            this.Controls.Add(this.PlayersInroomlabel);
            this.Controls.Add(this.RoomListlabel);
            this.Controls.Add(this.PlayersInRoomsList);
            this.Controls.Add(this.roomsList);
            this.Controls.Add(this.ErrorTextBox);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.JoinButton);
            this.MaximumSize = new System.Drawing.Size(816, 528);
            this.MinimumSize = new System.Drawing.Size(816, 528);
            this.Name = "JoinRoom";
            this.Text = "JoinRoom";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button JoinButton;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.Label ErrorTextBox;
        private System.Windows.Forms.ToolStripPanel BottomToolStripPanel;
        private System.Windows.Forms.ToolStripPanel TopToolStripPanel;
        private System.Windows.Forms.ToolStripPanel RightToolStripPanel;
        private System.Windows.Forms.ToolStripPanel LeftToolStripPanel;
        private System.Windows.Forms.ToolStripContentPanel ContentPanel;
        private System.Windows.Forms.ListBox roomsList;
        private System.Windows.Forms.ListBox PlayersInRoomsList;
        private System.Windows.Forms.Label RoomListlabel;
        private System.Windows.Forms.Label PlayersInroomlabel;
    }
}