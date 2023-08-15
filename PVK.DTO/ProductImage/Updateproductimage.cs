using PVK.DTO.BaseResponse;
using System;
using System.Collections.Generic;
using System.Text;

namespace PVK.DTO.ProductImage
{
    public class Updateproductimage : BaseRequest
    {
        public string Guid_ProductId { get; set; }
        public bool Is_Primary { get; set; }
    }
}
