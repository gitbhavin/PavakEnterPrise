using PVK.DTO.BaseResponse;
using System;
using System.Collections.Generic;
using System.Text;

namespace PVK.DTO.ProductImage
{
    public class ProdcutimageResponse : BaseResponsedata
    {
        public List<Productimagedata> productimagedatas { get; set; } = new List<Productimagedata>();
    }
}
