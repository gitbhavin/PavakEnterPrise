using PVK.DTO.BaseResponse;
using System;
using System.Collections.Generic;
using System.Text;

namespace PVK.DTO.Category
{
   public class CategoryResponse : BaseResponsedata
    {
        public List<CategoryData> categoryDatas { get; set; } = new List<CategoryData>();
    }
}
