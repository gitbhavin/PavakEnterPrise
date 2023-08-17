using PVK.DTO.ContactUs;
using PVK.Interfaces.Services.ContactUs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PVK.Application.Services.ContactUs
{
    public class ContactUsServices : IContactUsServices
    {
        private IContactUsProcessor _contactUsProcessor;

        public ContactUsServices(IContactUsProcessor contactUsProcessor)
        {
            this._contactUsProcessor = contactUsProcessor;
        }
        public async Task<ContactUsResponse> AddNewContactUs(AddContactUs addContactUs)
        {
            return await _contactUsProcessor.AddNewContactUs(addContactUs);
        }

        public async Task<ContactUsResponse> DeleteContactUs(DeleteContactUs tblContactUs)
        {
            return await _contactUsProcessor.DeleteContactUs(tblContactUs);
        }

        public async Task<ContactUsResponse> GetAllContactUsList()
        {
            return await _contactUsProcessor.GetAllContactUsList();
        }

        public async Task<ContactUsResponse> UpdateContactUs(UpdateContactUs tblContactUs)
        {
            return await _contactUsProcessor.UpdateContactUs(tblContactUs);
        }
    }
}
