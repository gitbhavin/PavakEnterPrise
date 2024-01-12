using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PVK.DTO.SMSTemplate;
using PVK.Interfaces.Services.SMSTemplate;

namespace PVK.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SmsTemplateController : ControllerBase
    {
        private ISmsTemplateServices _services;

        public SmsTemplateController(ISmsTemplateServices smsTemplateServices)
        {
            this._services = smsTemplateServices;
        }
        [HttpPost("addNewSmsTemplate")]
        public async Task<SmsTemplateResponse> addNewSmsTemplate(AddSmsTemplateData addSmsTemplateData)
        {
            return await _services.AddNewSmsTemplate(addSmsTemplateData);
        }
        [HttpGet("GetAllSmsTemplate")]
        public async Task<SmsTemplateResponse> GetAllSmsTemplate()
        {
            return await _services.GetAllSmsTemplate();
        }
        [HttpPost("DeleteSmsTemplate")]
        public async Task<SmsTemplateResponse> DeleteSmsTemplate(DeleteSmsTemplate deleteSmsTemplate)
        {
            return await _services.RemoveSmsTemplate(deleteSmsTemplate);
        }
        [HttpPost("UpdateSmsTemplate")]
        public async Task<SmsTemplateResponse> UpdateSmsTemplate(UpdateSmsTemplate updateSmsTemplate)
        {
            return await _services.UpdateSmsTemplate(updateSmsTemplate);
        }
        [HttpPost("GetsmstemplatebyId")]
        public async Task<SmsTemplateResponse> GetsmstemplatebyId(string guidsmstemplateId)
        {
            return await _services.Getsmstemplatebyguid(guidsmstemplateId);
        }

    }
}
