using PVK.DTO.Order;
using PVK.Interfaces.Services.Order;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PVK.Application.Services.Order
{
    public class OrderService : IOrderService
    {
        private IOrderProcessor _orderProcessor;
        public OrderService(IOrderProcessor orderProcessor)
        {
            this._orderProcessor = orderProcessor;
        }
        public async Task<OrderResponse> AddOrder(AddOrder addOrder)
        {
            return await _orderProcessor.AddOrder(addOrder);
        }

        public Task<OrderResponse> DeleteOrder(Deleteorder deleteorder)
        {
            throw new NotImplementedException();
        }

        public async Task<OrderResponse> GetAllOrder()
        {
            return await _orderProcessor.GetAllOrder();
        }

        public async Task<OrderResponse> GetOrderbyId(string GuidOrderid)
        {
            return await _orderProcessor.GetOrderbyId(GuidOrderid);
        }

        public async Task<OrderResponse> GetOrderbypickupId(string Guidpickupid)
        {
            return await _orderProcessor.GetOrderbypickupId(Guidpickupid);
        }

        public async Task<OrderResponse> GetOrderbyUserId(string Guiduserid)
        {
            return await _orderProcessor.GetOrderbyUserId(Guiduserid);
        }

        public async Task<OrderResponse> UpdateOrder(Updateorder updateorder)
        {
            return await _orderProcessor.UpdateOrder(updateorder);
        }
    }
}
