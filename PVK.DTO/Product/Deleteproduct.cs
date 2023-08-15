using PVK.DTO.BaseResponse;
using System;
using System.Collections.Generic;
using System.Text;

namespace PVK.DTO.Product
{
    public class Deleteproduct : BaseRequest
    {
        public string Guid_ProductId { get; set; }
    }
}
