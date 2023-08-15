using PVK.DTO.BaseResponse;
using System;
using System.Collections.Generic;
using System.Text;

namespace PVK.DTO.Wholeseller
{
    public class Addwholeseller: BaseRequest
    {
       
        public string Name { get; set; }
        public string Companyname { get; set; }
        public string Phonenumber { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
    }
}
