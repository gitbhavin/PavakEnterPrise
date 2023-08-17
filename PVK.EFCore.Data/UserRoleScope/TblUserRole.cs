using PVK.EFCore.Data.BaseScope;
using System;
using System.Collections.Generic;
using System.Text;

namespace PVK.EFCore.Data.UserRoleScope
{
    public class TblUserRole : BaseEntity
    {
        public string Guid_UserRoleId { get; set; }
        public string Guid_UserId { get; set; }
        public string Guid_RoleId { get; set; }
    }
}
