using PVK.DTO.ContactUs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PVK.Interfaces.Services.ContactUs
{
   public interface IContactUsProcessor
    {
        Task<ContactUsResponse> GetAllContactUsList();
        Task<ContactUsResponse> AddNewContactUs(AddContactUs addContactUs);
        Task<ContactUsResponse> UpdateContactUs(UpdateContactUs tblContactUs);
        Task<ContactUsResponse> DeleteContactUs(DeleteContactUs tblContactUs);
    }
}
