using PVK.DTO.BaseResponse;
using System;
using System.Collections.Generic;
using System.Text;

namespace PVK.DTO.SmsUrl
{
   public class updateSmsurl: BaseRequest
    {
        public string GuidSMSURL { get; set; }
        public string Url { get; set; }
    }
}
