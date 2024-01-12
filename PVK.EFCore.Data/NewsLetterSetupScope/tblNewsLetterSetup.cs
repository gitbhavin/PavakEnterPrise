using PVK.EFCore.Data.BaseScope;
using System;
using System.Collections.Generic;
using System.Text;

namespace PVK.EFCore.Data.NewsLetterSetupScope
{
    public class tblNewsLetterSetup : BaseEntity
    {
        public string Guid_NewslatterId { get; set; }
        public string EmailId { get; set; }
    }
}
