using PVK.EFCore.Data.BaseScope;
using PVK.EFCore.Data.UserScope;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace PVK.EFCore.Data.TokenScope
{
   public class UserToken : BaseEntity
    {
        public string Guid_UserTokenId { get; set; }

        public string Guid_UserId { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public DateTimeOffset? AccessToken_Expiry { get; set; }
        public DateTimeOffset? RefreshToken_Expiry { get; set; }
      
    }
}
