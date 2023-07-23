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

        Task<BrandResponse> addnewbrand(TblBrand addbranddata);
    }
}
