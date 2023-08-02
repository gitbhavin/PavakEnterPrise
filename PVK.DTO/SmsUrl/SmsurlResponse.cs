using System;
using System.Collections.Generic;
using System.Text;

namespace PVK.DTO.SmsUrl
{
   public class SmsurlResponse
    {
        public List<SmsurlData> Smsurldata { get; set; } = new List<SmsurlData>();
        public string Message { get; set; }
        public bool Status { get; set; }

    }
}
