using PVK.DTO.BaseResponse;
using System;
using System.Collections.Generic;
using System.Text;

namespace PVK.DTO.Gallary
{
   public class DeleteGallary: BaseRequest
    {
        public string GuidGallaryId { get; set; }
    }
}
