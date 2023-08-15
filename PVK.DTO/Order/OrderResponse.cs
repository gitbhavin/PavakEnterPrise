using PVK.DTO.BaseResponse;
using System;
using System.Collections.Generic;
using System.Text;

namespace PVK.DTO.Order
{
   public class OrderResponse : BaseResponsedata
    {
        public List<Orderdata> orderdatas { get; set; } = new List<Orderdata>();
    }
}
