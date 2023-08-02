using PVK.EFCore.Data.BaseScope;
using System;
using System.Collections.Generic;
using System.Text;

namespace PVK.EFCore.Data.SmsUrlScope
{
   public class TblSmsurl : BaseEntity
    {
        public string GuidSMSURL { get; set; }
        public string Url { get; set; }   
    }
}
