using PVK.DTO.BaseResponse;
using System;
using System.Collections.Generic;
using System.Text;

namespace PVK.DTO.ContactUs
{
   public class DeleteContactUs: BaseRequest
    {
        public string GuidContactusid { get; set; }
    }
}
