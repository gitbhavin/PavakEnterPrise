using PVK.DTO.BaseResponse;
using System;
using System.Collections.Generic;
using System.Text;

namespace PVK.DTO.Address
{
   public class UpdateAddress: BaseRequest
    {
        public string GuidAddressId { get; set; }
        public int VersionId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
        public string Country { get; set; }
        public bool IsDefault { get; set; }
        public bool IsBilling { get; set; }
        public bool IsDelivery { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }
}
