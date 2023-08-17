using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PVK.DTO.ContactUs;
using PVK.Interfaces.Services.ContactUs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PVK.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactUsController : ControllerBase
    {
        private IContactUsServices _services;

        public ContactUsController(IContactUsServices contactUsServices)
        {
            this._services = contactUsServices;
        }
        [HttpPost("AddNewContactUs")]
        public async Task<ContactUsResponse> AddNewContactUs(AddContactUs addContactUs)
        {
            return await _services.AddNewContactUs(addContactUs);
        }
        [HttpGet("GetAllContactUsList")]
        public async Task<ContactUsResponse> GetAllContactUsList()
        {
            return await _services.GetAllContactUsList();
        }
        [HttpPost("UpdateContactUs")]
        public async Task<ContactUsResponse> UpdateContactUs(UpdateContactUs tblContactUsU)
        {
            return await _services.UpdateContactUs(tblContactUsU);
        }
        [HttpPost("DeleteContactUs")]
        public async Task<ContactUsResponse> DeleteContactUs(DeleteContactUs tblContactUs)
        {
            return await _services.DeleteContactUs(tblContactUs);
        }
    }
}
