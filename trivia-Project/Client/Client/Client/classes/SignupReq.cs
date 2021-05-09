using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class SignupReq
    { 
        public SignupReq(string userName, string pass, string email)
        {
            username = userName;
            password = pass;
            this.email = email;
        }
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
    }
}
