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
                int? count = _orderContext.TblOrders.ToList().Count() + 1;
                var order = new TblOrder()
                {
                    Guid_OrderId = orderguid,
                    orderno = "OD" + count.ToString(),
                    Guid_UserId = addOrder.Guid_UserId,
                    Guid_PickupLocationId = addOrder.Guid_PickupLocationId,
                    Discount =Convert.ToDecimal(addOrder.Discount),
                    name=addOrder.name,
                    emailid=addOrder.emailid,
                    address=addOrder.address,
                    city=addOrder.city,
                    zipcode=addOrder.zipcode,
                    phoneno=addOrder.phoneno,
                    remark=addOrder.remark,
                    status=addOrder.status,
                    Tax = Convert.ToDecimal(addOrder.Tax),
                    Total = Convert.ToDecimal(addOrder.Total),                   
                    estimatedeliverydate=DateTime.Now,
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
                            Totalprice=item.Totalprice,
                            Date_Inactive = null,
                            Uid_Created = addOrder.Guid_UserId
                        };
                        await _orderDetailContext.TblOrderDetails.AddAsync(orderdetail);
                        var resultorder = await _orderDetailContext.SaveChangesAsync();
                    }
                    response.guid = orderguid;
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
                        data.orderno = item.orderno;
                        data.invoiceno = item.invoiceno;
                        data.phoneno = item.phoneno;
                        data.status = item.status;
                        data.address = item.address;
                        data.shippingCharge = item.shippingCharge;
                        data.zipcode = item.zipcode;
                        data.name = item.name;
                        data.source = item.source;
                        data.remark = item.remark;
                        data.callNumber = item.callNumber;
                        data.addressbilling = item.addressbilling;
                        data.bankname = item.bankname;
                        data.city = item.city;
                        data.emailid = item.emailid;
                        data.flgIsCallRequest = item.flgIsCallRequest;
                        data.flgIsCancel = item.flgIsCancel;
                        data.flgIsCancelRequest = item.flgIsCancelRequest;
                        data.flgIsPaymentDone = item.flgIsPaymentDone;
                        data.flgIsReturn = item.flgIsReturn;
                        data.landmark = item.landmark;
                        data.paymenttype = item.paymenttype;
                        data.shipmentstatus = item.shipmentstatus;
                        data.Total = Convert.ToDecimal(item.Total);
                        data.Tax = Convert.ToDecimal(item.Tax);
                        data.Discount = Convert.ToDecimal(item.Discount);
                        data.Date_Created = item.Date_Created;
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
                        data.Total = Convert.ToDecimal(item.Total);
                        data.Tax = Convert.ToDecimal(item.Tax);
                        data.Discount = Convert.ToDecimal(item.Discount);
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
                        data.Total = Convert.ToDecimal(item.Total);
                        data.Tax = Convert.ToDecimal(item.Tax);
                        data.Discount = Convert.ToDecimal(item.Discount);
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
                        data.Total = Convert.ToDecimal(item.Total);
                        data.Tax = Convert.ToDecimal(item.Tax);
                        data.Discount = Convert.ToDecimal(item.Discount);
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
                    Discount = Convert.ToDecimal(updateorder.Discount),
                    Tax = Convert.ToDecimal(updateorder.Tax),
                    Total = Convert.ToDecimal(updateorder.Total),
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
