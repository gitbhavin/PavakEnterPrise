using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PVK.DTO.BannerImage;
using PVK.EFCore.Data.BannerImagescope;
using PVK.EFCore.Data.BannerScope;
using PVK.Interfaces.Services.BannerImage;
using PVK.QueryHandlers.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVK.Application.Services.BannerImage
{
    public class BannerImageProcessor : IBannerImageProcessor
    {
        private readonly BannerImageContext _bannerImageContext;
        private readonly BannerContext _bannerContext;
        private readonly ImageSettings _imageSettings;
        private readonly BlobServiceClient _blobServiceClient;
        public BannerImageProcessor(BannerImageContext bannerImageContext, BannerContext bannerContext, IOptions<ImageSettings> imageSettings, BlobServiceClient blobServiceClient)
        {
            this._bannerImageContext = bannerImageContext;
            this._imageSettings = imageSettings.Value;
            this._bannerContext = bannerContext;
            this._blobServiceClient = blobServiceClient;
        }
        public async Task<BannerimageResponse> addbannerimage(IFormFile file, AddBannerimage addBannerimage)
        {
            BannerimageResponse response = new BannerimageResponse();
            try
            {

                if (file == null || file.Length == 0)
                {
                    response.Status = false;
                    response.Message = "";
                    return response;
                }

               
                string uniqueFileName = file.FileName;
             
                var containerinstant = _blobServiceClient.GetBlobContainerClient("bannerimages");

                var blobinstant = containerinstant.GetBlobClient(file.FileName);

                await blobinstant.UploadAsync(file.OpenReadStream());


                var bannerimage = new TblBannerImage()
                {
                    Guid_BannerImageId = Guid.NewGuid().ToString(),
                    Guid_BannerId = addBannerimage.Guid_BannerId,                   
                    Image_Url = uniqueFileName,
                    Date_Inactive = null,
                    Date_Created = DateTime.Now,
                    Uid_Created = addBannerimage.UserId
                };

                await _bannerImageContext.TblBannerImages.AddAsync(bannerimage);
                var result = await _bannerImageContext.SaveChangesAsync();
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

        public async Task<BannerimageResponse> deletebannerimage(Deletebannerimage deletebannerimage)
        {
            BannerimageResponse response = new BannerimageResponse();
            try
            {

                var bannerimage = _bannerImageContext.TblBannerImages.Where(x => x.Guid_BannerImageId == deletebannerimage.Guid_BannerImageId).FirstOrDefault();

                if (bannerimage != null)
                {




                    bannerimage.Date_Inactive = DateTime.Now;
                    bannerimage.Uid_Modified = deletebannerimage.UserId;


                    _bannerImageContext.TblBannerImages.Update(bannerimage);
                    var result = await _bannerImageContext.SaveChangesAsync();
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

        public async Task<BannerimageResponse> Getallbannerimagebybannerid(string guidbannerguid)
        {
            BannerimageResponse response = new BannerimageResponse();

            try
            {
                var result = await _bannerImageContext.TblBannerImages.Where(x => x.Date_Inactive == null && x.Guid_BannerId == guidbannerguid).ToListAsync();

                if (result != null)
                {
                    foreach (var item in result)
                    {
                        var product = _bannerContext.TblBanners.Where(a => a.Guid_BannerId == item.Guid_BannerId).FirstOrDefault();

                        Bannerimagedata data = new Bannerimagedata();
                        data.Guid_BannerImageId = item.Guid_BannerImageId;
                        data.Guid_BannerId = item.Guid_BannerId;                     
                        data.Image_Url = item.Image_Url;

                        //if (product != null)
                        //    data.ProductName = product.ProductName;

                        response.bannerimagedatas.Add(data);
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

        public int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
    }
}
