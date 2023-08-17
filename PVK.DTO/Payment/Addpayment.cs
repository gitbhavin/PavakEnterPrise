using PVK.DTO.BaseResponse;
using System;
using System.Collections.Generic;
using System.Text;

namespace PVK.DTO.Payment
{
    public class Addpayment : BaseRequest
    {
        public string Guid_OrderId { get; set; }
        public string TransferId { get; set; }
        public string Guid_UserId { get; set; }
        public double Amount { get; set; }
        public string PaymentStatus { get; set; }
        public string PaymentGateway { get; set; }

    }
}
