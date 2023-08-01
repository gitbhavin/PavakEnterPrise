using System;
using System.Collections.Generic;
using System.Text;

namespace PVK.DTO.Account
{
   public class LoginRequest
    {
        //public string userid { get; set; }
        public string UserName { get; set; }
        //public string Email { get; set; }
        //public string MobileNumber { get; set; }
        public string Password { get; set; }
        public string GrantType { get; set; }
        //public string RefreshToken { get; set; }
    }
}
