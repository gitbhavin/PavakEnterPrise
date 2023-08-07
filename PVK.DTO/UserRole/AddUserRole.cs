using PVK.DTO.BaseResponse;
using System;
using System.Collections.Generic;
using System.Text;

namespace PVK.DTO.UserRole
{
   public class AddUserRole :  BaseRequest
    {
      
        public string Guid_UserId { get; set; }
        public string Guid_RoleId { get; set; }
    }
}
