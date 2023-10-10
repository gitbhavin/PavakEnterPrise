using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PVK.DTO.BannerImage;
using PVK.Interfaces.Services.BannerImage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PVK.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannerImageController : ControllerBase
    {
        private readonly IBannerImageService _service;

        public BannerImageController(IBannerImageService service)
        {
            this._service = service;
        }

        [HttpPost("Addbannerimage")]
        public async Task<BannerimageResponse> Addproductimage(IFormFile file, AddBannerimage addBannerimage)
        {
            return await _service.addbannerimage(file, addBannerimage);
        }
        [HttpPost("Deletebannerimage")]
        public async Task<BannerimageResponse> deletebannerimage(Deletebannerimage deletebannerimage)
        {
            return await _service.deletebannerimage(deletebannerimage);
        }
       
        [HttpPost("GetallImagesbybannerguId")]
        public async Task<BannerimageResponse> GetallImagesbyProductId(string guidbannerid)
        {
            return await _service.Getallbannerimagebybannerid(guidbannerid);
        }
    }
}
