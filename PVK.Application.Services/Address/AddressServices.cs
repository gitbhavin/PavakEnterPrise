using PVK.DTO.Address;
using PVK.Interfaces.Services.Address;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PVK.Application.Services.Address
{
    public class AddressServices : IAddressServices
    {
        private IAddressProcessor _addressProcessor;

        public AddressServices(IAddressProcessor addressProcessor)
        {
            this._addressProcessor = addressProcessor;
        }
        public async Task<AddressResponse> AddNewAddress(AddAddress addAddress)
        {
            return await _addressProcessor.AddNewAddress(addAddress);
        }

        public async Task<AddressResponse> GetAllAddressList()
        {
            return await _addressProcessor.GetAllAddressList();
        }

        public async Task<AddressResponse> RemoveAddress(DeleteAddress tbladdress)
        {
            return await _addressProcessor.RemoveAddress(tbladdress);
        }

        public async Task<AddressResponse> UpdateAddress(UpdateAddress tbladdress)
        {
            return await _addressProcessor.UpdateAddress(tbladdress);
        }
    }
}
