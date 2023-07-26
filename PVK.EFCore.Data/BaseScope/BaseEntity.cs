using System;
using System.Collections.Generic;
using System.Text;

namespace PVK.EFCore.Data.BaseScope
{
    public class BaseEntity
    {
        public DateTime? DateInactive { get; set; }
        public DateTime? Date_Created { get; set; }
        public DateTime? Date_Modified { get; set; }
        public DateTime? Uid_Modified { get; set; }
    }
}
