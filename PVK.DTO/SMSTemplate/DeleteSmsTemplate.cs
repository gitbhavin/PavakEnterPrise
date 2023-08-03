using PVK.DTO.BaseResponse;
using System;
using System.Collections.Generic;
using System.Text;

namespace PVK.DTO.SMSTemplate
{
    public class DeleteSmsTemplate: BaseRequest
    {
        public string GuidSMSTemplateId { get; set; }
    }
}
