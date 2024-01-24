using PVK.DTO.BaseResponse;
using System;
using System.Collections.Generic;
using System.Text;

namespace PVK.DTO.Product
{
    public class Addnewproduct : BaseRequest
    {
        public string ProductName { get; set; }
        public string Guid_CategoryId { get; set; }
        public string Guid_SubCategoryId { get; set; }
        public string Guid_SubSubCategoryId { get; set; }
        public string Guid_UnitId { get; set; }
        public string Short_Description { get; set; }
        public string Full_Description { get; set; }
        public double Price { get; set; }
        public string Guid_BrandId { get; set; }
        public bool Is_InSale { get; set; }
        public bool Is_Organic { get; set; }
        public string Tag { get; set; }
        public string DiscountType { get; set; }
        public double Discount { get; set; }
        public decimal TaxPercentage { get; set; }
        public string Thumbnail_Image_Url { get; set; }
        public double Available_Stock { get; set; }
        public decimal MaxPurchaseQty { get; set; }
    }
}
