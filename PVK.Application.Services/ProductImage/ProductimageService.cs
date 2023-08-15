using Microsoft.AspNetCore.Http;
using PVK.DTO.ProductImage;
using PVK.Interfaces.Services.ProductImage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PVK.Application.Services.ProductImage
{
    public class ProductimageService : IProductimageService
    {
        private readonly IProductimageProcessor _productimageProcessor;

        public ProductimageService(IProductimageProcessor productimageProcessor)
        {
            this._productimageProcessor = productimageProcessor;
        }
        public async Task<ProdcutimageResponse> AddProductimages(IFormFile file, Addproductimage addproductimage)
        {
            return await _productimageProcessor.AddProductimages(file, addproductimage);
        }

        public async Task<ProdcutimageResponse> deleteproductimage(Deleteproductimage deleteproductimage)
        {
            return await _productimageProcessor.deleteproductimage(deleteproductimage);
        }

        public async Task<ProdcutimageResponse> GetallImagesbyProductId(string guidProductId)
        {
            return await _productimageProcessor.GetallImagesbyProductId(guidProductId);
        }

        public Task<ProdcutimageResponse> UploadProductimages(IFormFile file, Updateproductimage updateproductimage)
        {
            throw new NotImplementedException();
        }
    }
}
