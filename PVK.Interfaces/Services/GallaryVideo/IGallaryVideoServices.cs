using PVK.DTO.GallaryVideo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PVK.Interfaces.Services.GallaryVideo
{
   public interface IGallaryVideoServices
    {
        Task<GallaryVideoResponse> GetAllGallaryVideoList();
        Task<GallaryVideoResponse> AddNewGallaryVideo(AddGallaryVideoData addGallaryVideoData);
        Task<GallaryVideoResponse> UpdateGallaryVideo(UpdateGallaryVideo tblGallaryvideo);
        Task<GallaryVideoResponse> RemoveGallaryVideo(DeleteGallaryVideo tblGallaryvideo);
    }
}
