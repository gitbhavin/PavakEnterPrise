using PVK.DTO.Brand;
using PVK.Interfaces.Services.Brand;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PVK.Application.Services.Brand
{
    public class BrandServices : IBrandServices
    {
        private IBrandProcessor _brandProcessor;
        public BrandServices(IBrandProcessor brandProcessor)
        {
            this._brandProcessor = brandProcessor;
        }

        public async Task<BrandResponse> GetAllBrands()
        {
            return await _brandProcessor.GetAllBrands();
        }
    }
}
