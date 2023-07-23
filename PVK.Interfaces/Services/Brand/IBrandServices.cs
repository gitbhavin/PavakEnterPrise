using PVK.DTO.Brand;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PVK.Interfaces.Services.Brand
{
   public interface IBrandServices
    {
        Task<BrandResponse> GetAllBrands();
    }
   
}
