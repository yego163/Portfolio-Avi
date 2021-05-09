using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.classes
{
    public class RoomProp
    {
        public RoomProp(string _roomName, int _MaxUsers, int _questionCount, int _answerTimeout)
        {
            roomName = _roomName;
            maxUsers = _MaxUsers;
            questionCount = _questionCount;
            answerTimeout = _answerTimeout;
        }
        public string roomName { get; set; }
        public int maxUsers { get; set; }
        public int questionCount { get; set; }
        public int answerTimeout { get; set; }
    }
}
