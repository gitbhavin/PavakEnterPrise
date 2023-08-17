using System;
using System.Collections.Generic;
using System.Text;

namespace PVK.DTO.OrderStatus
{
   public class Orderstatusdata
    {
        public string Guid_OrderStatusId { get; set; }
        public string Guid_OrderId { get; set; }
        public string Status { get; set; }
        public bool Is_PickUp { get; set; }
        public DateTime Date_Status { get; set; }
    }
}
