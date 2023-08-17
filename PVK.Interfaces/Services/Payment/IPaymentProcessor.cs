using PVK.DTO.Payment;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PVK.Interfaces.Services.Payment
{
    public interface IPaymentProcessor
    {
        Task<Paymentresponse> AddPayment(Addpayment addpayment);
        Task<Paymentresponse> updaterefund(Refundpayment refundpayment);
    }
}
