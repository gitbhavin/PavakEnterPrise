using PVK.DTO.OrderStatus;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PVK.Interfaces.Services.OrderStatus
{
    public interface IOrderStatusService
    {
        Task<OrderstatusResponse> Addorderstatus(Addorderstatus addorderstatus);

        Task<OrderstatusResponse> Updateorderstatus(Updateorderstatus updateorderstatus);

        Task<OrderstatusResponse> Getorderstatusbyorderid(string guidorderid);
    }
}
