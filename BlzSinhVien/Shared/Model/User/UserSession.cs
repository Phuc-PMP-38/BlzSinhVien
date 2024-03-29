﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlzSinhVien.Shared.Model.User
{
    public class UserSession : BLBase
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Token { get; set; }
        public string Role { get; set; }
        public int ExpiresIn { get; set; }
        public DateTime ExpiryTimeStamp { get; set; }
    }
}
