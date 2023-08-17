using PVK.DTO.BaseResponse;
using System;
using System.Collections.Generic;
using System.Text;

namespace PVK.DTO.Banner
{
   public class Updatebanner: BaseRequest
    {
        public string Guid_BannerId { get; set; }
        public string PageName { get; set; }
        public string SectionName { get; set; }
        public int Order_Sequence { get; set; }

    }
}
