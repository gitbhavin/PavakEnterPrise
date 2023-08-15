using PVK.DTO.BaseResponse;
using System;
using System.Collections.Generic;
using System.Text;

namespace PVK.DTO.Email
{
  public  class EmailResponse: BaseResponsedata
    {
        public List<EmailData> emailDatas { get; set; } = new List<EmailData>();
    }
}
