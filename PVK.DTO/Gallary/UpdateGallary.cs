﻿using PVK.DTO.BaseResponse;
using System;
using System.Collections.Generic;
using System.Text;

namespace PVK.DTO.Gallary
{
    public class UpdateGallary: BaseRequest
    {
        public string GuidGallaryId { get; set; }
        public string Name { get; set; }
    }
}