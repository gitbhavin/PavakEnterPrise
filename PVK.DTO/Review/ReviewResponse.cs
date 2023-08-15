using PVK.DTO.BaseResponse;
using System;
using System.Collections.Generic;
using System.Text;

namespace PVK.DTO.Review
{
    public class ReviewResponse : BaseResponsedata
    {
       public List<Reviewdata> reviewdatas { get; set; } = new List<Reviewdata>();
    }
}
