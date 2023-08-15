using PVK.DTO.OrderStatus;
using PVK.Interfaces.Services.OrderStatus;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PVK.Application.Services.OrderStatus
{
    public class OrderstatusService : IOrderStatusService
    {
        private readonly IOrderStatusProcessor _orderStatusProcessor;

        public OrderstatusService(IOrderStatusProcessor orderStatusProcessor)
        {
            this._orderStatusProcessor = orderStatusProcessor;
        }
        public async Task<OrderstatusResponse> Addorderstatus(Addorderstatus addorderstatus)
        {
            return await _orderStatusProcessor.Addorderstatus(addorderstatus);
        }

        public async Task<OrderstatusResponse> Getorderstatusbyorderid(string guidorderid)
        {
            return await _orderStatusProcessor.Getorderstatusbyorderid(guidorderid);
        }

        public async Task<OrderstatusResponse> Updateorderstatus(Updateorderstatus updateorderstatus)
        {
            return await _orderStatusProcessor.Updateorderstatus(updateorderstatus);
        }
    }
}
