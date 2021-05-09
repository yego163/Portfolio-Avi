namespace Client.forms
{
    partial class Mystatus
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Mystatus));
            this.statistics = new System.Windows.Forms.TextBox();
            this.ErrorTextBox = new System.Windows.Forms.Label();
            this.BackButton = new System.Windows.Forms.Button();
            this.Name = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // statistics
            // 
            this.statistics.BackColor = System.Drawing.SystemColors.Control;
            this.statistics.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.statistics.Font = new System.Drawing.Font("Microsoft JhengHei", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statistics.Location = new System.Drawing.Point(70, 71);
            this.statistics.Multiline = true;
            this.statistics.Name = "statistics";
            this.statistics.ReadOnly = true;
            this.statistics.Size = new System.Drawing.Size(347, 295);
            this.statistics.TabIndex = 0;
            // 
            // ErrorTextBox
            // 
            this.ErrorTextBox.AutoSize = true;
            this.ErrorTextBox.Location = new System.Drawing.Point(67, 384);
            this.ErrorTextBox.Name = "ErrorTextBox";
            this.ErrorTextBox.Size = new System.Drawing.Size(0, 13);
            this.ErrorTextBox.TabIndex = 1;
            // 
            // BackButton
            // 
            this.BackButton.BackColor = System.Drawing.Color.Transparent;
            this.BackButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BackButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BackButton.Location = new System.Drawing.Point(13, 13);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(102, 37);
            this.BackButton.TabIndex = 2;
            this.BackButton.Text = "Back";
            this.BackButton.UseVisualStyleBackColor = false;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // Name
            // 
            this.Name.AutoSize = true;
            this.Name.Font = new System.Drawing.Font("Matura MT Script Capitals", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name.Location = new System.Drawing.Point(347, 36);
            this.Name.Name = "Name";
            this.Name.Size = new System.Drawing.Size(0, 32);
            this.Name.TabIndex = 3;
            // 
            // Mystatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(815, 489);
            this.Controls.Add(this.Name);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.ErrorTextBox);
            this.Controls.Add(this.statistics);
            this.Text = "Mystatus";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox statistics;
        private System.Windows.Forms.Label ErrorTextBox;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Label Name;
    }
}