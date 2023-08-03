using PVK.DTO.BaseResponse;
using System;
using System.Collections.Generic;
using System.Text;

namespace PVK.DTO.Brand
{
   public class updatebrand: BaseRequest
    {
        public string GuidBrandId { get; set; }
        public string BrandName { get; set; }
    }
}
