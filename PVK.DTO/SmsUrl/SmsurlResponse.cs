using PVK.DTO.BaseResponse;
using System;
using System.Collections.Generic;
using System.Text;

namespace PVK.DTO.SmsUrl
{
   public class SmsurlResponse: BaseResponsedata
    {
        public List<SmsurlData> Smsurldata { get; set; } = new List<SmsurlData>();
        

    }
}
