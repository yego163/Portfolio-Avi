using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.classes
{
    class joinRoomRespone
    {
        public joinRoomRespone(int _answerTimeout, int _questionCount, string _Room_name, int stat)
        {
            answerTimeout = _answerTimeout;
            questionCount = _questionCount;
            roomName = _Room_name;
            status = stat;
        }
        public int status;
        public int answerTimeout;
        public string roomName;
        public int questionCount;
    }
}
