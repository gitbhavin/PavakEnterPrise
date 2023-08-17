using PVK.DTO.BaseResponse;
using System;
using System.Collections.Generic;
using System.Text;

namespace PVK.DTO.Product
{
   public class ProductResponse : BaseResponsedata
    {
        public List<ProductData> productDatas { get; set; } = new List<ProductData>();

    }
}
