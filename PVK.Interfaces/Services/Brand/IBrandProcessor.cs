using PVK.DTO.Brand;
using PVK.EFCore.Data.BrandScope;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PVK.Interfaces.Services.Brand
{
    public interface IBrandProcessor
    {
        Task<BrandResponse> GetAllBrands();

        Task<BrandResponse> addnewbrand(Addbranddata addbranddata);

        Task<BrandResponse> RemoveBrand(deletebrand tblBrand);

        Task<BrandResponse> UpdateBrand(updatebrand tblBrand);
    }
}
