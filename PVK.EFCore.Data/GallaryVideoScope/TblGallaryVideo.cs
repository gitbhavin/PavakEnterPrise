using PVK.EFCore.Data.BaseScope;
using System;
using System.Collections.Generic;
using System.Text;

namespace PVK.EFCore.Data.GallaryVideoScope
{
    public class TblGallaryVideo: BaseEntity
    {
        public string GuidGallaryvideoid { get; set; }
        public string GuidGallaryid { get; set; }
        public string videourl { get; set; }
        public bool IsPrimery { get; set; }
    }
}
