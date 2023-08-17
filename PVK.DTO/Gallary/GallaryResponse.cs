using PVK.DTO.BaseResponse;
using System;
using System.Collections.Generic;
using System.Text;

namespace PVK.DTO.Gallary
{
    public class GallaryResponse: BaseResponsedata
    {
        public List<GallaryData> gallaryDatas { get; set; } = new List<GallaryData>();
    }
}
