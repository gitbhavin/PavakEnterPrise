using PVK.DTO.EmailTemplate;
using PVK.Interfaces.Services.EmailTemplate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PVK.Application.Services.EmailTemplate
{
    public class EmailTemplateService : IEmailtemplateService
    {
        private IEmailtemplateProcessor _emailtemplateProcessor;
        public EmailTemplateService(IEmailtemplateProcessor emailtemplateProcessor)
        {
            this._emailtemplateProcessor = emailtemplateProcessor;
        }
        public async Task<EmailTemplateResponse> Addemailtemplate(Addemailtemplate addemailtemplate)
        {
            return await _emailtemplateProcessor.Addemailtemplate(addemailtemplate);
        }

        public Task<EmailTemplateResponse> Deleteemailtemplate(Deleteemailtemplate deleteemailtemplate)
        {
            throw new NotImplementedException();
        }

        public async Task<EmailTemplateResponse> GetAllEmailTemplate()
        {
            return await _emailtemplateProcessor.GetAllEmailTemplate();
        }

        public async Task<EmailTemplateResponse> GetEmailTemplatebyId(string guidemailtemplateid)
        {
            return await _emailtemplateProcessor.GetEmailTemplatebyId(guidemailtemplateid);
        }

        public async Task<EmailTemplateResponse> Updateemailtemplate(Updateemailtemplate updateemailtemplate)
        {
            return await _emailtemplateProcessor.Updateemailtemplate(updateemailtemplate);
        }
    }
}
