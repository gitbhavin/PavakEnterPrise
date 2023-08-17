using PVK.DTO.BaseResponse;
using System;
using System.Collections.Generic;
using System.Text;

namespace PVK.DTO.GallaryImage
{
    public class GallaryImageData: BaseRequest
    {
        public string GuidGallaryimageid { get; set; }
        public string GuidGallaryid { get; set; }
        public string ImageUrl { get; set; }
        public bool IsPrimery { get; set; }
    }
}
