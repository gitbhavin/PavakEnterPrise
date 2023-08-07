using PVK.EFCore.Data.BaseScope;
using PVK.EFCore.Data.TokenScope;
using System;
using System.Collections.Generic;
using System.Text;

namespace PVK.EFCore.Data.UserScope
{
    public class TblUser : BaseEntity
    {
        public string Guid_Userid { get; set; }
        public int? VersionId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string  Email { get; set; }
        public string  Phone { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string IMG_URL { get; set; }
        public string  Gender { get; set; }
        
        public string Source { get; set; }



    }
}
