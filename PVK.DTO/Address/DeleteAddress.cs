using PVK.DTO.BaseResponse;
using System;
using System.Collections.Generic;
using System.Text;

namespace PVK.DTO.Address
{
   public class DeleteAddress: BaseRequest
    {
        public string GuidAddressId { get; set; }

    }
}
