using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PVK.DTO.Gallary;
using PVK.Interfaces.Services.Gallary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PVK.API.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class GallaryController : ControllerBase
    {
        private IGallaryServices _services;

        public GallaryController(IGallaryServices gallaryServices)
        {
            this._services = gallaryServices;
        }
        [HttpPost("AddNewGallary")]
        public async Task<GallaryResponse> AddNewGallary(AddGallaryData addGallaryData)
        {
            return await _services.AddNewGallary(addGallaryData);
        }
        [HttpGet("GetAllGallaryList")]
        public async Task<GallaryResponse> GetAllgallaryList()
        {
            return await _services.GetAllGallaryList();
        }
        [HttpPost("DeleteGallary")]
        public async Task<GallaryResponse> DeleteGallary(DeleteGallary deleteGallary)
        {
            return await _services.RemoveGallary(deleteGallary);
        }
        [HttpPost("UpdateGallary")]
        public async Task<GallaryResponse> UpdateGallary(UpdateGallary updateGallary)
        {
            return await _services.UpdateGallary(updateGallary);
        }
        [HttpPost("GetGallarybyid")]
        public async Task<GallaryResponse> GetGallarybyid(string GiudGallaryid)
        {
            return await _services.GetGallaryById(GiudGallaryid);
        }

        [HttpPost("UploadGallaryImage")]
        public async Task<GallaryResponse> UploadGallaryImage(IFormFile file,string GiudGallaryid,bool IsPrimary)
        {
            return await _services.UploadImage(file, GiudGallaryid, IsPrimary);
        }
    }
}
