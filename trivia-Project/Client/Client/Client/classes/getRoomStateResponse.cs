using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.classes
{
    class getRoomStateResponse
    {
        public getRoomStateResponse(int _answerTimeout, bool _hasGameBegun, string[] _players, int _questionCount, int _status)
        {
            answerTimeout = _answerTimeout;
            hasGameBegun = _hasGameBegun;
            players = _players;
            questionCount = _questionCount;
            status = _status;
        }
        public int status { get; set; }
        public bool hasGameBegun { get; set; }
        public string[] players { get; set; }
        public int questionCount { get; set; }
        public int answerTimeout { get; set; }
    }
}
