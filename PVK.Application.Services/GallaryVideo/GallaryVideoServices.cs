using PVK.DTO.GallaryVideo;
using PVK.Interfaces.Services.GallaryVideo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PVK.Application.Services.GallaryVideo
{
    public class GallaryVideoServices : IGallaryVideoServices
    {
        private IGallaryVideoProcessor _gallaryVideoProcessor;

        public GallaryVideoServices(IGallaryVideoProcessor gallaryVideoProcessor)
        {
            this._gallaryVideoProcessor = gallaryVideoProcessor;
        }
        public async Task<GallaryVideoResponse> AddNewGallaryVideo(AddGallaryVideoData addGallaryVideoData)
        {
            return await _gallaryVideoProcessor.AddNewGallaryVideo(addGallaryVideoData);
        }

        public async Task<GallaryVideoResponse> GetAllGallaryVideoList()
        {
            return await _gallaryVideoProcessor.GetAllGallaryVideoList();
        }

        public async Task<GallaryVideoResponse> RemoveGallaryVideo(DeleteGallaryVideo tblGallaryvideo)
        {
            return await _gallaryVideoProcessor.RemoveGallaryVideo(tblGallaryvideo);
        }

        public async Task<GallaryVideoResponse> UpdateGallaryVideo(UpdateGallaryVideo tblGallaryvideo)
        {
            return await _gallaryVideoProcessor.UpdateGallaryVideo(tblGallaryvideo);
        }
    }
}
