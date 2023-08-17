using PVK.DTO.BaseResponse;
using PVK.EFCore.Data.BaseScope;
using System;
using System.Collections.Generic;
using System.Text;

namespace PVK.DTO.GallaryImage
{
    public class UpdateGallaryImage: BaseRequest
    {
        public string GuidGallaryimageid { get; set; }
        public string GuidGallaryid { get; set; }
        public string ImageUrl { get; set; }
        public bool IsPrimery { get; set; }
    }
}
