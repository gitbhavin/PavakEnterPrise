using PVK.DTO.BaseResponse;
using System;
using System.Collections.Generic;
using System.Text;

namespace PVK.DTO.Review
{
    public class Deletereview: BaseRequest
    {
        public string Guid_ReviewId { get; set; }

    }
}
