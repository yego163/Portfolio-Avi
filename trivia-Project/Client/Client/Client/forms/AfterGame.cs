using Client.classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Client.forms
{
    public partial class AfterGame : Form
    {
        bool isAdmin;
        public AfterGame(bool _isAdmin)
        {
            InitializeComponent();
            isAdmin = _isAdmin;
            UserName.Text = G.myName;
            okButton.Click -= okButton_Click; //dont allow to click on button
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            string result = send.getGameResult();
            if ("" + result[0] == "" + (int)CODES.ERROR_ID)
            {
                ErrRespone r = JsonConvert.DeserializeObject<ErrRespone>(result.Substring(5));//get the message
                MessageBox.Show(r.message);
            }
            else if (result[0] == CODES.GET_GAME_RESULT_CODE )
            {
                resultResponse r = JsonConvert.DeserializeObject<resultResponse>(result.Substring(5));//get the message
                if (r.status == 0)//the game hasn't end yet
                    Score.Text = "Waiting to the other players";
                else//status 1 = the game has ended
                {
                    okButton.Click += okButton_Click;//enable the button
                    for (int i = 0; i < r.results.Length; i++)//set the score table
                        Score.Text = Score.Text + "\n" + (((r.results[i].username + ": ").PadRight(30, ' ')
                            + ("Correct Ans: " + r.results[i].correctAnswerCount).PadLeft(15, ' ')
                            + ("Wrong Ans: " + r.results[i].wrongAnswerCount).PadLeft(15, ' ')
                            + ("TimePerQ: " + r.results[i].averageAnswerTime).PadLeft(15, ' ')) + "\n");
                    timer.Enabled = false;//dont need to refresh anymore
                    timer.Stop();
                }
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if(isAdmin)
            {
                string result = send.EndGame();
            }
            changeFormTo(new Menu());
        }
        private void changeFormTo(Form f)
        {
            timer.Stop();
            this.Hide();
            f.ShowDialog();
            f.StartPosition = FormStartPosition.Manual;
            f.Location = f.Location;
            f.Size = f.Size;
            this.Close();
        }

        private void AfterGame_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer.Stop();
            this.Hide();
            this.Close();
        }
    }
}
