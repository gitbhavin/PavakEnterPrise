using PVK.DTO.Payment;
using PVK.EFCore.Data.PaymentScope;
using PVK.Interfaces.Services.Payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVK.Application.Services.Payment
{
    public class PaymentProcessor : IPaymentProcessor
    {
        private readonly PaymentContext _paymentContext;

        public PaymentProcessor(PaymentContext paymentContext)
        {
            this._paymentContext = paymentContext;
        }
        public async Task<Paymentresponse> AddPayment(Addpayment addpayment)
        {
            Paymentresponse response = new Paymentresponse();
            try
            {

                var _payment = _paymentContext.TblPayments.Where(x => x.Guid_OrderId == addpayment.Guid_OrderId).FirstOrDefault();
                if (_payment == null)
                {

                    var payment = new TblPayment()
                    {
                        Guid_PaymentId = Guid.NewGuid().ToString(),
                        Guid_OrderId = addpayment.Guid_OrderId,
                        Guid_UserId=addpayment.Guid_UserId,
                        PaymentGateway=addpayment.PaymentGateway,
                        PaymentStatus=addpayment.PaymentStatus,
                        Amount=addpayment.Amount,
                        TransferId=addpayment.TransferId,
                        Date_Inactive = null,
                        Date_Created = DateTime.Now,
                        Uid_Created = addpayment.UserId


                    };

                    await _paymentContext.TblPayments.AddAsync(payment);
                    var result = await _paymentContext.SaveChangesAsync();
                    if (result > 0)
                    {
                        response.Status = true;
                        response.Message = "data save successfully";


                    }
                    else
                    {
                        response.Status = false;
                        response.Message = "data already added";
                    }
                }
                else
                {
                    response.Status = false;
                    response.Message = "data already added";
                }
                return response;
            }
            catch (Exception ex)
            {

                response.Message = ex.Message;
                response.Status = false;

                return response;
            }
        }

        public async Task<Paymentresponse> updaterefund(Refundpayment refundpayment)
        {
            Paymentresponse response = new Paymentresponse();
            try
            {
                var paymentrefund = _paymentContext.TblPayments.Where(x => x.Guid_PaymentId == refundpayment.Guid_PaymentId).FirstOrDefault();
                if (paymentrefund != null)
                {
                    paymentrefund.Date_Refunded = DateTime.Now;
                    paymentrefund.Is_Refunded = refundpayment.Is_Refunded;
                    _paymentContext.TblPayments.Update(paymentrefund);
                    var result = await _paymentContext.SaveChangesAsync();
                    if (result > 0)
                    {
                        response.Status = true;
                        response.Message = "refund successfully";


                    }
                    else
                    {
                        response.Status = false;
                        response.Message = "data already added";
                    }
                }



                return response;

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;

                return response;
            }
        }
    }
}
