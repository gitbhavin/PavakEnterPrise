using PVK.DTO.Address;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PVK.Interfaces.Services.Address
{
   public interface IAddressServices
    {
        Task<AddressResponse> GetAllAddressList();
        Task<AddressResponse> AddNewAddress(AddAddress addAddress);
        Task<AddressResponse> UpdateAddress(UpdateAddress tbladdress);
        Task<AddressResponse> RemoveAddress(DeleteAddress tbladdress);
    }
}
