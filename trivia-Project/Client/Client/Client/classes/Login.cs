using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class Login
    {
        public Login(string user, string pass)
        {
            username = user;
            password = pass;
        }
        public string username { get; set; }
        public string password { get; set; }
    }
}
