using PVK.DTO.BaseResponse;
using System;
using System.Collections.Generic;
using System.Text;

namespace PVK.DTO.BannerImage
{
   public class BannerimageResponse: BaseResponsedata
    {
        public List<Bannerimagedata> bannerimagedatas { get; set; } = new List<Bannerimagedata>();
    }
}
