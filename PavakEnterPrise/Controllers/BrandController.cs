using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using PVK.DTO.Brand;
using PVK.Interfaces.Services.Brand;
using RouteAttribute = Microsoft.AspNetCore.Components.RouteAttribute;

namespace PVK.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
   
   
    public class BrandController : ControllerBase
    {
        private readonly  IBrandServices _service;
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
        public async Task<BrandResponse> Addnewbrand(Addbranddata tblBrand)
        {
            return await _service.Addnewbrand(tblBrand);
        }
        [HttpPost("Deletebrand")]
        public async Task<BrandResponse> Deletebrand(deletebrand tblBrand)
        {
            return await _service.RemoveBrand(tblBrand);
        }
        [HttpPost("Updatebrand")]
        public async Task<BrandResponse> UpdateBrand(updatebrand tblBrand)
        {
            return await _service.UpdateBrand(tblBrand);
        }

        [HttpPost("GetBrandbyId")]
        public async Task<BrandResponse> GetBrandbyId(string guidBrandId)
        {
            return await _service.GetBrandbyId(guidBrandId);
        }
    }
}
