using PVK.DTO.BaseResponse;
using System;
using System.Collections.Generic;
using System.Text;

namespace PVK.DTO.BannerImage
{
   public class Bannerimagedata : BaseResponsedata
    {
        public string Guid_BannerImageId { get; set; }
        public string Guid_BannerId { get; set; }
        public string Image_Url { get; set; }
    }
}
