using PVK.DTO.BaseResponse;
using System;
using System.Collections.Generic;
using System.Text;

namespace PVK.DTO.Wholeseller
{
  public  class WholesellerResponse: BaseResponsedata
    {
        public List<WholesellerData> wholesellerDatas { get; set; } = new List<WholesellerData>();
    }
}
