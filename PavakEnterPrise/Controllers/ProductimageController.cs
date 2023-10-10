using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PVK.DTO.ProductImage;
using PVK.Interfaces.Services.ProductImage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PVK.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductimageController : ControllerBase
    {
        private readonly IProductimageService _service;

        public ProductimageController(IProductimageService service)
        {
            this._service = service;
        }

        [HttpPost("Addproductimage")]
        public async Task<ProdcutimageResponse> Addproductimage(IFormFile file,string productguid_id)
        {
            return await _service.AddProductimages(file, productguid_id);
        }
        [HttpPost("Deleteproductimage")]
        public async Task<ProdcutimageResponse> Deleteproductimage(Deleteproductimage deleteproductimage)
        {
            return await _service.deleteproductimage(deleteproductimage);
        }
        [HttpPost("Updateproductimage")]
        public async Task<ProdcutimageResponse> Updateproductimage(IFormFile file, Updateproductimage updateproductimage)
        {
            return await _service.UploadProductimages(file, updateproductimage);
        }

        [HttpPost("GetallImagesbyProductId")]
        public async Task<ProdcutimageResponse> GetallImagesbyProductId(string guidproductid)
        {
            return await _service.GetallImagesbyProductId(guidproductid);
        }
    }
}
