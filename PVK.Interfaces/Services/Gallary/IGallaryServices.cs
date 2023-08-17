using PVK.DTO.Gallary;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PVK.Interfaces.Services.Gallary
{
    public interface IGallaryServices
    {
        Task<GallaryResponse> GetAllGallaryList();
        Task<GallaryResponse> AddNewGallary(AddGallaryData addGallaryData);
        Task<GallaryResponse> UpdateGallary(UpdateGallary tblgallary);
        Task<GallaryResponse> RemoveGallary(DeleteGallary tblgallary);
    }
}
