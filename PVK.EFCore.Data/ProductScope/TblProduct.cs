using PVK.EFCore.Data.BaseScope;
using System;
using System.Collections.Generic;
using System.Text;

namespace PVK.EFCore.Data.ProductScope
{
    public class TblProduct : BaseEntity
    {
        public string Guid_ProductId { get; set; }
        public string ProductName { get; set; }
        public string Guid_CategoryId { get; set; }
        public string Guid_SubCategoryId { get; set; }
        public string Guid_SubSubCategoryId { get; set; }
        public string Short_Description { get; set; }
        public string Full_Description { get; set; }
        public double Price { get; set; }
        public string Guid_BrandId { get; set; }
        public bool Is_InSale { get; set; }

        public double Discount { get; set; }

        public string Thumbnail_Image_Url { get; set; }

        public double Available_Stock { get; set; }
     
    }
}
