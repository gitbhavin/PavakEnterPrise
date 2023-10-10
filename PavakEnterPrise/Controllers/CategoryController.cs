using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PVK.DTO.Category;
using PVK.Interfaces.Services.Category;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PVK.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ICategoryService _service;
        public CategoryController(ICategoryService CategoryServices)
        {
            this._service = CategoryServices;
        }
        [HttpGet("GetAllCategory")]
        public async Task<CategoryResponse> GetAllBrands()
        {
            return await _service.GetAllCategory();
        }

        [HttpPost("AddNewCategory")]
        public async Task<CategoryResponse> Addnewcategory(Addnewcategory addnewcategory)
        {
            return await _service.AddNewCategory(addnewcategory);
        }
        [HttpPost("DeleteCategory")]
        public async Task<CategoryResponse> DeleteCategory(DeleteCategory deleteCategory)
        {
            return await _service.DeleteCategory(deleteCategory);
        }
        [HttpPost("UpdateCategory")]
        public async Task<CategoryResponse> UpdateCategory(UpdateCategory updateCategory)
        {
            return await _service.UpdateCategory(updateCategory);
        }

        [HttpPost("GetCategorybyId")]
        public async Task<CategoryResponse> GetCategorybyId(string guidcategoryid)
        {
            return await _service.GetCategoryById(guidcategoryid);
        }

        [HttpGet("categorylist")]
        public async Task<CategoryResponse> getcategorylist()
        {
            return await _service.categorylist();
        }

        [HttpPost("Getsubcategorylist")]
        public async Task<CategoryResponse> Getsubcategorylist(string guidcategoryid)
        {
            return await _service.GetSubCategoryById(guidcategoryid);
        }
        [HttpPost("UploadcategoryImage")]
        public async Task<CategoryResponse> uploadcategoryimage(IFormFile file, string categoryid)
        {
            return await _service.UploadImage(file, categoryid);
        }
        [HttpGet("categorylistformenu")]
        public async Task<CategoryResponse> categorylistformenu()
        {
            return await _service.categorylistformenu();
        }

    }
}
