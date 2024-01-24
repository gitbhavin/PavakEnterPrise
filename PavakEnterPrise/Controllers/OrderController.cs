using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using PVK.DTO.Order;
using PVK.Interfaces.Services.Order;
using PVK.QueryHandlers.Helper;
using SendGrid;
using SendGrid.Helpers.Mail;
using Stripe;
using Stripe.BillingPortal;
using Stripe.Checkout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PVK.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _service;
        private readonly StripeSettings _stripeSettings;
        public string SessionId { get; set; }
        public OrderController(IOrderService orderService, IOptions<StripeSettings> options)
        {
            this._service = orderService;
            this._stripeSettings = options.Value;
        }

        [HttpGet("GetAllOrders")]
        public async Task<OrderResponse> GetAllOrder()
        {
            return await _service.GetAllOrder();
        }

        [HttpPost("Addneworder")]
        public async Task<OrderResponse> AddOrder(AddOrder addOrder)
        {
            return await _service.AddOrder(addOrder);
        }
        [HttpPost("Deleteorder")]
        public async Task<OrderResponse> Deleteorder(Deleteorder deleteorder)
        {
            return await _service.DeleteOrder(deleteorder);
        }
        [HttpPost("Updateorder")]
        public async Task<OrderResponse> Updateorder(Updateorder updateorder)
        {
            return await _service.UpdateOrder(updateorder);
        }

        [HttpPost("GetOrderbyId")]
        public async Task<OrderResponse> GetOrderbyId(string guidorderid)
        {
            return await _service.GetOrderbyId(guidorderid);
        }

        [HttpPost("GetOrderDetailbyId")]
        public async Task<OrderResponse> GetOrderDetailbyId(string guidorderid)
        {
            return await _service.GetOrderDetails(guidorderid);
        }

        [HttpPost("GetOrderbyPickuporderId")]
        public async Task<OrderResponse> GetOrderbypickupId(string guidpickuporderid)
        {
            return await _service.GetOrderbypickupId(guidpickuporderid);
        }

        [HttpPost("GetOrderbyUserId")]
        public async Task<OrderResponse> GetOrderbyUserId(string guiduserid)
        {
            return await _service.GetOrderbyUserId(guiduserid);
        }
        [HttpPost("checkoutpayment")]
        public IActionResult checkoutsession(string amount)
        {
            var currancy = "usd";
            var successUrl = "https://pavakadmin.azurewebsites.net";
            var cancelUrl = "https://pavakadmin.azurewebsites.net";

            StripeConfiguration.ApiKey = _stripeSettings.SecretKey;

            var option = new Stripe.Checkout.SessionCreateOptions
            {
                
                LineItems = new List<SessionLineItemOptions>
              {
                  new SessionLineItemOptions
                  {
                      PriceData=new SessionLineItemPriceDataOptions
                      {
                          Currency=currancy,
                          UnitAmount=Convert.ToInt32(amount) * 100,
                          ProductData=new SessionLineItemPriceDataProductDataOptions
                          {
                              Name="PavakEnterPrise"
                             
                          }
                      },
                      Quantity=1
                  }
              },
                Mode = "payment",
                SuccessUrl = successUrl,
                CancelUrl = cancelUrl


            };
            var service = new Stripe.Checkout.SessionService();
            var session = service.Create(option);
            SessionId = session.Id;
            return Redirect(session.Url);
        }     
        
       
    }
}
