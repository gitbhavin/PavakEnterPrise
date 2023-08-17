using Microsoft.EntityFrameworkCore;
using PVK.DTO.OrderStatus;
using PVK.EFCore.Data.OrderStatusScope;
using PVK.Interfaces.Services.OrderStatus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVK.Application.Services.OrderStatus
{
    public class OrderstatusProcessor : IOrderStatusProcessor
    {
        private readonly OrderStatusContext _orderStatusContext;

        public OrderstatusProcessor(OrderStatusContext orderStatusContext)
        {
            this._orderStatusContext = orderStatusContext;
        }
        public async Task<OrderstatusResponse> Addorderstatus(Addorderstatus addorderstatus)
        {
            OrderstatusResponse response = new OrderstatusResponse();
            try
            {
                    var orderStatus = new TblOrderStatus()
                    {
                        Guid_OrderStatusId = Guid.NewGuid().ToString(),
                        Guid_OrderId = addorderstatus.Guid_OrderId,
                        Status=addorderstatus.Status,
                        Is_PickUp=addorderstatus.Is_PickUp,
                        Date_Status=addorderstatus.Date_Status,
                        Date_Inactive = null,
                        Date_Created = DateTime.Now,
                        Uid_Created = addorderstatus.UserId


                    };

                    await _orderStatusContext.TblOrderStatuses.AddAsync(orderStatus);
                    var result = await _orderStatusContext.SaveChangesAsync();
                    if (result > 0)
                    {
                        response.Status = true;
                        response.Message = "status updated successfully";


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

        public async Task<OrderstatusResponse> Getorderstatusbyorderid(string guidorderid)
        {
            OrderstatusResponse response = new OrderstatusResponse();

            try
            {
                var result = await _orderStatusContext.TblOrderStatuses.Where(x => x.Date_Inactive == null && x.Guid_OrderId == guidorderid).ToListAsync();


                if (result != null)
                {
                    foreach (var item in result)
                    {
                        Orderstatusdata data = new Orderstatusdata();
                        data.Guid_OrderId = item.Guid_OrderId;
                        data.Guid_OrderStatusId = item.Guid_OrderStatusId;
                        data.Is_PickUp = item.Is_PickUp;
                        data.Status = item.Status;
                        data.Date_Status = item.Date_Status;
                        response.orderstatusdatas.Add(data);
                    }
                    response.Message = "Success!";
                    response.Status = true;
                }
                else
                {
                    response.Message = "No Record Found!";
                    response.Status = true;
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

        public async Task<OrderstatusResponse> Updateorderstatus(Updateorderstatus updateorderstatus)
        {
            OrderstatusResponse response = new OrderstatusResponse();
            try
            {

                var orderStatus = new TblOrderStatus()
                {
                    Guid_OrderStatusId = updateorderstatus.Guid_OrderStatusId,
                    Guid_OrderId = updateorderstatus.Guid_OrderId,
                    Status = updateorderstatus.Status,
                    Is_PickUp = updateorderstatus.Is_PickUp,
                    Date_Status = updateorderstatus.Date_Status,
                    Date_Inactive = null,
                    Date_Created = DateTime.Now,
                    Uid_Created = updateorderstatus.UserId


                };

                _orderStatusContext.TblOrderStatuses.Update(orderStatus);
                var result = await _orderStatusContext.SaveChangesAsync();
                if (result > 0)
                {
                    response.Status = true;
                    response.Message = "status updated successfully";


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
    }
}
