﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PVK.DTO.Account
{
    public class UserRequest
    {
      
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public string Password { get; set; }
        public string Source { get; set; }
    }
}
