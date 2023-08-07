using PVK.DTO.BaseResponse;
using System;
using System.Collections.Generic;
using System.Text;

namespace PVK.DTO.Role
{
   public class RoleResponse : BaseResponsedata
    {
        public List<RoleData> RoleDatas { get; set; } = new List<RoleData>();
    }
}
