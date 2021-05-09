using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.classes
{
    class RoomsList
    {
        public RoomsList(string rooms)
        {
            this.Rooms = rooms;
        }
        public override string ToString()
        {
            return Rooms;
        }
       public string Rooms { get; set; }
    }
}
