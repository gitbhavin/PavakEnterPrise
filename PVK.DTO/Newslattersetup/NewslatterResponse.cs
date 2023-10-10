using PVK.DTO.BaseResponse;
using System;
using System.Collections.Generic;
using System.Text;

namespace PVK.DTO.Newslattersetup
{
   public class NewslatterResponse : BaseResponsedata
    {
        public List<Newslatterdata> newslatterdatas { get; set; } = new List<Newslatterdata>();
    }
}
