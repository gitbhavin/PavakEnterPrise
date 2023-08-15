using PVK.DTO.Banner;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PVK.Interfaces.Services.Banner
{
   public interface IBannerService
    {
        Task<BannerResponse> GetAllBanners();

        Task<BannerResponse> AddnewBanner(Addbanner addbanner);

        Task<BannerResponse> RemoveBanner(Deletebanner deletebanner);

        Task<BannerResponse> UpdateBanner(Updatebanner updatebanner);

        Task<BannerResponse> GetBannerbyId(string GuidBrandId);
    }
}
