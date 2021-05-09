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
using Client.forms;

namespace Client
{
    public partial class AfterCreateOrJoinRoom : Form
    {
        private bool isAdmin;
        private string myId;
        public AfterCreateOrJoinRoom(bool admin, string id, RoomProp room)
        {
            myId = id;
            isAdmin = admin;
            InitializeComponent();
            string respone = send.getRoomState();
            if ("" + respone[0] == "" + (int)CODES.GET_ROOM_STATE_ID)
            {
                ErrRespone r = JsonConvert.DeserializeObject<ErrRespone>(respone.Substring(5));//get the message
                MessageBox.Show(r.message);
            }
            else if (respone[0] + "" == "" + CODES.GET_ROOM_STATE_ID)
            {
                getRoomStateResponse r = JsonConvert.DeserializeObject<getRoomStateResponse>(respone.Substring(5));//get the message
            }
            if (isAdmin)
            {
                leaveButton.Hide();
                MaxPlayers.Text = "Max Players: " + room.maxUsers;
            }
            else
            {
                MaxPlayers.Hide();
                CloseRoomButton.Hide();
                StartGameButton.Hide();
            }
            Room_Name.Text = "Room Name: " + room.roomName;
            Num_Of_Questions.Text = "Num Of Questions: " + room.questionCount;
            TimePerQustion.Text = "Time Per Qustion: " + room.answerTimeout;
        }
        private void changeFormTo(Form f)
        {
            updateTimer.Stop();
            this.Hide();
            f.ShowDialog();
            f.StartPosition = FormStartPosition.Manual;
            f.Location = f.Location;
            f.Size = f.Size;
            this.Close();
        }
        private void createPlayersList(string[] players)
        {
            currentPlayers.Items.Clear();
            currentPlayers.Items.AddRange(players);
        }
        private void leaveButton_Click(object sender, EventArgs e)
        {
            string res = send.leaveRoom();
            if ("" + res[0] == "" + (int)CODES.ERROR_ID)
            {
                ErrRespone r = JsonConvert.DeserializeObject<ErrRespone>(res.Substring(5));//get the message
                MessageBox.Show(r.message);
            }
            else if(res[0] + "" == "" + CODES.LEAVE_ROOM_ID)
            {//status has to be 1...
                updateTimer.Enabled = false;
                changeFormTo(new Menu());
            }
        }

        private void CloseRoomButton_Click(object sender, EventArgs e)
        {
            string res = send.closeRoom();
            if ("" + res[0] == "" + (int)CODES.ERROR_ID)
            {
                ErrRespone r = JsonConvert.DeserializeObject<ErrRespone>(res.Substring(5));//get the message
                MessageBox.Show(r.message);
            }
            else if (res[0] + "" == "" + CODES.CLOSE_ROOM_ID)
            {
                updateTimer.Enabled = false;
                changeFormTo(new Menu());
            }
        }

        private void StartGameButton_Click(object sender, EventArgs e)
        {
            string res = send.startGame();
            if ("" + res[0] == "" + (int)CODES.ERROR_ID)
            {
                ErrRespone r = JsonConvert.DeserializeObject<ErrRespone>(res.Substring(5));//get the message
                MessageBox.Show(r.message);
            }
            else if (res[0] + "" == "" + CODES.START_GAME_ID)
            {
                changeFormTo(new Game(int.Parse(Num_Of_Questions.Text.Substring(18)), int.Parse(TimePerQustion.Text.Substring(18)), isAdmin));
            }
        }

        private void updateTimer_Tick(object sender, EventArgs e)
        {
            string serverMessage = send.getRoomState();
            if ("" + serverMessage[0] == "" + (int)CODES.ERROR_ID)
            {
                ErrRespone r = JsonConvert.DeserializeObject<ErrRespone>(serverMessage.Substring(5));//get the message
                MessageBox.Show(r.message);
                if (r.message == "Room has been cloesed")//if the err is because the remote has closed the room
                    leaveButton_Click(sender, e);
               
            }
            if ("" + serverMessage[0] == CODES.GET_ROOM_STATE_ID + "")
            {
                getRoomStateResponse stat = JsonConvert.DeserializeObject<getRoomStateResponse>(serverMessage.Substring(5));
                if (stat.hasGameBegun)
                    changeFormTo(new Game(stat.questionCount, stat.answerTimeout, isAdmin));
                createPlayersList(stat.players);
            }
        }
    }
}
