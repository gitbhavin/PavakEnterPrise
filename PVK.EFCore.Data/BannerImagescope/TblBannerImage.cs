using PVK.EFCore.Data.BaseScope;
using System;
using System.Collections.Generic;
using System.Text;

namespace PVK.EFCore.Data.BannerImagescope
{
    public class TblBannerImage : BaseEntity
    {
        public string Guid_BannerImageId { get; set; }
        public string Guid_BannerId { get; set; }
        public string Image_Url { get; set; }
    }
}
