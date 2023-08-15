using Microsoft.AspNetCore.Http;
using PVK.DTO.ProductImage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PVK.Interfaces.Services.ProductImage
{
   public interface IProductimageProcessor
    {
        Task<ProdcutimageResponse> AddProductimages(IFormFile file, Addproductimage addproductimage);

        Task<ProdcutimageResponse> UploadProductimages(IFormFile file, Updateproductimage updateproductimage);

        Task<ProdcutimageResponse> deleteproductimage(Deleteproductimage guidProductimageid);

        Task<ProdcutimageResponse> GetallImagesbyProductId(string guidProductId);
    }
}
