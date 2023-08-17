using PVK.DTO.BaseResponse;
using System;
using System.Collections.Generic;
using System.Text;

namespace PVK.DTO.GallaryVideo
{
    public class AddGallaryVideoData: BaseRequest
    {
        public string GuidGallaryid { get; set; }
        public string videourl { get; set; }
        public bool IsPrimery { get; set; }
    }
}
