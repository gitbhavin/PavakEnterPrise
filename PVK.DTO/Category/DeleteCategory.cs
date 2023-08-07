using PVK.DTO.BaseResponse;
using System;
using System.Collections.Generic;
using System.Text;

namespace PVK.DTO.Category
{
  public  class DeleteCategory : BaseRequest
    {
        public string Guid_CategoryId { get; set; }
    }
}
