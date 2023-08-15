using PVK.EFCore.Data.BaseScope;
using System;
using System.Collections.Generic;
using System.Text;

namespace PVK.EFCore.Data.ProductImageScope
{
    public class TblProductImage: BaseEntity
    {
        public string Guid_ProductImageId { get; set; }

        public string Guid_ProductId { get; set; }
        public string Image_Url { get; set; }
        public bool Is_Primary { get; set; }
       
    }
}
