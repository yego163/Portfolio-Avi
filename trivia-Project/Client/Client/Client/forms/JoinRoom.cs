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

namespace Client
{
    public partial class JoinRoom : Form
    {
        private IDictionary<string, string> roomsId;
        public JoinRoom()
        {
            InitializeComponent();
            refreshButton_Click(null, null);
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
        private void createRoomList(String[] rooms)
        {
            roomsList.Items.Clear();
            roomsId = new Dictionary<string, string>();
            for (int i = 0; i < rooms.Length - 1; i += 2)//every couple
                roomsId.Add(rooms[i], rooms[i + 1]);
            String[] keys = roomsId.Keys.ToArray<string>();
            roomsList.Items.AddRange(keys);
        }
        private void createPlayersList(String[] players)
        {
            PlayersInRoomsList.Items.Clear();
            PlayersInRoomsList.Items.AddRange(players);
        }
        private void BackButton_Click(object sender, EventArgs e)
        {
            changeFormTo(new Menu());
        }
        private void JoinButton_Click(object sender, EventArgs e)
        {
            if(roomsList.SelectedIndex == -1) return;//if the user didnt choose anything
            string joinRoomMessage = send.JoinRoomMessage(roomsId[roomsList.GetItemText(roomsList.SelectedItem)]);
            if ("" + joinRoomMessage[0] == "" + (int)CODES.ERROR_ID)
            {
                ErrRespone r = JsonConvert.DeserializeObject<ErrRespone>(joinRoomMessage.Substring(5));//get the message
                ErrorTextBox.Text = r.message;
                ErrorTextBox.ForeColor = Color.Red;//set the foreground to red
            }
            else if ("" + joinRoomMessage[0] == (int)CODES.JOIN_ROOM_ID + "")
            {
                joinRoomRespone stat = JsonConvert.DeserializeObject<joinRoomRespone>(joinRoomMessage.Substring(5));
                if (stat.status == 1)
                {
                    changeFormTo(new AfterCreateOrJoinRoom(false, roomsId[roomsList.GetItemText(roomsList.SelectedItem)],new RoomProp(stat.roomName, 0, stat.questionCount, stat.answerTimeout)));
                }    
            }
        }

        private void roomsList_Click(object sender, EventArgs e)
        {
            string choice;
            try
            {
                choice = roomsId[roomsList.GetItemText(roomsList.SelectedItem)];
            }catch { return; }
            string serverMessage = send.GetPlayersInRoomRequest(choice);
            if ("" + serverMessage[0] == "" + (int)CODES.ERROR_ID)
            {
                ErrRespone r = JsonConvert.DeserializeObject<ErrRespone>(serverMessage.Substring(5));//get the message
                ErrorTextBox.Text = r.message;
                ErrorTextBox.ForeColor = Color.Red;//set the foreground to red
            }
            else if ("" + serverMessage[0] == (int)CODES.GET_PLAYERS_IN_ROOM_ID + "")
            {
                PlayersList stat = JsonConvert.DeserializeObject<PlayersList>(serverMessage.Substring(5));
                createPlayersList(stat.PlayersInRoom);
            }

        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            string serverMessage = send.GetRoomsMessage();
            if ("" + serverMessage[0] == "" + (int)CODES.ERROR_ID)
            {
                ErrRespone r = JsonConvert.DeserializeObject<ErrRespone>(serverMessage.Substring(5));//get the message
                ErrorTextBox.Text = r.message;
                ErrorTextBox.ForeColor = Color.Red;//set the foreground to red
            }
            else if ("" + serverMessage[0] == (int)CODES.GET_ROOMS_ID + "")
            {
                RoomsList stat = JsonConvert.DeserializeObject<RoomsList>(serverMessage.Substring(5));
                if (stat.Rooms != "")
                    ErrorTextBox.Text = "";
                PlayersInRoomsList.Items.Clear();
                createRoomList(stat.Rooms.Split(','));
            }
        }
    }
}
