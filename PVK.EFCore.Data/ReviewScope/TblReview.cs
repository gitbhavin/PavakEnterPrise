﻿using PVK.EFCore.Data.BaseScope;
using System;
using System.Collections.Generic;
using System.Text;

namespace PVK.EFCore.Data.ReviewScope
{
    public class TblReview : BaseEntity
    {
        public string Guid_ReviewId { get; set; }
        public string Guid_ProductId { get; set; }
        public string Guid_UserId { get; set; }
        public string Txt_Comment { get; set; }
        public string Rating_Count { get; set; }
       
    }
}
