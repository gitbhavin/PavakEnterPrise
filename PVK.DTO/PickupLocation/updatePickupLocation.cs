using PVK.DTO.BaseResponse;
using System;
using System.Collections.Generic;
using System.Text;

namespace PVK.DTO.PickupLocation
{
   public class updatePickupLocation : BaseRequest
    {
        public string Guid_PickupLocationId { get; set; }
        public string CityName { get; set; }
        public string ContactName { get; set; }
        public string ContactNumber { get; set; }
        public string ContactNumber2 { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
        public string Country { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }
}
