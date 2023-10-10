using Microsoft.AspNetCore.Http;
using PVK.DTO.BannerImage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
namespace PVK.Interfaces.Services.BannerImage
{
    public interface IBannerImageProcessor
    {
        Task<BannerimageResponse> addbannerimage(IFormFile file, AddBannerimage addBannerimage);

        Task<BannerimageResponse> deletebannerimage(Deletebannerimage deletebannerimage);

        Task<BannerimageResponse> Getallbannerimagebybannerid(string guidbannerguid);
    }
}
