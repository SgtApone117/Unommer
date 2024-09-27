using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Unommer;
using Unommer.Chat_Unommer;

namespace Unommer.Chat_Unommer
{
    public class Messages
    {
        public string UserName { get; set; }

        public string Message { get; set; }

        public string Time { get; set; }

        public string UserImage { get; set; }

        public string Email { get; set; }

        public string FromUserName { get; set; }

        public string ToUserName { get; set; }

        public string FromEmail { get; set; }

        public string ToEmail { get; set; }

        public int ID { get; set; }
    }
}