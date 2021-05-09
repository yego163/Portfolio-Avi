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
using System.Deployment.Application;

namespace Client
{
    public partial class CreateRoom : Form
    {
        public CreateRoom()
        { 
            InitializeComponent();
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
        private bool CheckInfo()
        {
            return RoomName.Text != "" && NumOfPlayers.Text != "" && NumOfQuestions.Text != "" && TimeForQeustion.Text != ""//check if the text boxes are empty
                && int.TryParse(NumOfPlayers.Text + NumOfQuestions.Text + TimeForQeustion.Text, out _);//check if the numbers places are actualy numbers
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            if (!CheckInfo())
            {
                ErrorTextBox.Text = "uncorrect details!";
                ErrorTextBox.ForeColor = Color.Red;//set the foreground to red
                return;
            }
            string serverMessage = send.CreateRoom(new RoomProp(RoomName.Text, int.Parse(NumOfPlayers.Text), int.Parse(NumOfQuestions.Text), int.Parse(TimeForQeustion.Text)));
            if ("" + serverMessage[0] == "" + (int)CODES.ERROR_ID)
            {
                ErrRespone r = JsonConvert.DeserializeObject<ErrRespone>(serverMessage.Substring(5));//get the message
                ErrorTextBox.Text = r.message;
                ErrorTextBox.ForeColor = Color.Red;//set the foreground to red
            }
            else if ("" + serverMessage[0] == (int)CODES.CREATE_ROOM_ID + "")
            {
                CreateRoomRespone stat = JsonConvert.DeserializeObject<CreateRoomRespone>(serverMessage.Substring(5));
                if (stat.status == 1)
                {
                    changeFormTo(new AfterCreateOrJoinRoom(true, stat.ID.ToString(), new RoomProp(RoomName.Text, int.Parse(NumOfPlayers.Text), int.Parse(NumOfQuestions.Text), int.Parse(TimeForQeustion.Text))));
                }
                else
                {
                    ErrorTextBox.Text = "Cant create room";
                    ErrorTextBox.ForeColor = Color.Red;//set the foreground to red
                }
            }

        }
        private void BackButton_Click(object sender, EventArgs e)
        {
            changeFormTo(new Menu());
        }
    }
}
