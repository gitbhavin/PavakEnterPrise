using PVK.DTO.BaseResponse;
using System;
using System.Collections.Generic;
using System.Text;

namespace PVK.DTO.BannerImage
{
    public class Deletebannerimage: BaseRequest
    {
        public string Guid_BannerImageId { get; set; }
    }
}
