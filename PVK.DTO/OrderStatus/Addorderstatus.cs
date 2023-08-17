using PVK.DTO.BaseResponse;
using System;
using System.Collections.Generic;
using System.Text;

namespace PVK.DTO.OrderStatus
{
    public class Addorderstatus : BaseRequest
    {
        public string Guid_OrderId { get; set; }
        public string Status { get; set; }
        public bool Is_PickUp { get; set; }
        public DateTime Date_Status { get; set; }
    }
}
