using Microsoft.EntityFrameworkCore;
using PVK.DTO.Address;
using PVK.EFCore.Data.AddressScope;
using PVK.Interfaces.Services.Address;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVK.Application.Services.Address
{
    public class AddressProcessor : IAddressProcessor
    {
        private AddressContext _addressContext;

        public AddressProcessor(AddressContext addressContext)
        {
            this._addressContext = addressContext;
        }
        public async Task<AddressResponse> AddNewAddress(AddAddress addAddress)
        {
            AddressResponse response = new AddressResponse();
            try
            {
                var addressFirstName = await _addressContext.TblAddresses.Where(x => x.FirstName == addAddress.FirstName).ToListAsync();
                if(addressFirstName.Count == 0)
                {
                    var address = new TblAddress()
                    {
                        GuidAddressId = Guid.NewGuid().ToString(),
                        VersionId=addAddress.VersionId,
                        FirstName=addAddress.FirstName,
                        LastName=addAddress.LastName,
                        Email=addAddress.Email,
                        Phone=addAddress.Phone,
                        Address1=addAddress.Address1,
                        Address2=addAddress.Address2,
                        City=addAddress.City,
                        State=addAddress.State,
                        Zipcode=addAddress.Zipcode,
                        Country=addAddress.Country,
                        IsDefault=addAddress.IsDefault,
                        IsBilling=addAddress.IsBilling,
                        IsDelivery=addAddress.IsDelivery,
                        Latitude=addAddress.Latitude,
                        Longitude=addAddress.Longitude,
                        Date_Inactive=null,
                        Date_Created=DateTime.Now,
                        Uid_Created=addAddress.UserId
                    };

                    await _addressContext.TblAddresses.AddAsync(address);
                    var result = await _addressContext.SaveChangesAsync();
                    if (result > 0)
                    {
                        response.Status = true;
                        response.Message = "Data save successfully";
                    }
                    else
                    {
                        response.Status = false;
                        response.Message = "data already added";
                    }
                }
                else
                {
                    response.Status = false;
                    response.Message = "data already added";
                }
                return response;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;

                return response;
            }
            
        }

        public async Task<AddressResponse> GetAllAddressList()
        {
            AddressResponse response = new AddressResponse();
            try
            {
                var result = await _addressContext.TblAddresses.Where(x => x.Date_Inactive == null).ToListAsync();
                if(result != null)
                {
                    foreach(var item in result)
                    {
                        AddressData data = new AddressData();
                        data.GuidAddressId = item.GuidAddressId;
                        data.VersionId = item.VersionId;
                        data.FirstName = item.FirstName;
                        data.LastName = item.LastName;
                        data.Email = item.Email;
                        data.Phone = item.Phone;
                        data.Address1 = item.Address1;
                        data.Address2 = item.Address2;
                        data.City = item.City;
                        data.State = item.State;
                        data.Zipcode = item.Zipcode;
                        data.Country = item.Country;
                        data.IsDefault = item.IsDefault;
                        data.IsBilling = item.IsBilling;
                        data.IsDelivery = item.IsDelivery;
                        data.Latitude = item.Latitude;
                        data.Longitude = item.Longitude;

                        response.addressDatas.Add(data);
                    }
                    response.Status = true;
                    response.Message = "Sucsess";
                }
                else
                {
                    response.Status = true;
                    response.Message = "No Record Found";
                }
                return response;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;

                return response;

            }
        }

        public async Task<AddressResponse> RemoveAddress(DeleteAddress tbladdress)
        {
            AddressResponse response = new AddressResponse();
            try
            {
                var address = _addressContext.TblAddresses.Where(x => x.GuidAddressId == tbladdress.GuidAddressId).FirstOrDefault();
                if(address != null)
                {
                    address.Date_Inactive = DateTime.Now;
                    address.Uid_Modified = tbladdress.UserId;

                    _addressContext.TblAddresses.Update(address);
                    var result = await _addressContext.SaveChangesAsync();
                    if (result > 0)
                    {
                        response.Status = true;
                        response.Message = "Data Deleted Successfully";
                    }
                    else
                    {
                        response.Status = false;
                        response.Message = "Data alredy added";
                    }
                }
                else
                {
                    response.Status = false;
                    response.Message = "Data not exist";
                }
                return response;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;

                return response;
            }
            
        }

        public async Task<AddressResponse> UpdateAddress(UpdateAddress tbladdress)
        {
            AddressResponse response = new AddressResponse();
            try
            {
                var addressdata = new TblAddress()
                {
                    GuidAddressId=tbladdress.GuidAddressId,
                    VersionId=tbladdress.VersionId,
                    FirstName=tbladdress.FirstName,
                    LastName=tbladdress.LastName,
                    Email=tbladdress.Email,
                    Phone=tbladdress.Phone,
                    Address1=tbladdress.Address1,
                    Address2=tbladdress.Address2,
                    City=tbladdress.City,
                    State=tbladdress.State,
                    Zipcode=tbladdress.Zipcode,
                    Country=tbladdress.Country,
                    IsDefault=tbladdress.IsDefault,
                    IsBilling=tbladdress.IsBilling,
                    IsDelivery=tbladdress.IsDelivery,
                    Latitude=tbladdress.Latitude,
                    Longitude=tbladdress.Longitude,
                    Uid_Modified=tbladdress.UserId,
                    Date_Modified=DateTime.Now
                };

                _addressContext.TblAddresses.Update(addressdata);
                var result = await _addressContext.SaveChangesAsync();
                if (result > 0)
                {
                    response.Status = true;
                    response.Message = "Data Updated Successfully";
                }
                return response;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;

                return response;
            }
            
        }
    }
}
