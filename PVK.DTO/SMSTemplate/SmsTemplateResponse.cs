using System;
using System.Collections.Generic;
using System.Text;

namespace PVK.DTO.SMSTemplate
{
    public class SmsTemplateResponse
    {
        public List<SmsTemplateData> smsTemplateDatas { get; set; } = new List<SmsTemplateData>();
        public string Message { get; set; }
        public bool Status { get; set; }
    }
}
