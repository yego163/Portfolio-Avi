using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.classes
{
    public static class CODES
    {
        public static int LOGIN_ID = 1;
        public static int SIGNUP_ID = 2;
        public static int ERROR_ID = 3;
        public static int LOGOUT_ID = 4;
        public static int GET_ROOMS_ID = 5;
        public static int GET_PLAYERS_IN_ROOM_ID = 6;
        public static int JOIN_ROOM_ID = 7;
        public static int CREATE_ROOM_ID = 8;
        public static int HIGH_SCORE_ID = 9;
        public static int CLOSE_ROOM_ID = 0;
        public static char START_GAME_ID = 'A';
        public static char GET_ROOM_STATE_ID = 'B';
        public static char LEAVE_ROOM_ID = 'C';
        public static char LEAVE_GAME_CODE = 'D';
        public static char GET_QUESION_CODE = 'E';
        public static char SUBMIT_ANSWER_CODE = 'F';
        public static char GET_GAME_RESULT_CODE = 'G';
        public static char END_GAME_RESULT_CODE = 'H';

    }
    class statusRespone
    {
        public statusRespone(int stat)
        {
            status = stat;
        }
        public int status;
        public override string ToString()
        {
            return "" + status;
        }
    }
}
