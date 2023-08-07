using PVK.DTO.Brand;
using PVK.EFCore.Data.BrandScope;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PVK.Interfaces.Services.Brand
{
   public interface IBrandServices
    {
        Task<BrandResponse> GetAllBrands();

        Task<BrandResponse> Addnewbrand(Addbranddata addbranddata);

        Task<BrandResponse> RemoveBrand(deletebrand tblBrand);

        Task<BrandResponse> UpdateBrand(updatebrand tblBrand);

        Task<BrandResponse> GetBrandbyId(string GuidBrandId);
    }
   
}
