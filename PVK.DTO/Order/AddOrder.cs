using PVK.EFCore.Data.OrderDetailscope;
using System;
using System.Collections.Generic;
using System.Text;

namespace PVK.DTO.Order
{
   public class AddOrder
    {
        public string Guid_OrderId { get; set; }
        public string Guid_UserId { get; set; }

        public string orderno { get; set; }


        public string emailid { get; set; }

        //filed for shipping address
        public string name { get; set; }

        public string address { get; set; }
        public string city { get; set; }
        public string zipcode { get; set; }
        public string landmark { get; set; }
        public string phoneno { get; set; }

        //filed for billing address
        public string namebilling { get; set; }

        public string addressbilling { get; set; }
        public string citybilling { get; set; }
        public string zipcodebilling { get; set; }
        public string landmarkbilling { get; set; }
        public string phonenobilling { get; set; }
        public string paymenttype { get; set; }
        public bool flgIsPaymentDone { get; set; }
        public string transectionId { get; set; }
        public string bankname { get; set; }

        public string transectionRemarks { get; set; }
        public string shipmentstatus { get; set; }
        public string inCourierComId { get; set; }
        public string shippingTrackingId { get; set; }

        public bool flgIsCancelRequest { get; set; }

        public bool flgIsReturn { get; set; }

        public bool flgIsCallRequest { get; set; }
        public string callNumber { get; set; }
        public string remark { get; set; }
        public bool flgIsCancel { get; set; }

        public string invoiceno { get; set; }


        public string ordertype { get; set; }
        public string status { get; set; }
        public string source { get; set; }
      

        public double shippingCharge { get; set; }
        public double Discount { get; set; }
        public string Guid_PickupLocationId { get; set; }
        public double Tax { get; set; }
        public double Total { get; set; }
      
        public DateTime estimatedeliverydate { get; set; }
        public string estimatedeliverytime { get; set; }

        public List<TblOrderDetail> orderDetails { get; set; }
    }
}
