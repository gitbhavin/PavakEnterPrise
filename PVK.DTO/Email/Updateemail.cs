using PVK.DTO.BaseResponse;
using System;
using System.Collections.Generic;
using System.Text;

namespace PVK.DTO.Email
{
   public class UpdateEmail: BaseRequest
    {
        public string Guid_Emailid { get; set; }

        public string FromAddress { get; set; }

        public string ToAddress { get; set; }

        public string BccAddress { get; set; }

        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
