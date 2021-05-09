using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using Newtonsoft.Json;
using Client.classes;

namespace Client
{
    public partial class Signup : Form
    {
        public Signup()
        {
            InitializeComponent();
        }
        private void SignupButton_Click(object sender, EventArgs e)
        {
            string serverMessage = send.SignUpMessage(new SignupReq(Username.Text, Password.Text, email.Text));
            if ("" + serverMessage[0] == "" + (int)CODES.ERROR_ID)
            {
                ErrRespone r = JsonConvert.DeserializeObject<ErrRespone>(serverMessage.Substring(5));//get the message
                OUTPUT.Text = r.message;
                OUTPUT.ForeColor = Color.Red;//set the foreground to red
            }
            else if ("" + serverMessage[0] == "" + CODES.SIGNUP_ID)
            {
                if (JsonConvert.DeserializeObject<statusRespone>(serverMessage.Substring(5)).status == 1)
                    changeFormTo(new Menu());
                else
                {
                    OUTPUT.ForeColor = Color.Red;//set the foreground to red
                    OUTPUT.Text = "The Username has been took";
                }
            }
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

        private void ShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (ShowPassword.Checked)
            {
                Password.UseSystemPasswordChar = false;
            }
            else
            {
                Password.UseSystemPasswordChar = true;
            }
        }

        private void email_Click(object sender, EventArgs e)
        {
            email.Text = "";
        }

        private void Password_Click(object sender, EventArgs e)
        {
            Password.Text =  "";
        }

        private void Username_Click(object sender, EventArgs e)
        {
            Username.Text = "";
        }
    }
}
