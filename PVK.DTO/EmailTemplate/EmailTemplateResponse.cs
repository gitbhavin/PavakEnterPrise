using PVK.DTO.BaseResponse;
using System;
using System.Collections.Generic;
using System.Text;

namespace PVK.DTO.EmailTemplate
{
    public class EmailTemplateResponse : BaseResponsedata
    {
        public List<EmailTemplateData> emailTemplateDatas { get; set; } = new List<EmailTemplateData>();
    }
}
