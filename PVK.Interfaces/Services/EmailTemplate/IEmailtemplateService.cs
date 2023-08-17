using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PVK.DTO.EmailTemplate;

namespace PVK.Interfaces.Services.EmailTemplate
{
    public interface IEmailtemplateService
    {
        Task<EmailTemplateResponse> GetAllEmailTemplate();

        Task<EmailTemplateResponse> Addemailtemplate(Addemailtemplate addemailtemplate);

        Task<EmailTemplateResponse> Deleteemailtemplate(Deleteemailtemplate deleteemailtemplate);

        Task<EmailTemplateResponse> Updateemailtemplate(Updateemailtemplate updateemailtemplate);

        Task<EmailTemplateResponse> GetEmailTemplatebyId(string guidemailtemplateid);
    }
}
