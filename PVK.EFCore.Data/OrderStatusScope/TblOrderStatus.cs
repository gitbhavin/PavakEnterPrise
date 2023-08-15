using PVK.EFCore.Data.BaseScope;
using System;
using System.Collections.Generic;
using System.Text;

namespace PVK.EFCore.Data.OrderStatusScope
{
    public class TblOrderStatus : BaseEntity
    {
        public string Guid_OrderStatusId { get; set; }
        public string Guid_OrderId { get; set; }
        public string Status { get; set; }
        public bool Is_PickUp { get; set; }
        public DateTime Date_Status { get; set; }
       
    }
}
