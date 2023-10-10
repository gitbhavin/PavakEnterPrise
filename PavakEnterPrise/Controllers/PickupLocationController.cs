using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PVK.DTO.PickupLocation;
using PVK.Interfaces.Services.PickupLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PVK.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PickupLocationController : ControllerBase
    {
        private IPickuplocationService _services;

        public PickupLocationController(IPickuplocationService pickuplocationService)
        {
            this._services = pickuplocationService;
        }
        [HttpPost("AddNewPickuplocation")]
        public async Task<PickupLocationResponse> AddPickuplocation(AddPickuplocation addAddress)
        {
            return await _services.AddNewPickuplocation(addAddress);
        }
        [HttpGet("GetAllPickuplocationList")]
        public async Task<PickupLocationResponse> GetAllAddressList()
        {
            return await _services.GetAllPickuplocationList();
        }
        [HttpPost("Updatepickuplocation")]
        public async Task<PickupLocationResponse> UpdateAddress(updatePickupLocation tbladdress)
        {
            return await _services.Updatepickuplocation(tbladdress);
        }

        [HttpPost("Deletepickuplocation")]
        public async Task<PickupLocationResponse> deletePickuplocation(deletePickuplocation tbladdress)
        {
            return await _services.Deletepickuplocation(tbladdress);
        }
    }
}
