using PVK.DTO.PickupLocation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PVK.Interfaces.Services.PickupLocation
{
    public interface IPickuplocationService
    {
        Task<PickupLocationResponse> GetAllPickuplocationList();
        Task<PickupLocationResponse> AddNewPickuplocation(AddPickuplocation addPickuplocation);
        Task<PickupLocationResponse> Updatepickuplocation(updatePickupLocation updatePickupLocation);
        Task<PickupLocationResponse> Deletepickuplocation(deletePickuplocation deletePickuplocation);
        Task<PickupLocationResponse> GetpickuplocationbyId(string guidpickuplocation);
    }
}
