namespace Client.forms
{
    partial class BestScores
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
            this.bestScoresTextBox = new System.Windows.Forms.TextBox();
            this.BackButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bestScoresTextBox
            // 
            this.bestScoresTextBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.bestScoresTextBox.Enabled = false;
            this.bestScoresTextBox.Font = new System.Drawing.Font("Segoe Print", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bestScoresTextBox.Location = new System.Drawing.Point(160, 109);
            this.bestScoresTextBox.Multiline = true;
            this.bestScoresTextBox.Name = "bestScoresTextBox";
            this.bestScoresTextBox.ReadOnly = true;
            this.bestScoresTextBox.Size = new System.Drawing.Size(511, 288);
            this.bestScoresTextBox.TabIndex = 0;
            // 
            // BackButton
            // 
            this.BackButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BackButton.Location = new System.Drawing.Point(12, 12);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(96, 40);
            this.BackButton.TabIndex = 1;
            this.BackButton.Text = "Back";
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // BestScores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Client.Properties.Resources.BestScore;
            this.ClientSize = new System.Drawing.Size(804, 483);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.bestScoresTextBox);
            this.MaximumSize = new System.Drawing.Size(820, 522);
            this.MinimumSize = new System.Drawing.Size(820, 522);
            this.Name = "BestScores";
            this.Text = "BestScores";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox bestScoresTextBox;
        private System.Windows.Forms.Button BackButton;
    }
}