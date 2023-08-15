using Microsoft.EntityFrameworkCore;
using PVK.DTO.Banner;
using PVK.EFCore.Data.BannerScope;
using PVK.Interfaces.Services.Banner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVK.Application.Services.Banner
{
    public class BannerProcessor : IBannerProcessor
    {
        private readonly BannerContext _bannerContext;

        public BannerProcessor(BannerContext bannerContext)
        {
            this._bannerContext = bannerContext;
        }
        public async Task<BannerResponse> AddnewBanner(Addbanner addbanner)
        {
            BannerResponse response = new BannerResponse();
            try
            {

               
                    var banner = new TblBanner()
                    {
                        Guid_BannerId = Guid.NewGuid().ToString(),
                        PageName = addbanner.PageName,
                        SectionName=addbanner.SectionName,
                        Order_Sequence=addbanner.Order_Sequence,
                        Date_Inactive = null,
                        Date_Created = DateTime.Now,
                        Uid_Created = addbanner.UserId


                    };

                    await _bannerContext.TblBanners.AddAsync(banner);
                    var result = await _bannerContext.SaveChangesAsync();
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

        public async Task<BannerResponse> GetAllBanners()
        {
            BannerResponse response = new BannerResponse();

            try
            {
                var result = await _bannerContext.TblBanners.Where(x => x.Date_Inactive == null).OrderByDescending(a => a.Date_Created).ToListAsync();

                if (result != null)
                {
                    foreach (var item in result)
                    {
                        BannerData data = new BannerData();
                        data.Guid_BannerId = item.Guid_BannerId;
                        data.PageName = item.PageName;
                        data.SectionName = item.SectionName;
                        data.Order_Sequence = item.Order_Sequence;

                        response.bannerDatas.Add(data);
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

        public async Task<BannerResponse> GetBannerbyId(string GuidBannerId)
        {
            BannerResponse response = new BannerResponse();

            try
            {
                var result = await _bannerContext.TblBanners.Where(x => x.Date_Inactive == null && x.Guid_BannerId==GuidBannerId).OrderByDescending(a => a.Date_Created).ToListAsync();

                if (result != null)
                {
                    foreach (var item in result)
                    {
                        BannerData data = new BannerData();
                        data.Guid_BannerId = item.Guid_BannerId;
                        data.PageName = item.PageName;
                        data.SectionName = item.SectionName;
                        data.Order_Sequence = item.Order_Sequence;

                        response.bannerDatas.Add(data);
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

        public async Task<BannerResponse> RemoveBanner(Deletebanner deletebanner)
        {
            BannerResponse response = new BannerResponse();
            try
            {

                var review = _bannerContext.TblBanners.Where(x => x.Guid_BannerId == deletebanner.Guid_BannerId).FirstOrDefault();

                if (review != null)
                {




                    review.Date_Inactive = DateTime.Now;
                    review.Uid_Modified = deletebanner.UserId;


                    _bannerContext.TblBanners.Update(review);
                    var result = await _bannerContext.SaveChangesAsync();
                    if (result > 0)
                    {
                        response.Status = true;
                        response.Message = "banner deleted successfully";


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

        public async Task<BannerResponse> UpdateBanner(Updatebanner updatebanner)
        {
            BannerResponse response = new BannerResponse();
            try
            {

                var banner = new TblBanner()
                {
                    Guid_BannerId = updatebanner.Guid_BannerId,
                    PageName = updatebanner.PageName,
                    SectionName = updatebanner.SectionName,
                    Order_Sequence = updatebanner.Order_Sequence,                   
                    Date_Modified = DateTime.Now,
                    Uid_Modified = updatebanner.UserId


                };
               

                _bannerContext.TblBanners.Update(banner);
                var result = await _bannerContext.SaveChangesAsync();
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
