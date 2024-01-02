using Microsoft.AspNetCore.Http;
using PVK.DTO.GallaryImage;
using PVK.Interfaces.Services.GallaryImage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PVK.Application.Services.GallaryImage
{
    public class GallaryImageServices : IGallaryImageServices
    {
        private IGallaryImageProcessor _gallaryImageProcessor;
        
        public GallaryImageServices(IGallaryImageProcessor gallaryImageProcessor)
        {
            this._gallaryImageProcessor = gallaryImageProcessor;
        }

        public async Task<GallaryImageResponse> AddNewGallaryImage(IFormFile file, string guidGallaryId)
        {
            return await _gallaryImageProcessor.AddNewGallaryImage(file, guidGallaryId);
        }

        public async Task<GallaryImageResponse> GetAllImagebyGallaryId(string giudGallaryId)
        {
            return await _gallaryImageProcessor.GetAllImagebyGallaryId(giudGallaryId);
        }

        public async Task<GallaryImageResponse> RemoveGallaryImage(DeleteGallaryImage tblgallaryimage)
        {
            return await _gallaryImageProcessor.RemoveGallaryImage(tblgallaryimage);
        }

        public async Task<GallaryImageResponse> UpdateGallaryImage(IFormFile file, UpdateGallaryImage updateGallaryImage)
        {
            return await _gallaryImageProcessor.UpdateGallaryImage(file, updateGallaryImage);
        }
    }
}
