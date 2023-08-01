using PVK.EFCore.Data.BaseScope;
using System;
using System.Collections.Generic;
using System.Text;

namespace PVK.EFCore.Data.SMSTemplate
{
    public class TblSmsTemplate: BaseEntity
    {
        public string GuidSMSTemplateId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
