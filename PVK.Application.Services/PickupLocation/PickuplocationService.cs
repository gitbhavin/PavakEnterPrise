using PVK.DTO.PickupLocation;
using PVK.Interfaces.Services.PickupLocation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PVK.Application.Services.PickupLocation
{
    public class PickuplocationService : IPickuplocationService
    {
        private IPickuplocationProcessor _pickuplocationProcessor;

        public PickuplocationService(IPickuplocationProcessor pickuplocationProcessor)
        {
            this._pickuplocationProcessor = pickuplocationProcessor;
        }
        public async Task<PickupLocationResponse> AddNewPickuplocation(AddPickuplocation addPickuplocation)
        {
            return  await _pickuplocationProcessor.AddNewPickuplocation(addPickuplocation);
        }

        public async Task<PickupLocationResponse> Deletepickuplocation(deletePickuplocation deletePickuplocation)
        {
            return await _pickuplocationProcessor.Deletepickuplocation(deletePickuplocation);
        }

        public async Task<PickupLocationResponse> GetAllPickuplocationList()
        {
            return await _pickuplocationProcessor.GetAllPickuplocationList();
        }

        public async Task<PickupLocationResponse> Updatepickuplocation(updatePickupLocation updatePickupLocation)
        {
            return await _pickuplocationProcessor.Updatepickuplocation(updatePickupLocation);
        }
    }
}
