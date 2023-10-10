using PVK.DTO.BaseResponse;
using System;
using System.Collections.Generic;
using System.Text;

namespace PVK.DTO.PickupLocation
{
    public class PickupLocationResponse: BaseResponsedata
    {
        public List<PickupLocationdata> pickuplocationDatas { get; set; } = new List<PickupLocationdata>();
    }
}
