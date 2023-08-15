using PVK.DTO.BaseResponse;
using System;
using System.Collections.Generic;
using System.Text;

namespace PVK.DTO.Banner
{
   public class BannerResponse: BaseResponsedata
    {
        public List<BannerData> bannerDatas { get; set; } = new List<BannerData>();
    }
}
