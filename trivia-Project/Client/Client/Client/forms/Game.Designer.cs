namespace Client.forms
{
    partial class Game
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Game));
            this.ExitButton = new System.Windows.Forms.Button();
            this.RoomName = new System.Windows.Forms.Label();
            this.QuestionsCount = new System.Windows.Forms.Label();
            this.numOfCorrectAnswers = new System.Windows.Forms.Label();
            this.timerForQ = new System.Windows.Forms.Timer(this.components);
            this.Timer = new System.Windows.Forms.Label();
            this.Question = new System.Windows.Forms.Label();
            this.optionB = new System.Windows.Forms.Button();
            this.optionD = new System.Windows.Forms.Button();
            this.optionC = new System.Windows.Forms.Button();
            this.optionA = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ExitButton
            // 
            this.ExitButton.BackColor = System.Drawing.Color.Transparent;
            this.ExitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitButton.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.ExitButton.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.ExitButton.Location = new System.Drawing.Point(12, 12);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(73, 43);
            this.ExitButton.TabIndex = 4;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = false;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // RoomName
            // 
            this.RoomName.AutoSize = true;
            this.RoomName.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RoomName.ForeColor = System.Drawing.SystemColors.Control;
            this.RoomName.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.RoomName.Location = new System.Drawing.Point(300, 16);
            this.RoomName.Name = "RoomName";
            this.RoomName.Size = new System.Drawing.Size(0, 31);
            this.RoomName.TabIndex = 5;
            // 
            // QuestionsCount
            // 
            this.QuestionsCount.AutoSize = true;
            this.QuestionsCount.BackColor = System.Drawing.Color.Transparent;
            this.QuestionsCount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.QuestionsCount.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QuestionsCount.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.QuestionsCount.Location = new System.Drawing.Point(385, 26);
            this.QuestionsCount.Name = "QuestionsCount";
            this.QuestionsCount.Size = new System.Drawing.Size(25, 28);
            this.QuestionsCount.TabIndex = 6;
            this.QuestionsCount.Text = "0";
            // 
            // numOfCorrectAnswers
            // 
            this.numOfCorrectAnswers.AutoSize = true;
            this.numOfCorrectAnswers.BackColor = System.Drawing.Color.Transparent;
            this.numOfCorrectAnswers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.numOfCorrectAnswers.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.numOfCorrectAnswers.ForeColor = System.Drawing.Color.White;
            this.numOfCorrectAnswers.Location = new System.Drawing.Point(541, 53);
            this.numOfCorrectAnswers.Name = "numOfCorrectAnswers";
            this.numOfCorrectAnswers.Size = new System.Drawing.Size(25, 25);
            this.numOfCorrectAnswers.TabIndex = 7;
            this.numOfCorrectAnswers.Text = "0";
            // 
            // timerForQ
            // 
            this.timerForQ.Enabled = true;
            this.timerForQ.Interval = 1000;
            this.timerForQ.Tick += new System.EventHandler(this.timerForQ_Tick);
            // 
            // Timer
            // 
            this.Timer.AutoSize = true;
            this.Timer.BackColor = System.Drawing.Color.Transparent;
            this.Timer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Timer.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Timer.ForeColor = System.Drawing.Color.White;
            this.Timer.Location = new System.Drawing.Point(330, 500);
            this.Timer.Name = "Timer";
            this.Timer.Size = new System.Drawing.Size(69, 31);
            this.Timer.TabIndex = 8;
            this.Timer.Text = "time";
            // 
            // Question
            // 
            this.Question.AutoSize = true;
            this.Question.BackColor = System.Drawing.Color.Transparent;
            this.Question.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Question.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Question.ForeColor = System.Drawing.Color.White;
            this.Question.Location = new System.Drawing.Point(204, 129);
            this.Question.Name = "Question";
            this.Question.Size = new System.Drawing.Size(27, 29);
            this.Question.TabIndex = 9;
            this.Question.Text = "q";
            // 
            // optionB
            // 
            this.optionB.AutoEllipsis = true;
            this.optionB.BackColor = System.Drawing.Color.Transparent;
            this.optionB.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.optionB.FlatAppearance.BorderSize = 6;
            this.optionB.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.optionB.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.optionB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.optionB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.optionB.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.optionB.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.optionB.Location = new System.Drawing.Point(425, 341);
            this.optionB.Name = "optionB";
            this.optionB.Size = new System.Drawing.Size(241, 36);
            this.optionB.TabIndex = 2;
            this.optionB.Text = "optionB";
            this.optionB.UseVisualStyleBackColor = false;
            this.optionB.Click += new System.EventHandler(this.optionB_Click);
            // 
            // optionD
            // 
            this.optionD.BackColor = System.Drawing.Color.Transparent;
            this.optionD.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.optionD.FlatAppearance.BorderSize = 6;
            this.optionD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.optionD.ForeColor = System.Drawing.Color.Transparent;
            this.optionD.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.optionD.Location = new System.Drawing.Point(425, 401);
            this.optionD.Name = "optionD";
            this.optionD.Size = new System.Drawing.Size(241, 36);
            this.optionD.TabIndex = 3;
            this.optionD.Text = "optionD";
            this.optionD.UseVisualStyleBackColor = false;
            this.optionD.Click += new System.EventHandler(this.optionD_Click);
            // 
            // optionC
            // 
            this.optionC.BackColor = System.Drawing.Color.Transparent;
            this.optionC.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.optionC.FlatAppearance.BorderSize = 6;
            this.optionC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.optionC.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.optionC.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.optionC.Location = new System.Drawing.Point(144, 401);
            this.optionC.Name = "optionC";
            this.optionC.Size = new System.Drawing.Size(255, 36);
            this.optionC.TabIndex = 1;
            this.optionC.Text = "optionC";
            this.optionC.UseVisualStyleBackColor = false;
            this.optionC.Click += new System.EventHandler(this.optionC_Click);
            // 
            // optionA
            // 
            this.optionA.BackColor = System.Drawing.Color.Transparent;
            this.optionA.FlatAppearance.BorderColor = System.Drawing.Color.Lime;
            this.optionA.FlatAppearance.BorderSize = 6;
            this.optionA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.optionA.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.optionA.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.optionA.Location = new System.Drawing.Point(144, 341);
            this.optionA.Name = "optionA";
            this.optionA.Size = new System.Drawing.Size(252, 36);
            this.optionA.TabIndex = 0;
            this.optionA.Text = "optionA";
            this.optionA.UseVisualStyleBackColor = false;
            this.optionA.Click += new System.EventHandler(this.optionA_Click);
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(800, 566);
            this.Controls.Add(this.Question);
            this.Controls.Add(this.Timer);
            this.Controls.Add(this.numOfCorrectAnswers);
            this.Controls.Add(this.QuestionsCount);
            this.Controls.Add(this.RoomName);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.optionD);
            this.Controls.Add(this.optionB);
            this.Controls.Add(this.optionC);
            this.Controls.Add(this.optionA);
            this.Name = "Game";
            this.Text = "EndGame";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Label RoomName;
        private System.Windows.Forms.Label QuestionsCount;
        private System.Windows.Forms.Label numOfCorrectAnswers;
        private System.Windows.Forms.Timer timerForQ;
        private System.Windows.Forms.Label Timer;
        private System.Windows.Forms.Label Question;
        private System.Windows.Forms.Button optionB;
        private System.Windows.Forms.Button optionD;
        private System.Windows.Forms.Button optionC;
        private System.Windows.Forms.Button optionA;
    }
}