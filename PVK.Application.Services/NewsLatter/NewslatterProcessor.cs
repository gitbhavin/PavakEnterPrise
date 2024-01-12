using Microsoft.EntityFrameworkCore;
using PVK.DTO.Newslattersetup;
using PVK.EFCore.Data.NewsLetterSetupScope;
using PVK.Interfaces.Services.Newslatter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVK.Application.Services.NewsLatter
{
    public class NewslatterProcessor : INewslatterProcessor
    {
        public readonly NewslettersetupContext _newslatterContext;
        public NewslatterProcessor(NewslettersetupContext newslettersetupContext)
        {
            this._newslatterContext = newslettersetupContext;
        }
        public async Task<NewslatterResponse> Addnewslatter(Addnewslatter addnewslatter)
        {
            NewslatterResponse response = new NewslatterResponse();
            try
            {

                var email = _newslatterContext.TblNewsLetterSetups.Where(x => x.EmailId == addnewslatter.EmailId && x.Date_Inactive==null).FirstOrDefault();
                if (email == null)
                {

                    var newsLetterSetup = new tblNewsLetterSetup()
                    {
                        Guid_NewslatterId = Guid.NewGuid().ToString(),
                        EmailId = addnewslatter.EmailId,
                        Date_Inactive = null,
                        Date_Created = DateTime.Now,
                        Uid_Created = addnewslatter.UserId

                    };

                    await _newslatterContext.TblNewsLetterSetups.AddAsync(newsLetterSetup);
                    var result = await _newslatterContext.SaveChangesAsync();
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

        public async Task<NewslatterResponse> GetAllNewslatterEmail()
        {
            NewslatterResponse response = new NewslatterResponse();

            try
            {
                var result = await _newslatterContext.TblNewsLetterSetups.Where(x => x.Date_Inactive == null).OrderByDescending(a => a.Date_Created).ToListAsync();

                if (result != null)
                {
                    foreach (var item in result)
                    {
                        Newslatterdata data = new Newslatterdata();
                        data.Guid_NewslatterId = item.Guid_NewslatterId;
                        data.EmailId = item.EmailId;

                        response.newslatterdatas.Add(data);
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

        public async Task<NewslatterResponse> Updatenewslatter(Updatenewslatter updatenewslatter)
        {
            NewslatterResponse response = new NewslatterResponse();
            try
            {
                var email = _newslatterContext.TblNewsLetterSetups.Where(x => x.Guid_NewslatterId == updatenewslatter.Guid_NewslatterId).FirstOrDefault();
                if (email != null)
                {
                    email.Date_Inactive = DateTime.Now;
                    _newslatterContext.TblNewsLetterSetups.Update(email);
                    var result = await _newslatterContext.SaveChangesAsync();
                    if (result > 0)
                    {
                        response.Status = true;
                        response.Message = "Unsubscribe successfully";


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
    }
}
