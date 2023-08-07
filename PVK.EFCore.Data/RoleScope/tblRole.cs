using PVK.EFCore.Data.BaseScope;
using System;
using System.Collections.Generic;
using System.Text;

namespace PVK.EFCore.Data.RoleScope
{
    public class tblRole : BaseEntity
    {
        public string Guid_RoleId { get; set; }
        public string RoleName { get; set; }
    }
}
