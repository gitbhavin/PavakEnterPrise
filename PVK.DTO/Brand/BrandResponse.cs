using PVK.DTO.BaseResponse;
using System;
using System.Collections.Generic;
using System.Text;

namespace PVK.DTO.Brand
{
    public class BrandResponse: BaseResponsedata
    {
        public List<BrandData> Brands { get; set; } = new List<BrandData>();
      


    }
}
