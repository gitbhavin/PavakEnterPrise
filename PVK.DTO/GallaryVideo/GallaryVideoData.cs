﻿using PVK.DTO.BaseResponse;
using System;
using System.Collections.Generic;
using System.Text;

namespace PVK.DTO.GallaryVideo
{
   public class GallaryVideoData: BaseRequest
    {
        public string GuidGallaryvideoid { get; set; }
        public string GuidGallaryid { get; set; }

        public string Gallaryname { get; set; }
        public string videourl { get; set; }
        public bool IsPrimery { get; set; }
    }
}
