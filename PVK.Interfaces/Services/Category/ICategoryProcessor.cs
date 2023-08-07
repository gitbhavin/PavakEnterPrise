using PVK.DTO.Category;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PVK.Interfaces.Services.Category
{
    public interface ICategoryProcessor
    {
        Task<CategoryResponse> GetAllCategory();

        Task<CategoryResponse> AddNewCategory(Addnewcategory addnewcategory);

        Task<CategoryResponse> DeleteCategory(DeleteCategory deleteCategory);

        Task<CategoryResponse> UpdateCategory(UpdateCategory updateCategory);

        Task<CategoryResponse> GetCategoryById(string Guid_CategoryId);

        Task<CategoryResponse> GetSubCategoryById(string Guid_CategoryId);
    }
}
