using PVK.DTO.Order;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PVK.Interfaces.Services.Order
{
   public interface IOrderProcessor
    {
        Task<OrderResponse> GetAllOrder();

        Task<OrderResponse> AddOrder(AddOrder addOrder);

        Task<OrderResponse> DeleteOrder(Deleteorder deleteorder);

        Task<OrderResponse> UpdateOrder(Updateorder updateorder);

        Task<OrderResponse> GetOrderbyId(string GuidOrderid);
        Task<OrderResponse> GetOrderbyUserId(string Guiduserid);
        Task<OrderResponse> GetOrderbypickupId(string Guidpickupid);
    }
}
