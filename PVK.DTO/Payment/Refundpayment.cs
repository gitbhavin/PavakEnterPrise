using PVK.DTO.BaseResponse;
using System;
using System.Collections.Generic;
using System.Text;

namespace PVK.DTO.Payment
{
   public class Refundpayment : BaseRequest
    {
        public string Guid_PaymentId { get; set; }
        public bool Is_Refunded { get; set; }
        public DateTime Date_Refunded { get; set; }
    }
}
