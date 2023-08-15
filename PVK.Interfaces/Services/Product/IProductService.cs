using Microsoft.AspNetCore.Http;
using PVK.DTO.Product;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PVK.Interfaces.Services.Product
{
    public interface IProductService
    {
        Task<ProductResponse> Getallproduct();

        Task<ProductResponse> Addnewproduct(Addnewproduct addnewproduct);

        Task<ProductResponse> Deleteproduct(Deleteproduct deleteproduct);

        Task<ProductResponse> Updateproduct(Updateproduct updateproduct);

        Task<ProductResponse> GetproductbyId(string Guid_productId);

        Task<ProductResponse> GetProductbyCategoryId(string Guid_CategoryId);
        Task<ProductResponse> GetProductbysubCategoryId(string Guid_SubCategoryId);

        Task<ProductResponse> UploadImage(IFormFile file, string categoryid);
    }
}
