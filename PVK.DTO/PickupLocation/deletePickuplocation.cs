using PVK.DTO.BaseResponse;
using System;
using System.Collections.Generic;
using System.Text;

namespace PVK.DTO.PickupLocation
{
    public class deletePickuplocation : BaseRequest
    {
        public string Guid_PickupLocationId { get; set; }
    }
}
