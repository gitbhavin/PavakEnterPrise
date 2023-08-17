using PVK.DTO.Banner;
using PVK.Interfaces.Services.Banner;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PVK.Application.Services.Banner
{
    public class BannerService : IBannerService
    {
        private IBannerProcessor _bannerProcessor;
        public BannerService(IBannerProcessor bannerProcessor)
        {
            this._bannerProcessor = bannerProcessor;
        }
        public async Task<BannerResponse> AddnewBanner(Addbanner addbanner)
        {
            return await _bannerProcessor.AddnewBanner(addbanner);
        }

        public async Task<BannerResponse> GetAllBanners()
        {
            return await _bannerProcessor.GetAllBanners();
        }

        public async Task<BannerResponse> GetBannerbyId(string GuidBrandId)
        {
            return await _bannerProcessor.GetBannerbyId(GuidBrandId);
        }

        public Task<BannerResponse> RemoveBanner(Deletebanner deletebanner)
        {
            throw new NotImplementedException();
        }

        public async Task<BannerResponse> UpdateBanner(Updatebanner updatebanner)
        {
            return await _bannerProcessor.UpdateBanner(updatebanner);
        }
    }
}
