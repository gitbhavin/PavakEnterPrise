using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PVK.DTO.Banner;
using PVK.Interfaces.Services.Banner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PVK.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannerController : ControllerBase
    {
        private readonly IBannerService _service;
        public BannerController(IBannerService service)
        {
            this._service = service;
        }
        [HttpGet("GetAllBanners")]
        public async Task<BannerResponse> GetAllBanners()
        {
            return await _service.GetAllBanners();
        }

        [HttpPost("Addnewbanner")]
        public async Task<BannerResponse> addnewbanner(Addbanner addbanner)
        {
            return await _service.AddnewBanner(addbanner);
        }
        [HttpPost("Deletebanner")]
        public async Task<BannerResponse> Deletebrand(Deletebanner deletebanner)
        {
            return await _service.RemoveBanner(deletebanner);
        }
        [HttpPost("Updatebanner")]
        public async Task<BannerResponse> UpdateBrand(Updatebanner updatebanner)
        {
            return await _service.UpdateBanner(updatebanner);
        }

        [HttpPost("GetBannerbyId")]
        public async Task<BannerResponse> Getbannerbyid(string guidBannerId)
        {
            return await _service.GetBannerbyId(guidBannerId);
        }
    }
}
