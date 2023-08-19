using PVK.DTO.BaseResponse;
using System;
using System.Collections.Generic;
using System.Text;

namespace PVK.DTO.GallaryImage
{
    public class GallaryImageResponse: BaseResponsedata
    {
        public List<GallaryImageData> gallaryImageDatas { get; set; } = new List<GallaryImageData>();
    }
}
