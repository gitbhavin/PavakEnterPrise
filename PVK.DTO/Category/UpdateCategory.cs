using PVK.DTO.BaseResponse;
using System;
using System.Collections.Generic;
using System.Text;

namespace PVK.DTO.Category
{
   public class UpdateCategory : BaseRequest
    {
        public string Guid_CategoryId { get; set; }
        public string Guid_SubCategoryId { get; set; }
        public string Guid_SubSubCategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public string CategoryImg { get; set; }
        public bool IsPreorder { get; set; }
    }
}
