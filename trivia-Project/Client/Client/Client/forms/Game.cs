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
using System.Linq;

namespace Client.forms
{
    public partial class Game : Form
    {
        private int timePerQ;
        private QuestionResponse currentQ;
        int chooseId;
        bool isAdmin;
        public Game(int numOfQuestions, int timeForQ, bool _isAdmin)
        {
            InitializeComponent();
            isAdmin = _isAdmin;
            this.QuestionsCount.Text = "" + numOfQuestions;
            numOfCorrectAnswers.Text = "0";
            this.timePerQ = timeForQ;
            Timer.Text = timeForQ + "";
            chooseId = -1;//reset choose
            newQuestion();//first Q
        }
        private void changeFormTo(Form f)
        {
            timerForQ.Stop();
            this.Hide();
            f.ShowDialog();
            f.StartPosition = FormStartPosition.Manual;
            f.Location = f.Location;
            f.Size = f.Size;
            this.Close();
        }
        private void setQuestion()
        {
            Question.Text = currentQ.question;
            if(currentQ.question.Length > 20)
                this.Question.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))); // do the font small if the text long
            foreach (var item in currentQ.answers)
            {
                switch (item.ElementAt(0).ToString())
                {
                    case "0":
                        optionA.Text = item.ElementAt(1).ToString();
                        break;
                    case "1":
                        optionB.Text = item.ElementAt(1).ToString();
                        break;
                    case "2":
                        optionC.Text = item.ElementAt(1).ToString();
                        break;
                    case "3":
                        optionD.Text = item.ElementAt(1).ToString();
                        break;
                    default:
                        optionA.Text = "";
                        optionB.Text = "";
                        optionC.Text = "";
                        optionD.Text = "";
                        break;
                }
            }
        }
        private void newQuestion()
        {
            string questionData = send.getQuestion();
            if ("" + questionData[0] == "" + (int)CODES.ERROR_ID)
            {
                ErrRespone r = JsonConvert.DeserializeObject<ErrRespone>(questionData.Substring(5));//get the message
                changeFormTo(new AfterGame(isAdmin));
            }
            else if ("" + questionData[0] == CODES.GET_QUESION_CODE + "")
            {
                currentQ = JsonConvert.DeserializeObject<QuestionResponse>(questionData.Substring(5));
                if (currentQ.status == 0)
                {
                    changeFormTo(new AfterGame(isAdmin));//if the user has answer on all the questions
                }
                //status 1....
                setQuestion();
            }
        }
        private void submitAnswer()
        {
            string data = send.submitAnswer(new submitAns(chooseId));
            if ("" + data[0] == "" + (int)CODES.ERROR_ID)
            {
                ErrRespone r = JsonConvert.DeserializeObject<ErrRespone>(data.Substring(5));//get the message
                MessageBox.Show(r.message);
            }
            else if (data[0] + "" == "" + CODES.SUBMIT_ANSWER_CODE)
            {//status has to be 1...
                submitResponse r = JsonConvert.DeserializeObject<submitResponse>(data.Substring(5));//get the message
                if (chooseId == r.correctAnswerId)
                    numOfCorrectAnswers.Text = (int.Parse(numOfCorrectAnswers.Text) + 1) + "";//the ans was correct
            }
            QuestionsCount.Text = (int.Parse(QuestionsCount.Text) - 1) + "";
        }
        private void timerForQ_Tick(object sender, EventArgs e)
        {
            if (Timer.Text != "0")
            {//there is still time...
                Timer.Text = (int.Parse(Timer.Text) - 1) + "";
                return;
            }
            if (QuestionsCount.Text == "0")
                changeFormTo(new AfterGame(isAdmin));//if the user has answer on all the questions
            if(chooseId == -1)
            {
                submitAnswer();
            }
            newQuestion();
            Timer.Text = timePerQ + "";//reset the clock
            chooseId = -1;//reset choose
            optionA.Font = new Font(optionA.Font, FontStyle.Regular);//reset the buttons
            optionB.Font = new Font(optionB.Font, FontStyle.Regular);
            optionC.Font = new Font(optionC.Font, FontStyle.Regular);
            optionD.Font = new Font(optionD.Font, FontStyle.Regular);
            optionA.Enabled = true;
            optionB.Enabled = true;
            optionC.Enabled = true;
            optionD.Enabled = true;

        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            string res = send.leaveGame();
            if ("" + res[0] == "" + (int)CODES.ERROR_ID)
            {
                ErrRespone r = JsonConvert.DeserializeObject<ErrRespone>(res.Substring(5));//get the message
                MessageBox.Show(r.message);
            }
            else if (res[0] + "" == "" + CODES.LEAVE_GAME_CODE)
            {//status has to be 1...
                changeFormTo(new Menu());
            }
        }

        private void optionA_Click(object sender, EventArgs e)
        {
            chooseId = 0;
            optionA.Font = new Font(optionA.Font, FontStyle.Underline | FontStyle.Bold);
            optionB.Font = new Font(optionB.Font, FontStyle.Regular);
            optionC.Font = new Font(optionC.Font, FontStyle.Regular);
            optionD.Font = new Font(optionD.Font, FontStyle.Regular);
            submitAnswer();
            optionA.Enabled = false;
            optionB.Enabled = false;
            optionC.Enabled = false;
            optionD.Enabled = false;
        }

        private void optionB_Click(object sender, EventArgs e)
        {
            chooseId = 1;
            optionA.Font = new Font(optionA.Font, FontStyle.Regular);
            optionB.Font = new Font(optionB.Font, FontStyle.Underline | FontStyle.Bold);
            optionC.Font = new Font(optionC.Font, FontStyle.Regular);
            optionD.Font = new Font(optionD.Font, FontStyle.Regular);
            submitAnswer();
            optionA.Enabled = false;
            optionB.Enabled = false;
            optionC.Enabled = false;
            optionD.Enabled = false;
        }

        private void optionC_Click(object sender, EventArgs e)
        {
            chooseId = 2;
            optionA.Font = new Font(optionA.Font, FontStyle.Regular);
            optionB.Font = new Font(optionB.Font, FontStyle.Regular);
            optionC.Font = new Font(optionC.Font, FontStyle.Underline | FontStyle.Bold);
            optionD.Font = new Font(optionD.Font, FontStyle.Regular);
            submitAnswer();
            optionA.Enabled = false;
            optionB.Enabled = false;
            optionC.Enabled = false;
            optionD.Enabled = false;
        }

        private void optionD_Click(object sender, EventArgs e)
        {
            chooseId = 3;
            optionA.Font = new Font(optionA.Font, FontStyle.Regular);
            optionB.Font = new Font(optionB.Font, FontStyle.Regular);
            optionC.Font = new Font(optionC.Font, FontStyle.Regular);
            optionD.Font = new Font(optionD.Font, FontStyle.Underline | FontStyle.Bold);
            submitAnswer();
            optionA.Enabled = false;
            optionB.Enabled = false;
            optionC.Enabled = false;
            optionD.Enabled = false;
        }
    }
}
