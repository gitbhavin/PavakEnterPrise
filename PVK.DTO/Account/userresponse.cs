using PVK.DTO.Address;
using PVK.DTO.BaseResponse;
using System;
using System.Collections.Generic;
using System.Text;

namespace PVK.DTO.Account
{
    public class userresponse : BaseResponsedata
    {
        public List<UserData> userDatas { get; set; } = new List<UserData>();
    }
}
