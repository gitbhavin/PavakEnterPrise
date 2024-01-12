using PVK.DTO.BaseResponse;
using System;
using System.Collections.Generic;
using System.Text;

namespace PVK.DTO.Newslattersetup
{
   public class Updatenewslatter : BaseRequest
    {
        public string Guid_NewslatterId { get; set; }
        public string EmailId { get; set; }
    }
}
