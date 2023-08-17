using PVK.DTO.BaseResponse;
using System;
using System.Collections.Generic;
using System.Text;

namespace PVK.DTO.ProductImage
{
    public class Deleteproductimage : BaseRequest
    {
        public string Guid_ProductImageId { get; set; }
    }
}
