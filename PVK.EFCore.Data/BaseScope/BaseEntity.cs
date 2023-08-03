using System;
using System.Collections.Generic;
using System.Text;

namespace PVK.EFCore.Data.BaseScope
{
    public class BaseEntity
    {
        public DateTime? Date_Inactive { get; set; }
        public DateTime? Date_Created { get; set; }
        public DateTime? Date_Modified { get; set; }
        public string Uid_Modified { get; set; }
        public string Uid_Created { get; set; }
    }
}
