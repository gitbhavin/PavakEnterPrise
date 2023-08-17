using PVK.EFCore.Data.BaseScope;
using System;
using System.Collections.Generic;
using System.Text;

namespace PVK.EFCore.Data.BannerScope
{
    public class TblBanner: BaseEntity
    {
        public string Guid_BannerId { get; set; }
        public string PageName { get; set; }
        public string SectionName { get; set; }
        public int Order_Sequence { get; set; }
       
    }
}
