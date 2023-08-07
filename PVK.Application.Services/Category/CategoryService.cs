using PVK.DTO.Category;
using PVK.Interfaces.Services.Category;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PVK.Application.Services.Category
{
    public class CategoryService : ICategoryService
    {

        private readonly ICategoryProcessor _categoryProcessor;
        public CategoryService(ICategoryProcessor categoryProcessor)
        {
            this._categoryProcessor = categoryProcessor;

        }
        public async Task<CategoryResponse> AddNewCategory(Addnewcategory addnewcategory)
        {
            return await _categoryProcessor.AddNewCategory(addnewcategory);
            
        }

        public async Task<CategoryResponse> DeleteCategory(DeleteCategory deleteCategory)
        {
            return await _categoryProcessor.DeleteCategory(deleteCategory);
        }

        public async Task<CategoryResponse> GetAllCategory()
        {
            return await _categoryProcessor.GetAllCategory();
        }

        public async Task<CategoryResponse> GetCategoryById(string Guid_CategoryId)
        {
            return await _categoryProcessor.GetCategoryById(Guid_CategoryId);
        }

        public async Task<CategoryResponse> GetSubCategoryById(string Guid_CategoryId)
        {
            return await _categoryProcessor.GetSubCategoryById(Guid_CategoryId);
        }

        public async Task<CategoryResponse> UpdateCategory(UpdateCategory updateCategory)
        {
            return await _categoryProcessor.UpdateCategory(updateCategory);
        }
    }
}
