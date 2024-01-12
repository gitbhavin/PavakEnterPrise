using Microsoft.AspNetCore.Http;
using PVK.DTO.Gallary;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PVK.Interfaces.Services.Gallary
{
    public interface IGallaryProcessor
    {
        Task<GallaryResponse> GetAllGallaryList();
        Task<GallaryResponse> AddNewGallary(AddGallaryData addGallaryData);
        Task<GallaryResponse> UpdateGallary(UpdateGallary tblgallary);
        Task<GallaryResponse> RemoveGallary(DeleteGallary tblgallary);

        Task<GallaryResponse> GetGallaryById(string GuidGallaryId);

        Task<GallaryResponse> UploadImage(IFormFile file, string GuidGallaryId, bool IsPrimary);

    }
}
