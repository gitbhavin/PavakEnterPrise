using PVK.EFCore.Data.BaseScope;
using System;
using System.Collections.Generic;
using System.Text;

namespace PVK.EFCore.Data.OrderScope
{
   public class TblOrder : BaseEntity
    {
        public string Guid_OrderId { get; set; }
        public string Guid_UserId { get; set; }
        public double Discount { get; set; }
        public string Guid_PickupLocationId { get; set; }
        public double Tax { get; set; }
        public double Total { get; set; }

      
    }
}
