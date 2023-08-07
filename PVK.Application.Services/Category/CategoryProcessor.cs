﻿using Microsoft.EntityFrameworkCore;
using PVK.DTO.Category;
using PVK.EFCore.Data.CategoryScope;
using PVK.Interfaces.Services.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVK.Application.Services.Category
{
    public class CategoryProcessor : ICategoryProcessor
    {
        private readonly CategoryContext _categoryContext;

        public CategoryProcessor(CategoryContext categoryContext)
        {
            this._categoryContext = categoryContext;
        }

        public async Task<CategoryResponse> AddNewCategory(Addnewcategory addnewcategory)
        {
            CategoryResponse response = new CategoryResponse();
            try
            {

                var categoryname = _categoryContext.TblCategories.Where(x => x.CategoryName == addnewcategory.CategoryName && x.Date_Inactive==null).FirstOrDefault();
                if (categoryname == null)
                {

                    var category = new TblCategory()
                    {
                        Guid_CategoryId = Guid.NewGuid().ToString(),
                        CategoryName = addnewcategory.CategoryName,
                        Guid_SubCategoryId=addnewcategory.Guid_SubCategoryId,
                        Guid_SubSubCategoryId=addnewcategory.Guid_SubSubCategoryId,
                        Description=addnewcategory.Description,
                        IsPreorder=addnewcategory.IsPreorder,
                        Date_Inactive = null,

                        Date_Created = DateTime.Now,
                        Uid_Created = addnewcategory.UserId


                    };

                    await _categoryContext.TblCategories.AddAsync(category);
                    var result = await _categoryContext.SaveChangesAsync();
                    if (result > 0)
                    {
                        response.Status = true;
                        response.Message = "data save successfully";


                    }
                    else
                    {
                        response.Status = false;
                        response.Message = "data already added";
                    }
                }
                else
                {
                    response.Status = false;
                    response.Message = "data already added";
                }
                return response;
            }
            catch (Exception ex)
            {

                response.Message = ex.Message;
                response.Status = false;

                return response;
            }
        }

        public async Task<CategoryResponse> DeleteCategory(DeleteCategory deleteCategory)
        {
            CategoryResponse response = new CategoryResponse();
            try
            {
                var category = new TblCategory()
                {
                    Guid_CategoryId = deleteCategory.Guid_CategoryId,
                    Date_Inactive = DateTime.Now,
                    Uid_Modified = deleteCategory.UserId

                };
                _categoryContext.TblCategories.Update(category);
                var result = await _categoryContext.SaveChangesAsync();
                if (result > 0)
                {
                    response.Status = true;
                    response.Message = "category deleted successfully";


                }
                else
                {
                    response.Status = false;
                    response.Message = "data already added";
                }
                return response;

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;

                return response;
            }
        }

        public async Task<CategoryResponse> GetAllCategory()
        {
            CategoryResponse response = new CategoryResponse();

            try
            {
                var result = await _categoryContext.TblCategories.Where(x => x.Date_Inactive == null).ToListAsync();

                if (result != null)
                {
                    foreach (var item in result)
                    {
                        var subcategory=  _categoryContext.TblCategories.Where(a => a.Guid_CategoryId == item.Guid_SubCategoryId).FirstOrDefault();
                        var subsubcategory=  _categoryContext.TblCategories.Where(a => a.Guid_CategoryId == item.Guid_SubSubCategoryId).FirstOrDefault();

                        CategoryData data = new CategoryData();
                        data.Guid_CategoryId = item.Guid_CategoryId;
                        data.CategoryName = item.CategoryName;
                        data.Description = item.Description;
                        data.CategoryImg = item.CategoryImg;
                        data.IsPreorder = item.IsPreorder;
                        data.Guid_SubCategoryId = item.Guid_SubCategoryId;
                        data.Guid_SubSubCategoryId = item.Guid_SubSubCategoryId;
                        if(subcategory != null)
                        data.Category = subcategory.CategoryName;
                        if (subsubcategory!=null)
                            data.SubCategory = subsubcategory.CategoryName;

                        response.categoryDatas.Add(data);
                    }
                    response.Message = "Success!";
                    response.Status = true;
                }
                else
                {
                    response.Message = "No Record Found!";
                    response.Status = true;
                }
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;

                return response;
            }
        }

        public async Task<CategoryResponse> GetCategoryById(string Guid_CategoryId)
        {
            CategoryResponse response = new CategoryResponse();

            try
            {
                var result = await _categoryContext.TblCategories.Where(x => x.Date_Inactive == null && x.Guid_CategoryId == Guid_CategoryId).ToListAsync();

                if (result != null)
                {
                    foreach (var item in result)
                    {
                        var subcategory = _categoryContext.TblCategories.Where(a => a.Guid_CategoryId == item.Guid_SubCategoryId).FirstOrDefault();
                        var subsubcategory = _categoryContext.TblCategories.Where(a => a.Guid_CategoryId == item.Guid_SubSubCategoryId).FirstOrDefault();

                        CategoryData data = new CategoryData();
                        data.Guid_CategoryId = item.Guid_CategoryId;
                        data.CategoryName = item.CategoryName;
                        data.Description = item.Description;
                        data.CategoryImg = item.CategoryImg;
                        data.IsPreorder = item.IsPreorder;
                        data.Guid_SubCategoryId = item.Guid_SubCategoryId;
                        data.Guid_SubSubCategoryId = item.Guid_SubSubCategoryId;
                        if (subcategory != null)
                            data.Category = subcategory.CategoryName;
                        if (subsubcategory != null)
                            data.SubCategory = subsubcategory.CategoryName;
                        response.categoryDatas.Add(data);
                    }
                    response.Message = "Success!";
                    response.Status = true;
                }
                else
                {
                    response.Message = "No Record Found!";
                    response.Status = true;
                }
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;

                return response;
            }
        }

        public async Task<CategoryResponse> GetSubCategoryById(string Guid_CategoryId)
        {
            CategoryResponse response = new CategoryResponse();

            try
            {
                var result = await _categoryContext.TblCategories.Where(x => x.Date_Inactive == null && (string.IsNullOrEmpty(x.Guid_SubSubCategoryId)) && x.Guid_SubCategoryId == Guid_CategoryId).ToListAsync();

                if (result != null)
                {
                    foreach (var item in result)
                    {
                       
                        CategoryData data = new CategoryData();
                        data.Guid_CategoryId = item.Guid_CategoryId;
                        data.CategoryName = item.CategoryName;
                        data.Description = item.Description;
                        data.CategoryImg = item.CategoryImg;
                        data.IsPreorder = item.IsPreorder;
                        data.Guid_SubCategoryId = item.Guid_SubCategoryId;
                        data.Guid_SubSubCategoryId = item.Guid_SubSubCategoryId;
                       
                        response.categoryDatas.Add(data);
                    }
                    response.Message = "Success!";
                    response.Status = true;
                }
                else
                {
                    response.Message = "No Record Found!";
                    response.Status = true;
                }
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;

                return response;
            }
        }

        public async Task<CategoryResponse> UpdateCategory(UpdateCategory updateCategory)
        {
            CategoryResponse response = new CategoryResponse();
            try
            {
                var category = new TblCategory()
                {
                    Guid_CategoryId = updateCategory.Guid_CategoryId,
                   Guid_SubCategoryId=updateCategory.Guid_SubCategoryId,
                   Guid_SubSubCategoryId=updateCategory.Guid_SubSubCategoryId,
                   CategoryName=updateCategory.CategoryName,
                   Description=updateCategory.Description,
                    Date_Modified = DateTime.Now,
                    Uid_Modified = updateCategory.UserId
                };

                _categoryContext.TblCategories.Update(category);
                var result = await _categoryContext.SaveChangesAsync();
                if (result > 0)
                {
                    response.Status = true;
                    response.Message = "data updated successfully";


                }
                return response;
            }
            catch (Exception ex)
            {

                response.Message = ex.Message;
                response.Status = false;

                return response;
            }
        }
    }
}
