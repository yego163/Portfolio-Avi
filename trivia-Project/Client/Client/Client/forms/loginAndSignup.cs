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

namespace Client
{
    public partial class loginAndSignup : Form
    {
        public loginAndSignup()
        {
            send.start();//hello thing
            InitializeComponent();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void toLogin_Click(object sender, EventArgs e)
        {
            G.myName = username.Text;
            string serverMessage = send.LoginMessage(new Login(username.Text, password.Text));
            if ("" + serverMessage[0] == "" +(int)CODES.ERROR_ID)
            {
                ErrRespone r = JsonConvert.DeserializeObject<ErrRespone>(serverMessage.Substring(5));//get the message
                OUTPUT.Text = r.message;
                OUTPUT.ForeColor = Color.Red;//set the foreground to red
            }
            else if("" + serverMessage[0] == (int)CODES.LOGIN_ID + "")
            {
                statusRespone stat = JsonConvert.DeserializeObject<statusRespone>(serverMessage.Substring(5));
                if (stat.status == 1)//if this ok
                    changeFormTo(new Menu());
                else
                {
                    OUTPUT.ForeColor = Color.Red;//set the foreground to red
                    OUTPUT.Text = "username or password dont match";
                }
            }
        }
        private void toSignup_Click(object sender, EventArgs e)
        {
            changeFormTo(new Signup());
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

        private void checkBox_ShowPassword(object sender, EventArgs e)
        {
            if(showPassword.Checked)
            {
                password.UseSystemPasswordChar = false;
            }
            else
            {
                password.UseSystemPasswordChar = true;
            }
        }

        private void username_Click(object sender, EventArgs e)
        {
            username.Text = "";
        }

        private void password_Click(object sender, EventArgs e)
        {
            password.Text = "";
        }
    }
}
