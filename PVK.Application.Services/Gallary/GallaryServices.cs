using PVK.DTO.Gallary;
using PVK.Interfaces.Services.Gallary;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PVK.Application.Services.Gallary
{
    public class GallaryServices : IGallaryServices
    {
        private IGallaryProcessor _gallaryProcessor;

        public GallaryServices(IGallaryProcessor gallaryProcessor)
        {
            this._gallaryProcessor = gallaryProcessor;
        }
        public async Task<GallaryResponse> AddNewGallary(AddGallaryData addGallaryData)
        {
            return await _gallaryProcessor.AddNewGallary(addGallaryData);
        }

        public async Task<GallaryResponse> GetAllGallaryList()
        {
            return await _gallaryProcessor.GetAllGallaryList();
        }

        public async Task<GallaryResponse> RemoveGallary(DeleteGallary tblgallary)
        {
            return await _gallaryProcessor.RemoveGallary(tblgallary);
        }

        public async Task<GallaryResponse> UpdateGallary(UpdateGallary tblgallary)
        {
            return await _gallaryProcessor.UpdateGallary(tblgallary);
        }
    }
}
