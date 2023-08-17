using PVK.DTO.Payment;
using PVK.Interfaces.Services.Payment;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PVK.Application.Services.Payment
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentProcessor _paymentProcessor;

        public PaymentService(IPaymentProcessor paymentProcessor)
        {
            this._paymentProcessor = paymentProcessor;
        }
        public async Task<Paymentresponse> AddPayment(Addpayment addpayment)
        {
            return await _paymentProcessor.AddPayment(addpayment);
        }

        public async Task<Paymentresponse> updaterefund(Refundpayment refundpayment)
        {
            return await _paymentProcessor.updaterefund(refundpayment);
        }
    }
}
