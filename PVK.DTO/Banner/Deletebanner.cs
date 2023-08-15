using PVK.DTO.BaseResponse;
using System;
using System.Collections.Generic;
using System.Text;

namespace PVK.DTO.Banner
{
    public class Deletebanner : BaseRequest
    {
        public string Guid_BannerId { get; set; }
    }
}
