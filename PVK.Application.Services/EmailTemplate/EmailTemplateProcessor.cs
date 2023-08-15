using Microsoft.EntityFrameworkCore;
using PVK.DTO.EmailTemplate;
using PVK.EFCore.Data.EmailTemplateScope;
using PVK.Interfaces.Services.EmailTemplate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVK.Application.Services.EmailTemplate
{
    public class EmailTemplateProcessor : IEmailtemplateProcessor
    {
        private readonly EmailTemplateContext _emailTemplateContext;

        public EmailTemplateProcessor(EmailTemplateContext emailTemplateContext)
        {
            this._emailTemplateContext = emailTemplateContext;
        }
        public async Task<EmailTemplateResponse> Addemailtemplate(Addemailtemplate addemailtemplate)
        {
            EmailTemplateResponse response = new EmailTemplateResponse();
            try
            {



                var emailtemplate = new TblEmailTemplate()
                {
                    Guid_EmailTemplateid = Guid.NewGuid().ToString(),
                   Name=addemailtemplate.Name,
                   Code=addemailtemplate.Code,
                    Subject = addemailtemplate.Subject,
                    Body = addemailtemplate.Body,
                    Date_Inactive = null,
                    Date_Created = DateTime.Now,
                    Uid_Created = addemailtemplate.UserId


                };

                await _emailTemplateContext.TblEmailTemplates.AddAsync(emailtemplate);
                var result = await _emailTemplateContext.SaveChangesAsync();
                if (result > 0)
                {
                    response.Status = true;
                    response.Message = "data save successfully";


                }
                else
                {
                    response.Status = false;
                    response.Message = "data already added";
                }

                return response;
            }
            catch (Exception ex)
            {

                response.Message = ex.Message;
                response.Status = false;

                return response;
            }
        }

        public async Task<EmailTemplateResponse> Deleteemailtemplate(Deleteemailtemplate deleteemailtemplate)
        {

            EmailTemplateResponse response = new EmailTemplateResponse();
            try
            {

                var email = _emailTemplateContext.TblEmailTemplates.Where(x => x.Guid_EmailTemplateid == deleteemailtemplate.Guid_EmailTemplateid).FirstOrDefault();

                if (email != null)
                {




                    email.Date_Inactive = DateTime.Now;
                    email.Uid_Modified = deleteemailtemplate.UserId;


                    _emailTemplateContext.TblEmailTemplates.Update(email);
                    var result = await _emailTemplateContext.SaveChangesAsync();
                    if (result > 0)
                    {
                        response.Status = true;
                        response.Message = "email template deleted successfully";


                    }
                    else
                    {
                        response.Status = false;
                        response.Message = "data already added";
                    }
                }
                return response;

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;

                return response;
            }
        }

        public async Task<EmailTemplateResponse> GetAllEmailTemplate()
        {
            EmailTemplateResponse response = new EmailTemplateResponse();

            try
            {
                var result = await _emailTemplateContext.TblEmailTemplates.Where(x => x.Date_Inactive == null).OrderByDescending(a => a.Date_Created).ToListAsync();

                if (result != null)
                {
                    foreach (var item in result)
                    {
                        EmailTemplateData data = new EmailTemplateData();
                        data.Guid_EmailTemplateid = item.Guid_EmailTemplateid;
                        data.Name = item.Name;
                        data.Code = item.Code;
                       
                        data.Subject = item.Subject;
                        data.Body = item.Body;

                        response.emailTemplateDatas.Add(data);
                    }
                    response.Message = "Success!";
                    response.Status = true;
                }
                else
                {
                    response.Message = "No Record Found!";
                    response.Status = true;
                }
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;

                return response;
            }
        }

        public async Task<EmailTemplateResponse> GetEmailTemplatebyId(string guidemailtemplateid)
        {
            EmailTemplateResponse response = new EmailTemplateResponse();

            try
            {
                var result = await _emailTemplateContext.TblEmailTemplates.Where(x => x.Date_Inactive == null && x.Guid_EmailTemplateid == guidemailtemplateid).ToListAsync();

                if (result != null)
                {
                    foreach (var item in result)
                    {
                        EmailTemplateData data = new EmailTemplateData();
                        data.Guid_EmailTemplateid = item.Guid_EmailTemplateid;
                        data.Name = item.Name;
                        data.Code = item.Code;

                        data.Subject = item.Subject;
                        data.Body = item.Body;

                        response.emailTemplateDatas.Add(data);
                    }
                    response.Message = "Success!";
                    response.Status = true;
                }
                else
                {
                    response.Message = "No Record Found!";
                    response.Status = true;
                }
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;

                return response;
            }
        }

        public async Task<EmailTemplateResponse> Updateemailtemplate(Updateemailtemplate updateemailtemplate)
        {
            EmailTemplateResponse response = new EmailTemplateResponse();
            try
            {

                var emailtemplate = new TblEmailTemplate()
                {
                    Guid_EmailTemplateid = updateemailtemplate.Guid_EmailTemplateid,
                    Name = updateemailtemplate.Name,
                    Code = updateemailtemplate.Code,
                    Subject = updateemailtemplate.Subject,
                    Body = updateemailtemplate.Body,
                    Date_Inactive = null,
                    Date_Created = DateTime.Now,
                    Uid_Created = updateemailtemplate.UserId


                };

                _emailTemplateContext.TblEmailTemplates.Update(emailtemplate);
                var result = await _emailTemplateContext.SaveChangesAsync();
                if (result > 0)
                {
                    response.Status = true;
                    response.Message = "data updated successfully";


                }
                return response;
            }
            catch (Exception ex)
            {

                response.Message = ex.Message;
                response.Status = false;

                return response;
            }
        }
    }
}
