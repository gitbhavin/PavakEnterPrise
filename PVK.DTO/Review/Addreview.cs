using System;
using System.Collections.Generic;
using System.Text;

namespace PVK.DTO.Review
{
    public class Addreview
    {

        public string Guid_ProductId { get; set; }
        public string Guid_UserId { get; set; }
        public string Txt_Comment { get; set; }
        public string Rating_Count { get; set; }
    }
}
