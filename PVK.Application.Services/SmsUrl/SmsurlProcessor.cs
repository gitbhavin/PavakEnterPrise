﻿using PVK.DTO.SmsUrl;
using PVK.EFCore.Data.SmsUrlScope;
using PVK.Interfaces.Services.SmsUrl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace PVK.Application.Services.SmsUrl
{
    public class SmsurlProcessor : ISmsurlProcessor
    {
        private SmsurlContext _smsurlContext;

        public SmsurlProcessor(SmsurlContext smsurlContext)
        {
            this._smsurlContext = smsurlContext;
        }

        public async Task<SmsurlResponse> AddnewSmsurl(Addsmsurldata addsmsurldata)
        {
            SmsurlResponse Response = new SmsurlResponse();
            try
            {
                var smsurl = _smsurlContext.TblSmsurls.Where(a => a.Url == addsmsurldata.Url).FirstOrDefault();
                if(smsurl == null)
                {
                    var guid = Guid.NewGuid();
                    var sms = new TblSmsurl()
                    {
                        GuidSMSURL = guid.ToString(),
                        Url = addsmsurldata.Url,
                        Uid_Created = addsmsurldata.UserId,
                        Date_Inactive = null ,
                        Date_Created=DateTime.Now
                    };

                    await _smsurlContext.TblSmsurls.AddAsync(sms);
                    var result = await _smsurlContext.SaveChangesAsync();
                    if(result > 0)
                    {
                        Response.Status = true;
                        Response.Message = "Data save successfully";
                    }
                    else
                    {
                        Response.Status = false;
                        Response.Message= "data already added";
                    }
                }
                else
                {
                    Response.Status = false;
                    Response.Message = "data already added";
                }
                return Response;
            }
            catch(Exception ex)
            {
                Response.Status = false;
                Response.Message = ex.Message;

                return Response;
            }
           
        }

        public async Task<SmsurlResponse> GelAllSmsurl()
        {
            SmsurlResponse response = new SmsurlResponse();
            try
            {
                var result = await _smsurlContext.TblSmsurls.Where(e => e.Date_Inactive == null).ToListAsync();
                if(result != null)
                {
                    foreach(var item in result)
                    {
                        SmsurlData data = new SmsurlData();
                        data.GuidSMSURL = item.GuidSMSURL;
                        data.Url = item.Url;

                        response.Smsurldata.Add(data);
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
        
        public async Task<SmsurlResponse> RemoveSmsurl(deleteSmsurl tblSmsurl)
        {
            SmsurlResponse response = new SmsurlResponse();
            try
            {
                var resultsmsurl = _smsurlContext.TblSmsurls.Where(x => x.GuidSMSURL == tblSmsurl.GuidSMSURL).FirstOrDefault();
                if(resultsmsurl != null)
                {
                    resultsmsurl.Date_Inactive = DateTime.Now;
                    resultsmsurl.Uid_Modified = tblSmsurl.UserId;

                    _smsurlContext.TblSmsurls.Update(resultsmsurl);
                    var result = await _smsurlContext.SaveChangesAsync();
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

                }
                else
                {
                    response.Status = false;
                    response.Message = "Data not exist";
                }

                return response;
            }
            catch(Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;

                return response;
            }
        }

        public async Task<SmsurlResponse> UpdateSmsurl(updateSmsurl tblSmsurl)
        {
            SmsurlResponse response = new SmsurlResponse();
            try
            {
                var sms = new TblSmsurl()
                {
                    GuidSMSURL = tblSmsurl.GuidSMSURL,
                    Url = tblSmsurl.Url,
                    Uid_Modified=tblSmsurl.UserId,
                    Date_Modified = DateTime.Now

                };

                _smsurlContext.Update(sms);
                var result = await _smsurlContext.SaveChangesAsync();
                if(result > 0)
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
