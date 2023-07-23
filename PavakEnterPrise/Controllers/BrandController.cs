using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PVK.DTO.Brand;
using PVK.Interfaces.Services.Brand;
using PVK.EFCore.Data.BrandScope;

namespace PVK.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private IBrandServices _service;
        public BrandController(IBrandServices brandServices)
        {
            this._service = brandServices;
        }
        [HttpGet("GetAllBrands")]
        public async Task<BrandResponse> GetAllBrands()
        {
            return await _service.GetAllBrands();
        }

        [HttpPost("Addnewbrand")]
        public async Task<BrandResponse> addnewbrand(TblBrand tblBrand)
        {

            return await _service.addnewbrand(tblBrand);
        }
    }
}
