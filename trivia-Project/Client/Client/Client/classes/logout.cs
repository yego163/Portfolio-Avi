using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.classes
{
    public class logout
    {
        public string username { get; set; }
        public logout(string userName)
        {
            username = userName;
        }
    }
}
