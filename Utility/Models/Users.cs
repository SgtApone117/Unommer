﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Unommer.Models
{
    public class Users
    {
        public string ConnectionId { get; set; }
        public string UserName { get; set; }
        public string UserImage { get; set; }
        public string LoginTime { get; set; }
        public string Email { get; set; }
    }
}