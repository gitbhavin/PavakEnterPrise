using System;
using System.Collections.Generic;
using System.Text;

namespace PVK.DTO.Product
{
    public class ProductData
    {
        public string Guid_ProductId { get; set; }
        public string ProductName { get; set; }
        public string Guid_CategoryId { get; set; }
        public string Guid_UnitId { get; set; }
        public string Category { get; set; }
        public string Guid_SubCategoryId { get; set; }
        public string SubCategory { get; set; }
        public string Guid_SubSubCategoryId { get; set; }
        public string SubsubCategory { get; set; }
        public string Short_Description { get; set; }
        public string Full_Description { get; set; }
        public decimal Price { get; set; }
        public string Guid_BrandId { get; set; }
        public decimal TaxPercentage { get; set; }
        public string BrandName { get; set; }
        public bool Is_InSale { get; set; }
        public bool Is_Organic { get; set; }
        public string Tag { get; set; }
        public string DiscountType { get; set; }
        public decimal Discount { get; set; }

        public string Thumbnail_Image_Url { get; set; }
        public decimal MaxPurchaseQty { get; set; }
        public decimal Available_Stock { get; set; }

    }
}
