using PVK.DTO.BaseResponse;
using System;
using System.Collections.Generic;
using System.Text;

namespace PVK.DTO.Address
{
   public class AddressResponse: BaseResponsedata
    {
        public List<AddressData> addressDatas { get; set; } = new List<AddressData>();
    }
}
