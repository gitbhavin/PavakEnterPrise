using PVK.DTO.BaseResponse;
using System;
using System.Collections.Generic;
using System.Text;

namespace PVK.DTO.SMSTemplate
{
   public class UpdateSmsTemplate: BaseRequest
    {
        public string GuidSMSTemplateId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
