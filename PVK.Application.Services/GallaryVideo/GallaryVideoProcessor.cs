using Microsoft.EntityFrameworkCore;
using PVK.DTO.GallaryVideo;
using PVK.EFCore.Data.GallaryVideoScope;
using PVK.Interfaces.Services.GallaryVideo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVK.Application.Services.GallaryVideo
{
    public class GallaryVideoProcessor: IGallaryVideoProcessor
    {
        private GallaryVideoContext _gallaryVideoContext;

        public GallaryVideoProcessor(GallaryVideoContext gallaryVideoContext)
        {
            this._gallaryVideoContext = gallaryVideoContext;
        }

        public async Task<GallaryVideoResponse> AddNewGallaryVideo(AddGallaryVideoData addGallaryVideoData)
        {
            GallaryVideoResponse response = new GallaryVideoResponse();

            try
            {
                var gallaryvideoname =await _gallaryVideoContext.TblGallaryVideos.Where(x => x.videourl == addGallaryVideoData.videourl).ToListAsync();
                if (gallaryvideoname.Count == 0)
                {
                    var gallaryvideo = new TblGallaryVideo()
                    {
                        GuidGallaryvideoid = Guid.NewGuid().ToString(),
                        GuidGallaryid=addGallaryVideoData.GuidGallaryid,
                        videourl=addGallaryVideoData.videourl,
                        IsPrimery=addGallaryVideoData.IsPrimery,
                        Date_Inactive=null,
                        Date_Created=DateTime.Now,
                        Uid_Created=addGallaryVideoData.UserId
                    };

                    await _gallaryVideoContext.TblGallaryVideos.AddAsync(gallaryvideo);
                    var result = await _gallaryVideoContext.SaveChangesAsync();
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

            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;

                return response;
            }
        }

        public async Task<GallaryVideoResponse> GetAllGallaryVideoList()
        {
            GallaryVideoResponse response = new GallaryVideoResponse();
            try
            {
                var result = await _gallaryVideoContext.TblGallaryVideos.Where(e => e.Date_Inactive == null).ToListAsync();
                if(result != null)
                {
                    foreach(var item in result)
                    {
                        GallaryVideoData data = new GallaryVideoData();
                        data.GuidGallaryvideoid = item.GuidGallaryvideoid;
                        data.GuidGallaryid = item.GuidGallaryid;
                        data.UserId = item.Uid_Created;
                        data.videourl = item.videourl;
                        data.IsPrimery = item.IsPrimery;

                        response.gallaryVideoDatas.Add(data);
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

        public async Task<GallaryVideoResponse> RemoveGallaryVideo(DeleteGallaryVideo tblGallaryvideo)
        {
            
            GallaryVideoResponse response = new GallaryVideoResponse();
            try
            {
                var resultvideo =  _gallaryVideoContext.TblGallaryVideos.Where(x => x.GuidGallaryvideoid == tblGallaryvideo.GuidGallaryvideoid).FirstOrDefault();
                if(resultvideo != null)
                {

                         resultvideo.Date_Inactive = DateTime.Now;
                         resultvideo.Uid_Modified = tblGallaryvideo.UserId;

                         _gallaryVideoContext.TblGallaryVideos.Update(resultvideo);
                        var result = await _gallaryVideoContext.SaveChangesAsync();
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

        public async Task<GallaryVideoResponse> UpdateGallaryVideo(UpdateGallaryVideo tblGallaryvideo)
        {
            GallaryVideoResponse response = new GallaryVideoResponse();
            try
            {
                var gallaryvideo = new TblGallaryVideo()
                {
                    GuidGallaryvideoid=tblGallaryvideo.GuidGallaryvideoid,
                    GuidGallaryid=tblGallaryvideo.GuidGallaryid,
                    videourl=tblGallaryvideo.videourl,
                    IsPrimery=tblGallaryvideo.IsPrimery,
                    Uid_Modified=tblGallaryvideo.UserId,
                    Date_Modified=DateTime.Now

                };
                _gallaryVideoContext.Update(gallaryvideo);
                var result = await _gallaryVideoContext.SaveChangesAsync();
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
