using Microsoft.EntityFrameworkCore;
using PVK.DTO.Email;
using PVK.EFCore.Data.EmailScope;
using PVK.Interfaces.Services.Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVK.Application.Services.Email
{
    public class EmailProcessor : IEmailProcessor
    {
        private EmailContext _emailContext;
        public EmailProcessor(EmailContext emailContext)
        {
            this._emailContext = emailContext;
        }
        public async Task<EmailResponse> AddEmail(AddEmail addEmail)
        {
            EmailResponse response = new EmailResponse();
            try
            {

               

                    var email = new TblEmail()
                    {
                        Guid_Emailid = Guid.NewGuid().ToString(),
                        FromAddress = addEmail.FromAddress,
                        ToAddress=addEmail.ToAddress,
                        BccAddress=addEmail.BccAddress,
                        Subject=addEmail.Subject,
                        Body=addEmail.Body,
                        Date_Inactive = null,
                        Date_Created = DateTime.Now,
                        Uid_Created = addEmail.UserId


                    };

                    await _emailContext.TblEmails.AddAsync(email);
                    var result = await _emailContext.SaveChangesAsync();
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

        public async Task<EmailResponse> Deleteemail(Deleteemail deleteemail)
        {
            EmailResponse response = new EmailResponse();
            try
            {

                var email = _emailContext.TblEmails.Where(x => x.Guid_Emailid == deleteemail.Guid_Emailid).FirstOrDefault();

                if (email != null)
                {




                    email.Date_Inactive = DateTime.Now;
                    email.Uid_Modified = deleteemail.UserId;


                    _emailContext.TblEmails.Update(email);
                    var result = await _emailContext.SaveChangesAsync();
                    if (result > 0)
                    {
                        response.Status = true;
                        response.Message = "email deleted successfully";


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

        public async Task<EmailResponse> GetAllEmail()
        {
            EmailResponse response = new EmailResponse();

            try
            {
                var result = await _emailContext.TblEmails.Where(x => x.Date_Inactive == null).OrderByDescending(a => a.Date_Created).ToListAsync();

                if (result != null)
                {
                    foreach (var item in result)
                    {
                        EmailData data = new EmailData();
                        data.Guid_Emailid = item.Guid_Emailid;
                        data.FromAddress = item.FromAddress;
                        data.ToAddress = item.ToAddress;
                        data.BccAddress = item.BccAddress;
                        data.Subject = item.Subject;
                        data.Body = item.Body;

                        response.emailDatas.Add(data);
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

        public async Task<EmailResponse> GetEmailbyId(string guidemailid)
        {
            EmailResponse response = new EmailResponse();

            try
            {
                var result = await _emailContext.TblEmails.Where(x => x.Date_Inactive == null && x.Guid_Emailid == guidemailid).ToListAsync();

                if (result != null)
                {
                    foreach (var item in result)
                    {
                        EmailData data = new EmailData();
                        data.Guid_Emailid = item.Guid_Emailid;
                        data.FromAddress = item.FromAddress;
                        data.ToAddress = item.ToAddress;
                        data.BccAddress = item.BccAddress;
                        data.Subject = item.Subject;
                        data.Body = item.Body;

                        response.emailDatas.Add(data);
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

        public async Task<EmailResponse> UpdateEmail(UpdateEmail updateEmail)
        {
            EmailResponse response = new EmailResponse();
            try
            {

                var email = new TblEmail()
                {
                    Guid_Emailid = Guid.NewGuid().ToString(),
                    FromAddress = updateEmail.FromAddress,
                    ToAddress = updateEmail.ToAddress,
                    BccAddress = updateEmail.BccAddress,
                    Subject = updateEmail.Subject,
                    Body = updateEmail.Body,
                    Date_Inactive = null,
                    Date_Created = DateTime.Now,
                    Uid_Created = updateEmail.UserId


                };

                 _emailContext.TblEmails.Update(email);
                var result = await _emailContext.SaveChangesAsync();
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
