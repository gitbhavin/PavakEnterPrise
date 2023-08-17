using PVK.EFCore.Data.BaseScope;
using System;
using System.Collections.Generic;
using System.Text;

namespace PVK.EFCore.Data.GallaryImageScope
{
    public class TblGallaryImage: BaseEntity
    {
        public string GuidGallaryimageid { get; set; }
        public string GuidGallaryid { get; set; }
        public string ImageUrl { get; set; }
        public bool IsPrimery { get; set; }
    }
}
