using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.classes
{
    class CreateRoomRespone
    {
        public CreateRoomRespone(int _ID,int stat)
        { 
            ID = _ID;
            status = stat;
        }
        public int status;
        public int ID;
        public override string ToString()
        {
            return "" + ID;
        }
    }
}
