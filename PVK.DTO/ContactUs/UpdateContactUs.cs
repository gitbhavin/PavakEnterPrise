using PVK.DTO.BaseResponse;
using System;
using System.Collections.Generic;
using System.Text;

namespace PVK.DTO.ContactUs
{
   public class UpdateContactUs: BaseRequest
    {
        public string GuidContactusid { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Message { get; set; }
    }
}
