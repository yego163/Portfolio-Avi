using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.classes
{
    public class resultPlayer
    {
        public string username;
        public int correctAnswerCount;
        public int wrongAnswerCount;
        public int averageAnswerTime;
    }
    public class resultResponse
    {
        public int status;
        public resultPlayer[] results;
    }
}
