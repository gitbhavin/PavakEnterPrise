using Microsoft.EntityFrameworkCore;
using PVK.DTO.ContactUs;
using PVK.EFCore.Data.ContactUsScope;
using PVK.Interfaces.Services.ContactUs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVK.Application.Services.ContactUs
{
    public class ContactUsProcessor : IContactUsProcessor
    {
        private ContactUsContext _contactUsContext;

        public ContactUsProcessor(ContactUsContext contactUsContext)
        {
            this._contactUsContext = contactUsContext;
        }
        public async Task<ContactUsResponse> AddNewContactUs(AddContactUs addContactUs)
        {
            ContactUsResponse response = new ContactUsResponse();
            try
            {

                var contactusname = _contactUsContext.TblContactUs.Where(x => x.Name == addContactUs.Name).FirstOrDefault();
                if (contactusname == null)
                {
                    var contactus = new TblContactUs()
                    {
                        GuidContactusid = Guid.NewGuid().ToString(),
                        Name = addContactUs.Name,
                        Email = addContactUs.Email,
                        Phone = addContactUs.Phone,
                        Message = addContactUs.Message,
                        Date_Inactive = null,
                        Uid_Created = addContactUs.UserId,
                        Date_Created = DateTime.Now
                    };

                    await _contactUsContext.TblContactUs.AddAsync(contactus);
                    var result = await _contactUsContext.SaveChangesAsync();
                    if (result > 0)
                    {
                        response.Status = true;
                        response.Message = "data save successfully";

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

                response.Message = ex.Message;
                response.Status = false;

                return response;
            }
        }

        public async Task<ContactUsResponse> DeleteContactUs(DeleteContactUs tblContactUs)
        {
            ContactUsResponse response = new ContactUsResponse();
            try
            {
                var contactus = _contactUsContext.TblContactUs.Where(x => x.GuidContactusid == tblContactUs.GuidContactusid).FirstOrDefault();
                if(contactus != null)
                {
                    contactus.Date_Modified = DateTime.Now;
                    contactus.Uid_Modified = tblContactUs.UserId;

                    _contactUsContext.TblContactUs.Update(contactus);
                    var result = await _contactUsContext.SaveChangesAsync();
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
        

        public async Task<ContactUsResponse> GetAllContactUsList()
        {
            ContactUsResponse response = new ContactUsResponse();
            try
            {
                var result = await _contactUsContext.TblContactUs.Where(x => x.Date_Inactive == null).ToListAsync();
                if(result != null)
                {
                    foreach(var item in result)
                    {
                        ContactUsData data = new ContactUsData();
                        data.GuidContactusid = item.GuidContactusid;
                        data.UserId = item.Uid_Created;
                        data.Name = item.Name;
                        data.Email = item.Email;
                        data.Phone = item.Phone;
                        data.Message = item.Message;

                        response.contactUsDatas.Add(data);
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

        public async Task<ContactUsResponse> UpdateContactUs(UpdateContactUs tblContactUs)
        {
            ContactUsResponse response = new ContactUsResponse();
            try
            {
                var contactus = new TblContactUs()
                {
                    GuidContactusid=tblContactUs.GuidContactusid,
                    Name=tblContactUs.Name,
                    Email=tblContactUs.Email,
                    Phone=tblContactUs.Phone,
                    Message=tblContactUs.Message,
                    Date_Modified=DateTime.Now,
                    Uid_Modified=tblContactUs.UserId
                };
                _contactUsContext.TblContactUs.Update(contactus);
                var result = await _contactUsContext.SaveChangesAsync();
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
