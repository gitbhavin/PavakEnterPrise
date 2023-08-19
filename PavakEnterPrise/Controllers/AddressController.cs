using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PVK.DTO.Address;
using PVK.Interfaces.Services.Address;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PVK.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private IAddressServices _services;

        public AddressController(IAddressServices addressServices)
        {
            this._services = addressServices;
        }
        [HttpPost("AddNewAddress")]
        public async Task<AddressResponse> AddNewAddress(AddAddress addAddress)
        {
            return await _services.AddNewAddress(addAddress);
        }
        [HttpGet("GetAllAddressList")]
        public async Task<AddressResponse> GetAllAddressList()
        {
            return await _services.GetAllAddressList();
        }
        [HttpPost("UpdateAddress")]
        public async Task<AddressResponse> UpdateAddress(UpdateAddress tbladdress)
        {
            return await _services.UpdateAddress(tbladdress);
        }

        [HttpPost("DeleteAddress")]
        public async Task<AddressResponse> DeleteAddress(DeleteAddress tbladdress)
        {
            return await _services.RemoveAddress(tbladdress);
        }
    }
}
