using PVK.EFCore.Data.UserScope;
using System;
using System.Collections.Generic;
using System.Text;

namespace PVK.DTO.Account
{
    public class AccountResponse 
    {
        public string userid { get; set; }
      
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public string Expiration { get; set; }
        public bool Status { get; set; }

    }
}
