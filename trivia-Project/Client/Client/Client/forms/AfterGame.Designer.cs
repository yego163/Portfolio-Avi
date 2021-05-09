namespace Client.forms
{
    partial class AfterGame
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
            this.UserName = new System.Windows.Forms.Label();
            this.Score = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // UserName
            // 
            this.UserName.AutoSize = true;
            this.UserName.BackColor = System.Drawing.Color.Transparent;
            this.UserName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserName.ForeColor = System.Drawing.Color.White;
            this.UserName.Location = new System.Drawing.Point(159, 9);
            this.UserName.Name = "UserName";
            this.UserName.Size = new System.Drawing.Size(178, 37);
            this.UserName.TabIndex = 0;
            this.UserName.Text = "UserName";
            // 
            // Score
            // 
            this.Score.AutoSize = true;
            this.Score.BackColor = System.Drawing.Color.Transparent;
            this.Score.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Score.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Score.ForeColor = System.Drawing.Color.White;
            this.Score.Location = new System.Drawing.Point(12, 66);
            this.Score.Name = "Score";
            this.Score.Size = new System.Drawing.Size(49, 16);
            this.Score.TabIndex = 1;
            this.Score.Text = "Score";
            // 
            // okButton
            // 
            this.okButton.BackColor = System.Drawing.Color.Transparent;
            this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.okButton.ForeColor = System.Drawing.SystemColors.Control;
            this.okButton.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.okButton.Location = new System.Drawing.Point(166, 243);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(154, 41);
            this.okButton.TabIndex = 2;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = false;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // AfterGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Client.Properties.Resources.EndGame;
            this.ClientSize = new System.Drawing.Size(484, 296);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.Score);
            this.Controls.Add(this.UserName);
            this.MaximumSize = new System.Drawing.Size(500, 335);
            this.MinimumSize = new System.Drawing.Size(500, 335);
            this.Name = "AfterGame";
            this.Text = "AfterGame";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AfterGame_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label UserName;
        private System.Windows.Forms.Label Score;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Timer timer;
    }
}