using PVK.DTO.SMSTemplate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PVK.Interfaces.Services.SMSTemplate
{
   public interface ISmsTemplateServices
    {
        Task<SmsTemplateResponse> GetAllSmsTemplate();
        Task<SmsTemplateResponse> AddNewSmsTemplate(AddSmsTemplateData addSmsTemplateData);
        Task<SmsTemplateResponse> UpdateSmsTemplate(UpdateSmsTemplate tblSmsTemplate);
        Task<SmsTemplateResponse> RemoveSmsTemplate(DeleteSmsTemplate tblSmsTemplate);
    }
}
