using System;
using System.Collections.Generic;
using System.Text;

namespace PVK.DTO.UserRole
{
   public class UserRoleData
    {
        public string Guid_UserRoleId { get; set; }
        public string Guid_UserId { get; set; }

        public string UserName { get; set; }

        public string Guid_RoleId { get; set; }
        public string RoleName { get; set; }
    }
}
