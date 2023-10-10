using Microsoft.AspNetCore.Http;
using PVK.DTO.BannerImage;
using PVK.Interfaces.Services.BannerImage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PVK.Application.Services.BannerImage
{
    public class BannerImageservice : IBannerImageService
    {
        public BannerImageProcessor _bannerimageprocessor;
        public async Task<BannerimageResponse> addbannerimage(IFormFile file, AddBannerimage addBannerimage)
        {
            return await _bannerimageprocessor.addbannerimage(file, addBannerimage);
        }

        public async Task<BannerimageResponse> deletebannerimage(Deletebannerimage deletebannerimage)
        {
            return await _bannerimageprocessor.deletebannerimage(deletebannerimage);
        }

        public async Task<BannerimageResponse> Getallbannerimagebybannerid(string guidbannerguid)
        {
            return await _bannerimageprocessor.Getallbannerimagebybannerid(guidbannerguid);
        }
    }
}
