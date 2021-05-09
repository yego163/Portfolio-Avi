using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.classes
{
    class PlayersList
    {
        public PlayersList(String[] players)
        {
            this.PlayersInRoom = players;
        }
        public String[] PlayersInRoom { get; set; }
    }
}
