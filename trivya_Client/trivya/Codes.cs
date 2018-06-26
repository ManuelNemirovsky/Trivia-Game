using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trivya
{
    public class Codes
    {
        public const string SIGN_IN = "200";
        public const string SIGN_OUT = "201";
        public const string SIGN_IN_ANS = "102";
        public const string SIGN_UP = "203";
        public const string SIGN_UP_ANS = "104";
        public const string GET_ROOMS = "205";
        public const string GET_ROOMS_ANS = "106";
        public const string GET_USERS = "207";
        public const string GET_USERS_ANS = "108";
        public const string JOIN_ROOM = "209";
        public const string JOIN_ROOM_ANS = "110";
        public const string LEAVE_ROOM = "211";
        public const string LEAVE_ROOM_ANS = "112";
        public const string CREATE_ROOM = "213";
        public const string CREATE_ROOM_ANS = "114";
        public const string CLOSE_ROOM = "215";
        public const string CLOSE_ROOM_ANS = "116";
        public const string START_GAME = "217";
        public const string SERVER_QUESTION = "118";
        public const string SEND_ANSWER = "219";
        public const string SEND_ANSWER_ANS = "120";
        public const string GAME_OVER = "121";
        public const string LEAVE_GANE = "222";
        public const string GET_BEST_SCORES = "223";
        public const string BEST_SCORES_ANS = "124";
        public const string GET_MY_STATUS = "225";
        public const string MY_STATUS_ANS = "126";
        public const string QUIT = "229";

        public const int CODE_LEN = 3;
        public const int USERLEN = 2;
        public const int PASSLEN = 2;
        public const int EMAILLEN = 2;
        public const int ROOM_NAME_LEN = 2;
        public const int ROOM_ID_LEN = 4;

        public const int PLAYERS_LEN = 1;
        public const int QUESTIONS_NUM_LEN = 2;
        public const int TIME_PER_QUESTION_LEN = 2;
    }
}
