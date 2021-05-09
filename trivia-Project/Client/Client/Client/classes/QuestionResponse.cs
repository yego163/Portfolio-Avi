using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.classes
{
    class QuestionResponse
    {
        public QuestionResponse(List<List<object>> _answers, string _question, int _status)
        {
            answers = _answers;
            question = _question;
            status = _status;
        }
        public List<List<object>> answers { get; set; }
        public string question { get; set; }
        public int status { get; set; }

    }
}