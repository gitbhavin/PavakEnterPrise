using Microsoft.EntityFrameworkCore;
using PVK.DTO.PickupLocation;
using PVK.EFCore.Data.PickupLocationScope;
using PVK.Interfaces.Services.PickupLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVK.Application.Services.PickupLocation
{
    public class PickuplocationProcessor : IPickuplocationProcessor
    {
        private PickupLocationContext _pickuplocationContext;

        public PickuplocationProcessor(PickupLocationContext pickupLocationContext)
        {
            this._pickuplocationContext = pickupLocationContext;
        }
        public async Task<PickupLocationResponse> AddNewPickuplocation(AddPickuplocation addPickuplocation)
        {
            PickupLocationResponse response = new PickupLocationResponse();
            try
            {               
                    var address = new TblPickupLocation()
                    {
                        Guid_PickupLocationId = Guid.NewGuid().ToString(),
                        ContactName=addPickuplocation.ContactName,
                        ContactNumber=addPickuplocation.ContactNumber,
                        ContactNumber2=addPickuplocation.ContactNumber2,
                        CityName = addPickuplocation.CityName,                       
                        Address1 = addPickuplocation.Address1,
                        Address2 = addPickuplocation.Address2,
                        City = addPickuplocation.City,
                        State = addPickuplocation.State,
                        Zipcode = addPickuplocation.Zipcode,
                        Country = addPickuplocation.Country,                       
                        Latitude = addPickuplocation.Latitude,
                        Longitude = addPickuplocation.Longitude,
                        Date_Inactive = null,
                        Date_Created = DateTime.Now,
                        Uid_Created = addPickuplocation.UserId
                    };

                    await _pickuplocationContext.TblPickupLocations.AddAsync(address);
                    var result = await _pickuplocationContext.SaveChangesAsync();
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
               
                return response;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;

                return response;
            }
        }

        public async Task<PickupLocationResponse> Deletepickuplocation(deletePickuplocation deletePickuplocation)
        {
            PickupLocationResponse response = new PickupLocationResponse();
            try
            {
                var address = _pickuplocationContext.TblPickupLocations.Where(x => x.Guid_PickupLocationId == deletePickuplocation.Guid_PickupLocationId).FirstOrDefault();
                if (address != null)
                {
                    address.Date_Inactive = DateTime.Now;
                    address.Uid_Modified = deletePickuplocation.UserId;

                    _pickuplocationContext.TblPickupLocations.Update(address);
                    var result = await _pickuplocationContext.SaveChangesAsync();
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

        public async Task<PickupLocationResponse> GetAllPickuplocationList()
        {
            PickupLocationResponse response = new PickupLocationResponse();
            try
            {
                var result = await _pickuplocationContext.TblPickupLocations.Where(x => x.Date_Inactive == null).ToListAsync();

                
                if (result != null)
                {
                    foreach (var item in result)
                    {
                        PickupLocationdata data = new PickupLocationdata();
                        data.Guid_PickupLocationId = item.Guid_PickupLocationId;
                        data.ContactName = item.ContactName;
                        data.ContactNumber = item.ContactNumber;
                        data.ContactNumber2 = item.ContactNumber2;
                        data.Address1 = item.Address1;
                        data.Address2 = item.Address2;
                        data.City = item.City;
                        data.State = item.State;
                        data.Zipcode = item.Zipcode;
                        data.Country = item.Country;
                        data.CityName = item.CityName;
                        data.Latitude = item.Latitude;
                        data.Longitude = item.Longitude;
                        
                        response.pickuplocationDatas.Add(data);
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

        public async Task<PickupLocationResponse> Updatepickuplocation(updatePickupLocation updatePickupLocation)
        {
            PickupLocationResponse response = new PickupLocationResponse();
            try
            {
                var addressdata = new TblPickupLocation()
                {
                    Guid_PickupLocationId = updatePickupLocation.Guid_PickupLocationId,
                    CityName=updatePickupLocation.CityName,
                    Address1 = updatePickupLocation.Address1,
                    Address2 = updatePickupLocation.Address2,
                    City = updatePickupLocation.City,
                    State = updatePickupLocation.State,
                    Zipcode = updatePickupLocation.Zipcode,
                    Country = updatePickupLocation.Country,                  
                    Latitude = updatePickupLocation.Latitude,
                    Longitude = updatePickupLocation.Longitude,
                    Uid_Modified = updatePickupLocation.UserId,
                    Date_Modified = DateTime.Now
                };

                _pickuplocationContext.TblPickupLocations.Update(addressdata);
                var result = await _pickuplocationContext.SaveChangesAsync();
                if (result > 0)
                {
                    response.Status = true;
                    response.Message = "pickuplocation Updated Successfully";
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
