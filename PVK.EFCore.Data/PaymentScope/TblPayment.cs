using PVK.EFCore.Data.BaseScope;
using System;
using System.Collections.Generic;
using System.Text;

namespace PVK.EFCore.Data.PaymentScope
{
   public class TblPayment : BaseEntity
    {
        public string Guid_PaymentId { get; set; }
        public string Guid_OrderId { get; set; }
        public string TransferId { get; set; }
        public string Guid_UserId { get; set; }
        public double Amount { get; set; }
        public string PaymentStatus { get; set; }
        public string PaymentGateway { get; set; }
        public bool Is_Refunded { get; set; }
        public DateTime Date_Refunded { get; set; }
       
    }
}
