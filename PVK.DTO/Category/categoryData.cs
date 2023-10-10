using PVK.DTO.BaseResponse;
using PVK.EFCore.Data.CategoryScope;
using System;
using System.Collections.Generic;
using System.Text;

namespace PVK.DTO.Category
{
    public class CategoryData 
    {
        public string Guid_CategoryId { get; set; }
        public string Guid_SubCategoryId { get; set; }

        public string Guid_SubSubCategoryId { get; set; }

        public string CategoryName { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public string Description { get; set; }
        public string CategoryImg { get; set; }

        public bool IsPreorder { get; set; }

        public List<TblCategory> subcategorylist { get; set; } = new List<TblCategory>();
    }
}
