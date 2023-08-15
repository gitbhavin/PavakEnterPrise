using PVK.DTO.BaseResponse;
using System;
using System.Collections.Generic;
using System.Text;

namespace PVK.DTO.OrderStatus
{
    public class OrderstatusResponse : BaseResponsedata
    {
        public List<Orderstatusdata> orderstatusdatas { get; set; } = new List<Orderstatusdata>();
    }
}
