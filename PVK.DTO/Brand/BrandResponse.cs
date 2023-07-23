using System;
using System.Collections.Generic;
using System.Text;

namespace PVK.DTO.Brand
{
    public class BrandResponse
    {
        public List<BrandData> Brands { get; set; } = new List<BrandData>();
        public string Message { get; set; }
        public bool Status { get; set; }
    }
}
