using PVK.DTO.BaseResponse;
using System;
using System.Collections.Generic;
using System.Text;

namespace PVK.DTO.Order
{
   public class Deleteorder: BaseRequest
    {
        public string Guid_OrderId { get; set; }
    }
}
