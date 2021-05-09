using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using Newtonsoft.Json;
using System.Security.Cryptography.X509Certificates;
using Client.classes;
using System.Windows.Media.Effects;


namespace Client.forms
{
    public partial class BestScores : Form
    {
        public BestScores()
        {
            InitializeComponent();
            setHighScores();
        }
        private void changeFormTo(Form f)
        {
            this.Hide();
            f.ShowDialog();
            f.StartPosition = FormStartPosition.Manual;
            f.Location = f.Location;
            f.Size = f.Size;
            this.Close();
        }
        private void setHighScores()
        {
            string serverMessage = send.GetHighScore();
            if ("" + serverMessage[0] == "" + (int)CODES.ERROR_ID)
            {
                ErrRespone r = JsonConvert.DeserializeObject<ErrRespone>(serverMessage.Substring(5));//get the message
            }
            else if ("" + serverMessage[0] == (int)CODES.HIGH_SCORE_ID + "")
            {
                HighScoreResponse stat = JsonConvert.DeserializeObject<HighScoreResponse>(serverMessage.Substring(5));
                bestScoresTextBox.Text = "";//clear
                string[] data = stat.HighScores.Split(',');
                for (int i = 0; i < data.Length - 1; i++)
                    bestScoresTextBox.Text = bestScoresTextBox.Text + (i + 1) + ") " + data[i] + Environment.NewLine;
                bestScoresTextBox.Text = bestScoresTextBox.Text + data.Length + ")" + data[data.Length - 1];
            }

        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            changeFormTo(new Menu());
        }
    }
}
