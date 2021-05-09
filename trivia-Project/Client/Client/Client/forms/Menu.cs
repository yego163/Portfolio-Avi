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
using Client.forms;

namespace Client
{
    public partial class Menu : Form
    {
        public Menu()
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

        private void JoinRoomButton(object sender, EventArgs e)
        {
            changeFormTo(new JoinRoom());
        }
        private void Menu_Load(object sender, EventArgs e)
        {

        }
        private void ExitButton_Click(object sender, EventArgs e)
        {
            send.logOut();
            this.Close();
        }

        private void CreateRoomButton_Click(object sender, EventArgs e)
        {
            changeFormTo(new CreateRoom());
        }

        private void OUTPUT_Click(object sender, EventArgs e)
        {

        }

        private void MyStatus_Click(object sender, EventArgs e)
        {
            changeFormTo(new Mystatus());
        }

        private void BestScores_Click(object sender, EventArgs e)
        {
            changeFormTo(new BestScores());
        }
    }
}
