using PVK.EFCore.Data.BaseScope;
using System;
using System.Collections.Generic;
using System.Text;

namespace PVK.EFCore.Data.GallaryScope
{
    public class TblGallary: BaseEntity
    {
        public string GuidGallaryId { get; set; }
        public string Name { get; set; }
    }
}
