using PVK.DTO.SMSTemplate;
using PVK.EFCore.Data.SMSTemplate;
using PVK.Interfaces.Services.SMSTemplate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace PVK.Application.Services.SMSTemplate
{
    public class SmsTemplateProcessor : ISmsTemplateProcessor
    {
        private SmsTemplateContext _smsTemplateContext;

        public SmsTemplateProcessor(SmsTemplateContext smsTemplateContext)
        {
            this._smsTemplateContext = smsTemplateContext;
        }
        public async Task<SmsTemplateResponse> AddNewSmsTemplate(AddSmsTemplateData addSmsTemplateData)
        {
            SmsTemplateResponse response = new SmsTemplateResponse();
            try
            {
                var smsTemplate = _smsTemplateContext.TblSmsTemplates.Where(a => a.Name == addSmsTemplateData.Name).FirstOrDefault();
                if(smsTemplate == null)
                {
                    var guid = Guid.NewGuid();
                    var smstemp = new TblSmsTemplate()
                    {
                        GuidSMSTemplateId=guid.ToString(),
                        Name=addSmsTemplateData.Name,
                        Code=addSmsTemplateData.Code,
                        Subject=addSmsTemplateData.Subject,
                        Body=addSmsTemplateData.Body
                    };

                    await _smsTemplateContext.TblSmsTemplates.AddAsync(smstemp);
                    var result = await _smsTemplateContext.SaveChangesAsync();
                    if (result > 0)
                    {
                        response.Status = true;
                        response.Message = "Data save successfully";
                    }
                    else
                    {
                        response.Status = false;
                        response.Message = "data already added";
                    }
                }
                else
                {
                    response.Status = false;
                    response.Message = "data already added";
                }
                return response;
            }catch(Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;

                return response;
            }
        }

        public async Task<SmsTemplateResponse> GetAllSmsTemplate()
        {
            SmsTemplateResponse response = new SmsTemplateResponse();
            try
            {
                var result = await _smsTemplateContext.TblSmsTemplates.Where(a => a.DateInactive == null).ToListAsync();
                if(result != null)
                {
                    foreach(var item in result)
                    {
                        SmsTemplateData data = new SmsTemplateData();
                        data.GuidSMSTemplateId = item.GuidSMSTemplateId;
                        data.Name = item.Name;
                        data.Code = item.Code;
                        data.Subject = item.Subject;
                        data.Body = item.Body;

                        response.smsTemplateDatas.Add(data);
                    }
                    response.Status = true;
                    response.Message = "Sucsess";
                }
                else
                {
                    response.Status = true;
                    response.Message = "No Record Found";
                }
                return response;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;

                return response;

            }
        }

        public async Task<SmsTemplateResponse> RemoveSmsTemplate(DeleteSmsTemplate tblSmsTemplate)
        {
            SmsTemplateResponse response = new SmsTemplateResponse();
            try
            {
                var smstemplate = new TblSmsTemplate()
                {
                    GuidSMSTemplateId = tblSmsTemplate.GuidSMSTemplateId
                };

                _smsTemplateContext.TblSmsTemplates.Remove(smstemplate);
                var result = await _smsTemplateContext.SaveChangesAsync();
                if (result > 0)
                {
                    response.Status = true;
                    response.Message = "Data Deleted Successfully";
                }
                else
                {
                    response.Status = false;
                    response.Message = "Data alredy added";
                }
                return response;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;

                return response;
            }
        }

        public async Task<SmsTemplateResponse> UpdateSmsTemplate(UpdateSmsTemplate tblSmsTemplate)
        {
            SmsTemplateResponse response = new SmsTemplateResponse();
            try
            {
                var smstemplate = new TblSmsTemplate()
                {
                    GuidSMSTemplateId = tblSmsTemplate.GuidSMSTemplateId,
                    Name = tblSmsTemplate.Name,
                    Code=tblSmsTemplate.Code,
                    Subject=tblSmsTemplate.Subject,
                    Body=tblSmsTemplate.Body
                };

                _smsTemplateContext.Update(smstemplate);
                var result = await _smsTemplateContext.SaveChangesAsync();
                if (result > 0)
                {
                    response.Status = true;
                    response.Message = "Data Updated Successfully";
                }
                return response;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;

                return response;
            }
        }
    }
}
