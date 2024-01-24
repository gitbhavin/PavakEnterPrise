using PVK.EFCore.Data.BaseScope;
using PVK.EFCore.Data.ProductScope;
using System;
using System.Collections.Generic;
using System.Text;

namespace PVK.DTO.Order
{
    public class orderdetaildata : BaseEntity
    {
        public string Guid_OrderDetailsId { get; set; }
        public string Guid_OrderId { get; set; }
        public string Guid_ProductId { get; set; }
        public decimal Price { get; set; }
        public decimal Discount_Price { get; set; }
        public int Quantity { get; set; }
        public decimal Totalprice { get; set; }     
       
        public List<TblProduct> products { get; set; }

    }
}
