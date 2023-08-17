using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PVK.DTO.OrderStatus;
using PVK.Interfaces.Services.OrderStatus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PVK.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderstatusController : ControllerBase
    {
        private readonly IOrderStatusService _service;

        public OrderstatusController(IOrderStatusService orderStatusService)
        {
            this._service = orderStatusService;
        }

        [HttpPost("Addorderstatus")]
        public async Task<OrderstatusResponse> Addorderstatus(Addorderstatus addorderstatus)
        {
            return await _service.Addorderstatus(addorderstatus);
        }

        [HttpPost("Updateorderstatus")]
        public async Task<OrderstatusResponse> UpdateOrderstatus(Updateorderstatus updateorderstatus)
        {
            return await _service.Updateorderstatus(updateorderstatus);
        }
        [HttpPost("GetOrderstatusbyOrderId")]
        public async Task<OrderstatusResponse> Getorderstatusbyorderid(string guidOrderid)
        {
            return await _service.Getorderstatusbyorderid(guidOrderid);
        }
    }
}
