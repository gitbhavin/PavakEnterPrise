﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PVK.DTO.SMSTemplate
{
   public class SmsTemplateData
    {
        public string GuidSMSTemplateId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
