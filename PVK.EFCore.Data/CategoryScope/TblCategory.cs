using PVK.EFCore.Data.BaseScope;
using System;
using System.Collections.Generic;
using System.Text;

namespace PVK.EFCore.Data.CategoryScope
{
    public class TblCategory : BaseEntity
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
