using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.classes
{
    class HighScoreResponse
    {
        public HighScoreResponse(String UserStatistics, String HighScores)
        {
            this.UserStatistics = UserStatistics;
            this.HighScores = HighScores;
        }
        public string UserStatistics { get; set; }
        public string HighScores { get; set; }
    }
}
