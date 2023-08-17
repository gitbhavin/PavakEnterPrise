using Microsoft.EntityFrameworkCore;
using PVK.DTO.Gallary;
using PVK.EFCore.Data.GallaryScope;
using PVK.Interfaces.Services.Gallary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVK.Application.Services.Gallary
{
    public class GallaryProcessor : IGallaryProcessor
    {
        private GallaryContext _gallaryContext;

        public GallaryProcessor(GallaryContext gallaryContext)
        {
            this._gallaryContext = gallaryContext;
        }
        public async Task<GallaryResponse> AddNewGallary(AddGallaryData addGallaryData)
        {
            GallaryResponse response = new GallaryResponse();
            try
            {
                var gallaryname = _gallaryContext.TblGallaries.Where(x => x.Name == addGallaryData.Name).FirstOrDefault();
                if(gallaryname == null)
                {
                    var gallary = new TblGallary()
                    {
                        GuidGallaryId=Guid.NewGuid().ToString(),
                        Name=addGallaryData.Name,
                        Date_Inactive=null,
                        Date_Created=DateTime.Now,
                        Uid_Created=addGallaryData.UserId
                    };

                    await _gallaryContext.TblGallaries.AddAsync(gallary);
                    var result = await _gallaryContext.SaveChangesAsync();
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

        public async Task<GallaryResponse> GetAllGallaryList()
        {
            GallaryResponse response = new GallaryResponse();
            try
            {
                var result = await _gallaryContext.TblGallaries.Where(x => x.Date_Inactive == null).ToListAsync();

                if(result!= null)
                {
                    foreach(var item in result)
                    {
                        GallaryData data = new GallaryData();
                        data.GuidGallaryId = item.GuidGallaryId;
                        data.Name = item.Name;
                        data.UserId = item.Uid_Created;

                        response.gallaryDatas.Add(data);
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

        public async Task<GallaryResponse> RemoveGallary(DeleteGallary tblgallary)
        {
            GallaryResponse response = new GallaryResponse();
            try
            {
                var resultgallary = _gallaryContext.TblGallaries.Where(x => x.GuidGallaryId == tblgallary.GuidGallaryId).FirstOrDefault();
                if(resultgallary != null)
                {
                    resultgallary.Date_Inactive = DateTime.Now;
                    resultgallary.Uid_Modified = tblgallary.UserId;

                    _gallaryContext.TblGallaries.Update(resultgallary);
                    var result = await _gallaryContext.SaveChangesAsync();
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
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;

                return response;
            }
        }

        public async Task<GallaryResponse> UpdateGallary(UpdateGallary tblgallary)
        {
            GallaryResponse response = new GallaryResponse();
            try
            {
                var gallary = new TblGallary()
                {
                    GuidGallaryId=tblgallary.GuidGallaryId,
                    Name=tblgallary.Name,
                    Date_Modified=DateTime.Now,
                    Uid_Modified=tblgallary.UserId
                };

                _gallaryContext.TblGallaries.Update(gallary);
                var result = await _gallaryContext.SaveChangesAsync();
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
