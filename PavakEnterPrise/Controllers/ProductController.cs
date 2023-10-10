using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PVK.DTO.Product;
using PVK.Interfaces.Services.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PVK.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;
        public ProductController(IProductService productService)
        {
            this._service = productService;
        }

        [HttpPost("Addnewproduct")]
        public async Task<ProductResponse> Addnewproduct(Addnewproduct addnewproduct)
        {
            return await _service.Addnewproduct(addnewproduct);
        }
        [HttpPost("Deleteproduct")]
        public async Task<ProductResponse> Deleteproduct(Deleteproduct deleteproduct)
        {
            return await _service.Deleteproduct(deleteproduct);
        }
        [HttpPost("Updateproduct")]
        public async Task<ProductResponse> Updateproduct(Updateproduct updateproduct)
        {
            return await _service.Updateproduct(updateproduct);
        }
        [HttpGet("GetAllProduct")]
        public async Task<ProductResponse> GetAllProduct()
        {
            return await _service.Getallproduct();
        }
        [HttpPost("GetProductbyId")]
        public async Task<ProductResponse> getproductbyproductid(string Guid_Productid)
        {
            return await _service.GetproductbyId(Guid_Productid);
        }


        [HttpPost("GetProductbyCategoryId")]
        public async Task<ProductResponse> GetProductbyCategoryId(string Guid_CategoryId)
        {
            return await _service.GetProductbyCategoryId(Guid_CategoryId);
        }

        [HttpPost("GetProductbysubCategoryId")]
        public async Task<ProductResponse> GetProductbysubCategoryId(string Guid_SubCategoryId)
        {
            return await _service.GetProductbysubCategoryId(Guid_SubCategoryId);
        }

        [HttpPost("UploadproductImage")]
        public async Task<ProductResponse> uploadproductimage(IFormFile file, string guidproductid)
        {
            return await _service.UploadImage(file, guidproductid);
        }
    }
}
