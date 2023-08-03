using PVK.DTO.BaseResponse;
using System;
using System.Collections.Generic;
using System.Text;

namespace PVK.DTO.SMSTemplate
{
    public class SmsTemplateResponse: BaseResponsedata
    {
        public List<SmsTemplateData> smsTemplateDatas { get; set; } = new List<SmsTemplateData>();
       
    }
}
