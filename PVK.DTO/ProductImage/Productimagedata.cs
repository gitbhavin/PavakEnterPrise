using System;
using System.Collections.Generic;
using System.Text;

namespace PVK.DTO.ProductImage
{
    public class Productimagedata
    {
        public string Guid_ProductImageId { get; set; }
        public string Guid_ProductId { get; set; }
        public string Image_Url { get; set; }
        public bool Is_Primary { get; set; }
        public string ProductName { get; set; }
    }
}
