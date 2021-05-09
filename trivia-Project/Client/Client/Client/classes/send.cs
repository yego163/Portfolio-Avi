using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Client.classes
{
    public static class send
    {
        private static string getStringFromServer()
        {
            byte[] buffer = new byte[5], data = new byte[4096];
            int bytesRead = G.clientStream.Read(buffer, 0, 5);
            int byteRead = G.clientStream.Read(data, 0, int.Parse(System.Text.Encoding.UTF8.GetString(buffer).Substring(1)));
            return System.Text.Encoding.UTF8.GetString(buffer) + System.Text.Encoding.UTF8.GetString(data);//get the string
        }
        public static void start()
        {
            byte[] buffer = new ASCIIEncoding().GetBytes("hello");//create the command
            G.clientStream.Write(buffer, 0, buffer.Length);//send
            G.clientStream.Flush();
            buffer = new byte[100];
            int bytesRead = G.clientStream.Read(buffer, 0, 5);
        }
        public static string LoginMessage(Login login)
        {
            string data = JsonConvert.SerializeObject(login, Formatting.Indented);//create the data
            byte[] buffer = new ASCIIEncoding().GetBytes(CODES.LOGIN_ID + (data.Length + "").PadLeft(4, '0') + data);//create the command
            G.clientStream.Write(buffer, 0, buffer.Length);//send
            G.clientStream.Flush();
            return getStringFromServer();
        }
        public static string SignUpMessage(SignupReq sig)
        {
            string data = JsonConvert.SerializeObject(sig, Formatting.Indented);//create the data
            byte[] buffer = new ASCIIEncoding().GetBytes(CODES.SIGNUP_ID + (data.Length + "").PadLeft(4, '0') + data);//create the command
            G.clientStream.Write(buffer, 0, buffer.Length);//send
            G.clientStream.Flush();
            return getStringFromServer();
        }
        public static string JoinRoomMessage(string roomId)
        {
            if (roomId == "") return "30003Err";
            roomId = "{\"roomId\":" + roomId + "}";
            byte[] buffer = new ASCIIEncoding().GetBytes(CODES.JOIN_ROOM_ID + (roomId.Length + "").PadLeft(4, '0') + roomId);//create the comman
            G.clientStream.Write(buffer, 0, buffer.Length);//send
            G.clientStream.Flush();
            return getStringFromServer();
        }
        public static string GetRoomsMessage()
        {
            byte[] buffer = new ASCIIEncoding().GetBytes(CODES.GET_ROOMS_ID + "0000");//create the comman
            G.clientStream.Write(buffer, 0, buffer.Length);//send
            G.clientStream.Flush();
            return getStringFromServer();
        }
        public static string CreateRoom(RoomProp createRoom)
        {
            string data = JsonConvert.SerializeObject(createRoom, Formatting.Indented);//create the data
            byte[] buffer = new ASCIIEncoding().GetBytes(CODES.CREATE_ROOM_ID + (data.Length + "").PadLeft(4, '0') + data);//create the comman
            G.clientStream.Write(buffer, 0, buffer.Length);//send
            G.clientStream.Flush();
            return getStringFromServer();
        }
        public static string GetPlayersInRoomRequest(string roomId)
        {
            if (roomId == "") return "30003Err";
            roomId = "{\"roomId\":" + roomId + "}";
            byte[] buffer = new ASCIIEncoding().GetBytes(CODES.GET_PLAYERS_IN_ROOM_ID + (roomId.Length + "").PadLeft(4, '0') + roomId);//create the comman
            G.clientStream.Write(buffer, 0, buffer.Length);//send
            G.clientStream.Flush();
            return getStringFromServer();
        }
        public static string GetHighScore()
        {
            byte[] buffer = new ASCIIEncoding().GetBytes(CODES.HIGH_SCORE_ID + "0000");//create the comman
            G.clientStream.Write(buffer, 0, buffer.Length);//send
            G.clientStream.Flush();
            return getStringFromServer();
        }
        public static void logOut()
        {
            byte[] buffer = new ASCIIEncoding().GetBytes(CODES.LOGOUT_ID + "0000");//logout
            G.clientStream.Write(buffer, 0, buffer.Length);//send
            G.clientStream.Flush();
            getStringFromServer();
            G.socket.Close();
        }
        public static string leaveRoom() {
            byte[] buffer = new ASCIIEncoding().GetBytes(CODES.LEAVE_ROOM_ID + "0000");//create the comman
            G.clientStream.Write(buffer, 0, buffer.Length);//send
            G.clientStream.Flush();
            return getStringFromServer();
        }
        public static string startGame()
        {
            byte[] buffer = new ASCIIEncoding().GetBytes(CODES.START_GAME_ID + "0000");//create the comman
            G.clientStream.Write(buffer, 0, buffer.Length);//send
            G.clientStream.Flush();
            return getStringFromServer();
        }
        public static string closeRoom()
        {
            byte[] buffer = new ASCIIEncoding().GetBytes(CODES.CLOSE_ROOM_ID + "0000");//create the comman
            G.clientStream.Write(buffer, 0, buffer.Length);//send
            G.clientStream.Flush();
            return getStringFromServer();
        }
        public static string getRoomState()
        {
            byte[] buffer = new ASCIIEncoding().GetBytes(CODES.GET_ROOM_STATE_ID + "0000");//create the comman
            G.clientStream.Write(buffer, 0, buffer.Length);//send
            G.clientStream.Flush();
            return getStringFromServer();
        }
        public static string leaveGame()
        {
            byte[] buffer = new ASCIIEncoding().GetBytes(CODES.LEAVE_GAME_CODE + "0000");//create the comman
            G.clientStream.Write(buffer, 0, buffer.Length);//send
            G.clientStream.Flush();
            return getStringFromServer();
        }
        public static string getQuestion()
        {
            byte[] buffer = new ASCIIEncoding().GetBytes(CODES.GET_QUESION_CODE + "0000");//create the comman
            G.clientStream.Write(buffer, 0, buffer.Length);//send
            G.clientStream.Flush();
            return getStringFromServer();
        }
        public static string getGameResult()
        {
            byte[] buffer = new ASCIIEncoding().GetBytes(CODES.GET_GAME_RESULT_CODE + "0000");//create the comman
            G.clientStream.Write(buffer, 0, buffer.Length);//send
            G.clientStream.Flush();
            return getStringFromServer();
        }
        public static string submitAnswer(submitAns ans)
        {
            string data = JsonConvert.SerializeObject(ans, Formatting.Indented);//create the data
            byte[] buffer = new ASCIIEncoding().GetBytes(CODES.SUBMIT_ANSWER_CODE + (data.Length + "").PadLeft(4, '0') + data);//create the comman
            G.clientStream.Write(buffer, 0, buffer.Length);//send
            G.clientStream.Flush();
            return getStringFromServer();
        }
        public static string EndGame()
        {
            byte[] buffer = new ASCIIEncoding().GetBytes(CODES.END_GAME_RESULT_CODE + "0000");//create the command
            G.clientStream.Write(buffer, 0, buffer.Length);//send
            G.clientStream.Flush();
            return getStringFromServer();
        }
    }
}
