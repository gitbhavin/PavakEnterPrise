using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PVK.DTO.Email;
using PVK.Interfaces.Services.Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PVK.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _service;
        public EmailController(IEmailService emailService)
        {
            this._service = emailService;
        }
        [HttpGet("GetAllEmail")]
        public async Task<EmailResponse> GetAllEmail()
        {
            return await _service.GetAllEmail();
        }

        [HttpPost("Addemail")]
        public async Task<EmailResponse> AddnewEmail(AddEmail addEmail)
        {
            return await _service.AddEmail(addEmail);
        }
        [HttpPost("Deleteemail")]
        public async Task<EmailResponse> DeleteEmail(Deleteemail deleteemail)
        {
            return await _service.Deleteemail(deleteemail);
        }
        [HttpPost("Updateemail")]
        public async Task<EmailResponse> UpdateEmail(UpdateEmail updateEmail)
        {
            return await _service.UpdateEmail(updateEmail);
        }

        [HttpPost("GetEmailbyId")]
        public async Task<EmailResponse> GetEmailbyId(string guidEmailId)
        {
            return await _service.GetEmailbyId(guidEmailId);
        }
    }
}
