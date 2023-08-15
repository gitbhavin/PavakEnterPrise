using Microsoft.EntityFrameworkCore;
using PVK.DTO.Order;
using PVK.EFCore.Data.OrderDetailscope;
using PVK.EFCore.Data.OrderScope;
using PVK.Interfaces.Services.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVK.Application.Services.Order
{
    public class OrderProcessor : IOrderProcessor
    {
        private readonly OrderContext _orderContext;

        private readonly OrderDetailContext _orderDetailContext;
        public OrderProcessor(OrderContext orderContext, OrderDetailContext orderDetailContext)
        {
            this._orderContext = orderContext;
            this._orderDetailContext = orderDetailContext;
        }
        public async Task<OrderResponse> AddOrder(AddOrder addOrder)
        {
            OrderResponse response = new OrderResponse();
            try
            {
                var orderguid = Guid.NewGuid().ToString();
                var order = new TblOrder()
                {
                    Guid_OrderId = orderguid,
                    Guid_UserId = addOrder.Guid_UserId,
                    Guid_PickupLocationId = addOrder.Guid_PickupLocationId,
                    Discount = addOrder.Discount,
                    Tax = addOrder.Tax,
                    Total = addOrder.Total,
                    Date_Inactive = null,
                    Date_Created = DateTime.Now,
                    Uid_Created = addOrder.Guid_UserId
                };

                await _orderContext.TblOrders.AddAsync(order);
                var result = await _orderContext.SaveChangesAsync();
                if (result > 0)
                {

                    foreach (var item in addOrder.orderDetails)
                    {
                        var orderdetail = new TblOrderDetail()
                        {
                            Guid_OrderDetailsId = Guid.NewGuid().ToString(),
                            Guid_OrderId = orderguid,
                            Guid_ProductId = item.Guid_ProductId,
                            Price = item.Price,
                            Discount_Price = item.Discount_Price,
                            Quantity = item.Quantity,
                            Date_Created = DateTime.Now,
                            Date_Inactive = null,
                            Uid_Created = addOrder.Guid_UserId
                        };
                        await _orderDetailContext.TblOrderDetails.AddAsync(orderdetail);
                        var resultorder = await _orderDetailContext.SaveChangesAsync();
                    }

                    response.Status = true;
                    response.Message = "order placed successfully";


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

        public Task<OrderResponse> DeleteOrder(Deleteorder deleteorder)
        {
            throw new NotImplementedException();
        }

        public async Task<OrderResponse> GetAllOrder()
        {
            OrderResponse response = new OrderResponse();

            try
            {
                var result = await _orderContext.TblOrders.Where(x => x.Date_Inactive == null).OrderByDescending(a => a.Date_Created).ToListAsync();

                if (result != null)
                {
                    foreach (var item in result)
                    {
                        Orderdata data = new Orderdata();
                        data.Guid_OrderId = item.Guid_OrderId;
                        data.Guid_PickupLocationId = item.Guid_PickupLocationId;
                        data.Guid_UserId = item.Guid_UserId;
                        data.Total = item.Total;
                        data.Tax = item.Tax;
                        data.Discount = item.Discount;
                        data.orderDetails =await _orderDetailContext.TblOrderDetails.Where(o => o.Guid_OrderId == item.Guid_OrderId).ToListAsync();


                        response.orderdatas.Add(data);
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

        public async Task<OrderResponse> GetOrderbyId(string GuidOrderid)
        {
            OrderResponse response = new OrderResponse();

            try
            {
                var result = await _orderContext.TblOrders.Where(x => x.Date_Inactive == null && x.Guid_OrderId == GuidOrderid).ToListAsync();

                if (result != null)
                {
                    foreach (var item in result)
                    {
                        Orderdata data = new Orderdata();
                        data.Guid_OrderId = item.Guid_OrderId;
                        data.Guid_PickupLocationId = item.Guid_PickupLocationId;
                        data.Guid_UserId = item.Guid_UserId;
                        data.Total = item.Total;
                        data.Tax = item.Tax;
                        data.Discount = item.Discount;
                        data.orderDetails = await _orderDetailContext.TblOrderDetails.Where(o => o.Guid_OrderId == item.Guid_OrderId).ToListAsync();


                        response.orderdatas.Add(data);
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

        public async Task<OrderResponse> GetOrderbypickupId(string Guidpickupid)
        {
            OrderResponse response = new OrderResponse();

            try
            {
                var result = await _orderContext.TblOrders.Where(x => x.Date_Inactive == null && x.Guid_PickupLocationId == Guidpickupid).ToListAsync();

                if (result != null)
                {
                    foreach (var item in result)
                    {
                        Orderdata data = new Orderdata();
                        data.Guid_OrderId = item.Guid_OrderId;
                        data.Guid_PickupLocationId = item.Guid_PickupLocationId;
                        data.Guid_UserId = item.Guid_UserId;
                        data.Total = item.Total;
                        data.Tax = item.Tax;
                        data.Discount = item.Discount;
                        data.orderDetails = await _orderDetailContext.TblOrderDetails.Where(o => o.Guid_OrderId == item.Guid_OrderId).ToListAsync();


                        response.orderdatas.Add(data);
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

        public async Task<OrderResponse> GetOrderbyUserId(string Guiduserid)
        {
            OrderResponse response = new OrderResponse();

            try
            {
                var result = await _orderContext.TblOrders.Where(x => x.Date_Inactive == null && x.Guid_UserId == Guiduserid).ToListAsync();

                if (result != null)
                {
                    foreach (var item in result)
                    {
                        Orderdata data = new Orderdata();
                        data.Guid_OrderId = item.Guid_OrderId;
                        data.Guid_PickupLocationId = item.Guid_PickupLocationId;
                        data.Guid_UserId = item.Guid_UserId;
                        data.Total = item.Total;
                        data.Tax = item.Tax;
                        data.Discount = item.Discount;
                        data.orderDetails = await _orderDetailContext.TblOrderDetails.Where(o => o.Guid_OrderId == item.Guid_OrderId).ToListAsync();


                        response.orderdatas.Add(data);
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

        public async Task<OrderResponse> UpdateOrder(Updateorder updateorder)
        {
            OrderResponse response = new OrderResponse();
            try
            {

                var orderguid = Guid.NewGuid().ToString();
                var order = new TblOrder()
                {
                    Guid_OrderId = orderguid,
                    Guid_UserId = updateorder.Guid_UserId,
                    Guid_PickupLocationId = updateorder.Guid_PickupLocationId,
                    Discount = updateorder.Discount,
                    Tax = updateorder.Tax,
                    Total = updateorder.Total,
                    Date_Inactive = null,
                    Date_Created = DateTime.Now,
                    Uid_Created = updateorder.Guid_UserId
                };

                 _orderContext.TblOrders.Update(order);
                var result = await _orderContext.SaveChangesAsync();
                if (result > 0)
                {

                    foreach (var item in updateorder.orderDetails)
                    {
                        var orderdetail = new TblOrderDetail()
                        {
                            Guid_OrderDetailsId = item.Guid_OrderDetailsId,
                            Guid_OrderId = orderguid,
                            Guid_ProductId = item.Guid_ProductId,
                            Price = item.Price,
                            Discount_Price = item.Discount_Price,
                            Quantity = item.Quantity,
                            Date_Created = DateTime.Now,
                            Date_Inactive = null,
                            Uid_Created = updateorder.Guid_UserId
                        };
                         _orderDetailContext.TblOrderDetails.Update(orderdetail);
                        var resultorder = await _orderDetailContext.SaveChangesAsync();
                    }

                    response.Status = true;
                    response.Message = "order placed successfully";


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
