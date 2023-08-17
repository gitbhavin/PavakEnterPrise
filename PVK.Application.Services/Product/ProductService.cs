using Microsoft.AspNetCore.Http;
using PVK.DTO.Product;
using PVK.Interfaces.Services.Product;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PVK.Application.Services.Product
{
    public class ProductService : IProductService
    {
        private readonly IProductProcessor _productProcessor;

        public ProductService(IProductProcessor productProcessor)
        {
            this._productProcessor = productProcessor;
        }
        public async Task<ProductResponse> Addnewproduct(Addnewproduct addnewproduct)
        {
            return await _productProcessor.Addnewproduct(addnewproduct);
        }

        public async Task<ProductResponse> Deleteproduct(Deleteproduct deleteproduct)
        {
            return await _productProcessor.Deleteproduct(deleteproduct);
        }

        public async Task<ProductResponse> Getallproduct()
        {
            return await _productProcessor.Getallproduct();
        }

        public async Task<ProductResponse> GetProductbyCategoryId(string Guid_CategoryId)
        {
            return await _productProcessor.GetProductbyCategoryId(Guid_CategoryId);
        }

        public async Task<ProductResponse> GetproductbyId(string Guid_productId)
        {
            return await _productProcessor.GetproductbyId(Guid_productId);
        }

        public Task<ProductResponse> GetProductbysubCategoryId(string Guid_SubCategoryId)
        {
            throw new NotImplementedException();
        }

        public async Task<ProductResponse> Updateproduct(Updateproduct updateproduct)
        {
            return await _productProcessor.Updateproduct(updateproduct);
        }

        public async Task<ProductResponse> UploadImage(IFormFile file, string guidproductid)
        {
            return await _productProcessor.UploadImage(file, guidproductid);
        }
    } 
}
