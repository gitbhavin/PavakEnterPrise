using Microsoft.AspNetCore.Http;
using PVK.DTO.ProductImage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PVK.Interfaces.Services.ProductImage
{
    public interface IProductimageService
    {
        Task<ProdcutimageResponse> AddProductimages(IFormFile file,  string productguid_id);

        Task<ProdcutimageResponse> UploadProductimages(IFormFile file, Updateproductimage updateproductimage);

        Task<ProdcutimageResponse> deleteproductimage(Deleteproductimage guidProductimageid);

        Task<ProdcutimageResponse> GetallImagesbyProductId(string guidProductId);

    }
}
