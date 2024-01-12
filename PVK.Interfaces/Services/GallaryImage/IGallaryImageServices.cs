using Microsoft.AspNetCore.Http;
using PVK.DTO.GallaryImage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PVK.Interfaces.Services.GallaryImage
{
    public interface IGallaryImageServices
    {
        Task<GallaryImageResponse> AddNewGallaryImage(IFormFile file, string guidGallaryId);

        Task<GallaryImageResponse> UpdateGallaryImage(IFormFile file, UpdateGallaryImage updateGallaryImage);

        Task<GallaryImageResponse> RemoveGallaryImage(DeleteGallaryImage tblgallaryimage);

        Task<GallaryImageResponse> GetAllImagebyGallaryId(string giudGallaryId);

    }
}
