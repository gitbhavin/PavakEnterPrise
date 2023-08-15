using PVK.EFCore.Data.BaseScope;
using System;
using System.Collections.Generic;
using System.Text;

namespace PVK.EFCore.Data.EmailScope
{
    public class TblEmail: BaseEntity
    {
       public string Guid_Emailid { get; set; }

        public string FromAddress { get; set; }

        public string ToAddress { get; set; }

        public string BccAddress { get; set; }

        public string Subject { get; set; }
        public string Body { get; set; }
       
    }
}
