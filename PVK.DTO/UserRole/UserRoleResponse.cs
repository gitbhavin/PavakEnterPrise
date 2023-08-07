using PVK.DTO.BaseResponse;
using System;
using System.Collections.Generic;
using System.Text;

namespace PVK.DTO.UserRole
{
    public class UserRoleResponse : BaseResponsedata
    {
      public  List<UserRoleData> userRoleDatas { get; set; } = new List<UserRoleData>();
    }
}
