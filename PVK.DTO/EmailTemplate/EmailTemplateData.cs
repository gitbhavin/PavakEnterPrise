using System;
using System.Collections.Generic;
using System.Text;

namespace PVK.DTO.EmailTemplate
{
   public class EmailTemplateData
    {
        public string Guid_EmailTemplateid { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
