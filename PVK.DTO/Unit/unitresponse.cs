using PVK.DTO.BaseResponse;
using PVK.DTO.SmsUrl;
using System;
using System.Collections.Generic;
using System.Text;

namespace PVK.DTO.Unit
{
    public class unitresponse : BaseResponsedata
    {
        public List<unitdata> unitdata { get; set; } = new List<unitdata>();
    }
}
