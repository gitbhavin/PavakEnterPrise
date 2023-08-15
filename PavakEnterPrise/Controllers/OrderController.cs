using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PVK.DTO.Order;
using PVK.Interfaces.Services.Order;
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

        public OrderController(IOrderService orderService)
        {
            this._service = orderService;
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
    }
}
