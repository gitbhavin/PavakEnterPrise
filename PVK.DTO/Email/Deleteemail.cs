using PVK.DTO.BaseResponse;
using System;
using System.Collections.Generic;
using System.Text;

namespace PVK.DTO.Email
{
   public class Deleteemail : BaseRequest
    {
        public string Guid_Emailid { get; set; }
    }
}
