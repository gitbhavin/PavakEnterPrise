using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PVK.DTO.Payment;
using PVK.Interfaces.Services.Payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PVK.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _service;

        public PaymentController(IPaymentService paymentService)
        {
            this._service = paymentService;
        }
        [HttpPost("Addnewpayment")]
        public async Task<Paymentresponse> Addpayment(Addpayment addpayment)
        {
            return await _service.AddPayment(addpayment);
        }
        [HttpPost("Updaterefund")]
        public async Task<Paymentresponse> Refundpayment(Refundpayment refundpayment)
        {
            return await _service.updaterefund(refundpayment);
        }
    }
}
