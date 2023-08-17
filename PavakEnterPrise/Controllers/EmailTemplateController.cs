using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PVK.DTO.EmailTemplate;
using PVK.Interfaces.Services.EmailTemplate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PVK.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailTemplateController : ControllerBase
    {
        private readonly IEmailtemplateService _service;
        public EmailTemplateController(IEmailtemplateService emailService)
        {
            this._service = emailService;
        }
        [HttpGet("GetAllEmailTemplate")]
        public async Task<EmailTemplateResponse> GetAllEmailtemplate()
        {
            return await _service.GetAllEmailTemplate();
        }

        [HttpPost("Addemailtemplate")]
        public async Task<EmailTemplateResponse> Addemailtemplate(Addemailtemplate addEmail)
        {
            return await _service.Addemailtemplate(addEmail);
        }
        [HttpPost("Deleteemailtemplate")]
        public async Task<EmailTemplateResponse> Deleteemailtemplate(Deleteemailtemplate deleteemail)
        {
            return await _service.Deleteemailtemplate(deleteemail);
        }
        [HttpPost("Updateemailtemplate")]
        public async Task<EmailTemplateResponse> Updateemailtemplate(Updateemailtemplate updateEmail)
        {
            return await _service.Updateemailtemplate(updateEmail);
        }

        [HttpPost("GetEmailtemplatebyId")]
        public async Task<EmailTemplateResponse> GetEmailtemplatebyId(string guidEmailtemplateId)
        {
            return await _service.GetEmailTemplatebyId(guidEmailtemplateId);
        }
    }
}
