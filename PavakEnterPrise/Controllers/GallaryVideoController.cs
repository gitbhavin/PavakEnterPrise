using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PVK.DTO.GallaryVideo;
using PVK.Interfaces.Services.GallaryVideo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PVK.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GallaryVideoController : ControllerBase
    {
        private IGallaryVideoServices _services;

        public GallaryVideoController(IGallaryVideoServices gallaryVideoServices)
        {
            this._services = gallaryVideoServices;
        }
        [HttpPost("AddNewGallaryVideo")]
        public async Task<GallaryVideoResponse> AddNewGallaryVideo(AddGallaryVideoData addGallaryVideoData)
        {
            return await _services.AddNewGallaryVideo(addGallaryVideoData);
        }
        [HttpGet("GetAllGallaryVideoList")]
        public async Task<GallaryVideoResponse> GetAllGallaryVideoList()
        {
            return await _services.GetAllGallaryVideoList();
        }
        [HttpPost("DeleteGallaryVideo")]
        public async Task<GallaryVideoResponse> DeleteGallaryVideo(DeleteGallaryVideo tblGallaryVideo)
        {
            return await _services.RemoveGallaryVideo(tblGallaryVideo);
        }
        [HttpPost("UpdateGallaryVideo")]
        public async Task<GallaryVideoResponse> UpdateGallaryVideo(UpdateGallaryVideo tblGallaryVideo)
        {
            return await _services.UpdateGallaryVideo(tblGallaryVideo);
        }




    }
}
