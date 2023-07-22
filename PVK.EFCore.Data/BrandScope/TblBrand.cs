using PVK.EFCore.Data.BaseScope;
using System;
using System.Collections.Generic;
using System.Text;

namespace PVK.EFCore.Data.BrandScope
{
   public class TblBrand : BaseEntity
    {
        public string GuidBrandId { get; set; }
        public string BrandName { get; set; }
    }
}
