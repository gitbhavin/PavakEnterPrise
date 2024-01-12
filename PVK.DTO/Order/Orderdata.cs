using PVK.EFCore.Data.OrderDetailscope;
using System;
using System.Collections.Generic;
using System.Text;

namespace PVK.DTO.Order
{
    public class Orderdata
    {
        public string Guid_OrderId { get; set; }
        public string Guid_UserId { get; set; }
        public decimal Discount { get; set; }
        public string Guid_PickupLocationId { get; set; }
        public decimal Tax { get; set; }
        public decimal Total { get; set; }
        public List<TblOrderDetail> orderDetails { get; set; }
    }
}
