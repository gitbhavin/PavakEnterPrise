using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PVK.DTO.Gallary;
using PVK.EFCore.Data.GallaryScope;
using PVK.Interfaces.Services.Gallary;
using PVK.QueryHandlers.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVK.Application.Services.Gallary
{
    
    public class GallaryProcessor : IGallaryProcessor
    {
        private GallaryContext _gallaryContext;
        private ImageSettings _imageSettings;

        public GallaryProcessor(GallaryContext gallaryContext, IOptions<ImageSettings> imageSettings)
        {
            this._gallaryContext = gallaryContext;
            this._imageSettings = imageSettings.Value;
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

        public async Task<GallaryResponse> GetGallaryById(string GuidGallaryId)
        {
            GallaryResponse response = new GallaryResponse();
            try
            {
                var result = await _gallaryContext.TblGallaries.Where(x => x.Date_Inactive == null && x.GuidGallaryId == GuidGallaryId).ToListAsync();
                if(result != null)
                {
                    foreach(var item in result)
                    {
                        var gallary = _gallaryContext.TblGallaries.Where(a => a.GuidGallaryId == item.GuidGallaryId).FirstOrDefault();
                        var name = _gallaryContext.TblGallaries.Where(a => a.Name == item.Name).FirstOrDefault();

                        GallaryData data = new GallaryData();
                        data.GuidGallaryId = item.GuidGallaryId;
                        data.Name = item.Name;

                        if (name != null)
                            data.Name = name.Name;

                        response.gallaryDatas.Add(data);
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

        //Remove Gallary Data
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
                var resultgallary = _gallaryContext.TblGallaries.Where(x => x.GuidGallaryId == tblgallary.GuidGallaryId).FirstOrDefault();
                if (resultgallary != null)
                {

                    resultgallary.GuidGallaryId = tblgallary.GuidGallaryId;
                    resultgallary.Name = tblgallary.Name;
                    resultgallary.Date_Modified = DateTime.Now;
                    resultgallary.Uid_Modified = tblgallary.UserId;
                    

                    _gallaryContext.TblGallaries.Update(resultgallary);
                    var result = await _gallaryContext.SaveChangesAsync();
                    if (result > 0)
                    {
                        response.Status = true;
                        response.Message = "Data Updated Successfully";
                    }
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

        public async Task<GallaryResponse> UploadImage(IFormFile file, string GuidGallaryId, bool IsPrimary)
        {
            GallaryResponse response = new GallaryResponse();

            try
            {

                if (file == null || file.Length == 0)
                {
                    response.Status = false;
                    response.Message = "";
                    return response;
                }

                string uploadsFolder = Path.Combine(_imageSettings.ImageFolderPath);
                string uniqueFileName = RandomNumber(1000, 50000) + "_" + file.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }

                var gallaryimage = new TblGallary()
                {
                    GuidGallaryId = Guid.NewGuid().ToString(),
                    Name = uniqueFileName,
                    Date_Inactive = null,
                    Date_Created = DateTime.Now,
           
                };

                await _gallaryContext.TblGallaries.AddAsync(gallaryimage);
                var result = await _gallaryContext.SaveChangesAsync();
                if (result > 0)
                {
                    response.Status = true;
                    response.Message = "Image uploaded successfully.";
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
                response.Status = false;
                response.Message = ex.ToString();
            }
            return response;

        }

        public int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
    }
}
