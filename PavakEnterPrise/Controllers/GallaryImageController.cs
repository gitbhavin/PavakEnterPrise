using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PVK.DTO.GallaryImage;
using PVK.Interfaces.Services.GallaryImage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PVK.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GallaryImageController : ControllerBase
    {
        private IGallaryImageServices _services;

        public GallaryImageController(IGallaryImageServices services)
        {
            this._services = services;
        }
        [HttpPost("AddGallaryImage")]
        public async Task<GallaryImageResponse> AddGallaryImage(IFormFile file,string guidGallaryId)
        {
            return await _services.AddNewGallaryImage(file, guidGallaryId);
        }
        [HttpPost("GetGallaryImagebyId")]
        public async Task<GallaryImageResponse> GetGallaryImagebyId(string guidGallaryId)
        {
            return await _services.GetAllImagebyGallaryId(guidGallaryId);
        }
    }
}
