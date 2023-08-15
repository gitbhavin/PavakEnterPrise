using PVK.DTO.BaseResponse;
using System;
using System.Collections.Generic;
using System.Text;

namespace PVK.DTO.Wholeseller
{
   public class UpdateWholeseller: BaseRequest
    {
        public string Guid_Wholesellerid { get; set; }
        public string Name { get; set; }
        public string Companyname { get; set; }
        public string Phonenumber { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
    }
}
