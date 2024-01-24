using PVK.DTO.BaseResponse;
using System;
using System.Collections.Generic;
using System.Text;

namespace PVK.DTO.Order
{
   public class OrderResponse : BaseResponsedata
    {
        public List<Orderdata> orderdatas { get; set; } = new List<Orderdata>();

        public List<orderdetaildata> orderdetaildatas { get; set; } = new List<orderdetaildata>();
        public object orderList { get; set; }
    }
}
