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
    public partial class Mystatus : Form
    {
        public Mystatus()
        {
            InitializeComponent();
            setStatus();
            Name.Text = G.myName;
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
        private void setStatus()
        {
            string serverMessage = send.GetHighScore();
            if ("" + serverMessage[0] == "" + (int)CODES.ERROR_ID)
            {
                ErrRespone r = JsonConvert.DeserializeObject<ErrRespone>(serverMessage.Substring(5));//get the message
                ErrorTextBox.Text = r.message;
                ErrorTextBox.ForeColor = Color.Red;//set the foreground to red
            }
            else if ("" + serverMessage[0] == (int)CODES.HIGH_SCORE_ID + "")
            {
                HighScoreResponse stat = JsonConvert.DeserializeObject<HighScoreResponse>(serverMessage.Substring(5));
                statistics.Text = "";
                string[] data = stat.UserStatistics.Split(','), names = { "Total Games: ", "Total Questions: ", "Total Correct Questions: ", "AVG Time Per Quesion: " };
                for (int i = 0; i < 4; i++)
                    statistics.Text = statistics.Text + names[i] + data[i] +  Environment.NewLine;//add the new line => Category: number\n
                
            }

        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            changeFormTo(new Menu());
        }
    }
}
