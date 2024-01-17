using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PVK.DTO.GallaryImage;
using PVK.EFCore.Data.GallaryImageScope;
using PVK.EFCore.Data.GallaryScope;
using PVK.Interfaces.Services.GallaryImage;
using PVK.QueryHandlers.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVK.Application.Services.GallaryImage
{
    public class GallaryImageProcessor : IGallaryImageProcessor
    {
        private GallaryImageContext _gallaryImageContext;
        private ImageSettings _imageSettings;
        private GallaryContext _gallarContext;
        private readonly BlobServiceClient _blobServiceClient;
        public GallaryImageProcessor(GallaryImageContext gallaryImageContext, GallaryContext gallaryContext, IOptions<ImageSettings> imageSettings, BlobServiceClient blobServiceClient)
        {
            this._gallaryImageContext = gallaryImageContext;
            this._gallarContext = gallaryContext;
            this._imageSettings = imageSettings.Value;
            this._blobServiceClient = blobServiceClient;
        }

        public async Task<GallaryImageResponse> AddNewGallaryImage(IFormFile file, string guidGallaryId)
        {
            GallaryImageResponse response = new GallaryImageResponse();
            try
            {
                if(file == null || file.Length == 0)
                {
                    response.Status = false;
                    response.Message = "";
                    return response;
                }
                //string uploadsFolder = Path.Combine(_imageSettings.ImageFolderPath);
                string uniqueFileName =  file.FileName;
              //  string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                var containerinstant = _blobServiceClient.GetBlobContainerClient("gallaryimage");

                var blobinstant = containerinstant.GetBlobClient(file.FileName);

                await blobinstant.UploadAsync(file.OpenReadStream());

                var gallaryImage = new TblGallaryImage()
                {
                    GuidGallaryimageid = Guid.NewGuid().ToString(),
                    GuidGallaryid=guidGallaryId,
                   IsPrimery=false,
                    ImageUrl=uniqueFileName,
                    Date_Inactive=null,
                  //  Uid_Created=addGallaryImageData.UserId,
                    Date_Created=DateTime.Now
                };

                await _gallaryImageContext.TblGallaryImages.AddAsync(gallaryImage);
                var result = await _gallaryImageContext.SaveChangesAsync();
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

        public async Task<GallaryImageResponse> GetAllImagebyGallaryId(string giudGallaryId)
        {
            GallaryImageResponse response = new GallaryImageResponse();
            try
            {
                var result = await _gallaryImageContext.TblGallaryImages.Where(x => x.Date_Inactive == null && x.GuidGallaryid == giudGallaryId).ToListAsync();
                if(result != null)
                {                  
                   

                    foreach (var item in result)
                    {                      

                        var gallary_tbl = _gallarContext.TblGallaries.Where(x => x.GuidGallaryId == item.GuidGallaryid).FirstOrDefault();

                        GallaryImageData data = new GallaryImageData();
                        data.GuidGallaryimageid = item.GuidGallaryimageid;
                        data.GuidGallaryid = item.GuidGallaryid;
                        data.IsPrimery = item.IsPrimery;
                        data.ImageUrl = item.ImageUrl;

                        if(gallary_tbl != null)
                        {
                            data.Name = gallary_tbl.Name;
                            response.gallaryImageDatas.Add(data);
                        }
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

        public async Task<GallaryImageResponse> RemoveGallaryImage(DeleteGallaryImage tblgallaryimage)
        {
            GallaryImageResponse response = new GallaryImageResponse();
            try
            {
                var gallaryImage = _gallaryImageContext.TblGallaryImages.Where(x => x.GuidGallaryimageid == tblgallaryimage.GuidGallaryimageid).FirstOrDefault();
                if(gallaryImage != null)
                {
                    gallaryImage.Date_Inactive = DateTime.Now;
                    gallaryImage.Uid_Modified = tblgallaryimage.UserId;

                    _gallaryImageContext.TblGallaryImages.Update(gallaryImage);
                    var result = await _gallaryImageContext.SaveChangesAsync();
                    if (result > 0)
                    {
                        response.Status = true;
                        response.Message = "deleted successfully";


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

       


        public Task<GallaryImageResponse> UpdateGallaryImage(IFormFile file, UpdateGallaryImage updateGallaryImage)
        {
            throw new NotImplementedException();
        }


        public int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
    }
}
