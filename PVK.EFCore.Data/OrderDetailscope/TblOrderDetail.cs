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
        public decimal Price { get; set; }
        public decimal Discount_Price { get; set; }
        public int Quantity { get; set; }
        public decimal Totalprice { get; set; }

    }
}
