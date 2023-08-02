using PVK.DTO.SMSTemplate;
using PVK.Interfaces.Services.SMSTemplate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PVK.Application.Services.SMSTemplate
{
    public class SmsTemplateServices : ISmsTemplateServices
    {
        private ISmsTemplateProcessor _smsTemplateProcessor;

        public SmsTemplateServices(ISmsTemplateProcessor smsTemplateProcessor)
        {
            this._smsTemplateProcessor = smsTemplateProcessor;
        }
        public async Task<SmsTemplateResponse> AddNewSmsTemplate(AddSmsTemplateData addSmsTemplateData)
        {
            return await _smsTemplateProcessor.AddNewSmsTemplate(addSmsTemplateData);
        }

        public async Task<SmsTemplateResponse> GetAllSmsTemplate()
        {
            return await _smsTemplateProcessor.GetAllSmsTemplate();
        }

        public async Task<SmsTemplateResponse> RemoveSmsTemplate(DeleteSmsTemplate tblSmsTemplate)
        {
            return await _smsTemplateProcessor.RemoveSmsTemplate(tblSmsTemplate);
        }

        public async Task<SmsTemplateResponse> UpdateSmsTemplate(UpdateSmsTemplate tblSmsTemplate)
        {
            return await _smsTemplateProcessor.UpdateSmsTemplate(tblSmsTemplate);
        }
    }
}
