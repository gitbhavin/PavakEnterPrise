using PVK.DTO.BaseResponse;
using System;
using System.Collections.Generic;
using System.Text;

namespace PVK.DTO.ContactUs
{
   public class ContactUsResponse: BaseResponsedata
    {
        public List<ContactUsData> contactUsDatas { get; set; } = new List<ContactUsData>();
    }
}
