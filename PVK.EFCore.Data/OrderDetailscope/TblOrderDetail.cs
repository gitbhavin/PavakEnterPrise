using PVK.EFCore.Data.BaseScope;
using System;
using System.Collections.Generic;
using System.Text;

namespace PVK.EFCore.Data.OrderDetailscope
{
   public class TblOrderDetail: BaseEntity
    {
        public string Guid_OrderDetailsId { get; set; }
        public string Guid_OrderId { get; set; }
        public string Guid_ProductId { get; set; }
        public double Price { get; set; }
        public double Discount_Price { get; set; }
        public double Quantity { get; set; }

       
    }
}
