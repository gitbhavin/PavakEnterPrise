using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PVK.DTO.Product;
using PVK.EFCore.Data.BrandScope;
using PVK.EFCore.Data.CategoryScope;
using PVK.EFCore.Data.ProductScope;
using PVK.Interfaces.Services.Product;
using PVK.QueryHandlers.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVK.Application.Services.Product
{
    public class ProductProcessor : IProductProcessor
    {
        private readonly ProductContext _productContext;

        private readonly CategoryContext _categoryContext;
        private readonly ImageSettings _imageSettings;
        private readonly BrandContext _brandContext;

        public ProductProcessor(ProductContext productContext, IOptions<ImageSettings> imageSettings, CategoryContext categoryContext , BrandContext brandContext)
        {
            this._productContext = productContext;
            this._categoryContext = categoryContext;
            this._brandContext = brandContext;
            this._imageSettings = imageSettings.Value;
        }
        public async Task<ProductResponse> Addnewproduct(Addnewproduct addnewproduct)
        {
            ProductResponse response = new ProductResponse();
            try
            {

                var productname = _productContext.TblProducts.Where(x => x.ProductName == addnewproduct.ProductName && x.Date_Inactive == null).FirstOrDefault();
                if (productname == null)
                {
                    var Guid_ProductId = Guid.NewGuid().ToString();
                    var product = new TblProduct()
                    {
                        Guid_ProductId = Guid_ProductId,
                        Guid_CategoryId = addnewproduct.Guid_CategoryId,
                        ProductName = addnewproduct.ProductName,
                        Guid_SubCategoryId = addnewproduct.Guid_SubCategoryId,
                        Guid_SubSubCategoryId = addnewproduct.Guid_SubSubCategoryId,
                        Short_Description = addnewproduct.Short_Description,
                        Is_InSale = addnewproduct.Is_InSale,
                        Guid_BrandId=addnewproduct.Guid_BrandId,
                        Full_Description=addnewproduct.Full_Description,
                        Price=Convert.ToDecimal(addnewproduct.Price),
                        Discount= Convert.ToDecimal(addnewproduct.Discount),
                        Available_Stock= Convert.ToDecimal(addnewproduct.Available_Stock),
                        Thumbnail_Image_Url=addnewproduct.Thumbnail_Image_Url,
                        Date_Inactive = null,

                        Date_Created = DateTime.Now,
                        Uid_Created = addnewproduct.UserId
                    };

                    await _productContext.TblProducts.AddAsync(product);
                    var result = await _productContext.SaveChangesAsync();
                    if (result > 0)
                    {
                        response.guid = Guid_ProductId;
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

        public async Task<ProductResponse> Deleteproduct(Deleteproduct deleteproduct)
        {
            ProductResponse response = new ProductResponse();
            try
            {
                var product = _productContext.TblProducts.Where(x => x.Guid_ProductId == deleteproduct.Guid_ProductId).FirstOrDefault();
                if (product != null)
                {
                    product.Date_Inactive = DateTime.Now;
                    product.Uid_Modified = deleteproduct.UserId;

                    _productContext.TblProducts.Update(product);
                    var result = await _productContext.SaveChangesAsync();
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

        public async Task<ProductResponse> Getallproduct()
        {
            ProductResponse response = new ProductResponse();

            try
            {
                var result = await _productContext.TblProducts.Where(x => x.Date_Inactive == null).ToListAsync();

                if (result != null)
                {
                    foreach (var item in result)
                    {
                        var category = _categoryContext.TblCategories.Where(a => a.Guid_CategoryId == item.Guid_CategoryId).FirstOrDefault();
                        var subcategory = _categoryContext.TblCategories.Where(a => a.Guid_CategoryId == item.Guid_SubCategoryId).FirstOrDefault();
                        var subsubcategory = _categoryContext.TblCategories.Where(a => a.Guid_CategoryId == item.Guid_SubSubCategoryId).FirstOrDefault();
                        var brandname = _brandContext.TblBrands.Where(b => b.GuidBrandId == item.Guid_BrandId).FirstOrDefault();


                        ProductData data = new ProductData();
                        data.Guid_CategoryId = item.Guid_CategoryId;
                        data.ProductName = item.ProductName;
                        data.Short_Description = item.Short_Description;
                        data.Full_Description = item.Full_Description;
                        data.Is_InSale = item.Is_InSale;
                        data.Price = Convert.ToDecimal(item.Price);
                        data.Discount = Convert.ToDecimal(item.Discount);
                        data.Available_Stock = Convert.ToDecimal(item.Available_Stock);
                        data.Guid_BrandId = item.Guid_BrandId;
                        data.Thumbnail_Image_Url = item.Thumbnail_Image_Url;                       

                        data.Guid_SubCategoryId = item.Guid_SubCategoryId;
                        data.Guid_SubSubCategoryId = item.Guid_SubSubCategoryId;
                        if (category != null)
                            data.Category = category.CategoryName;
                        if (subcategory != null)
                            data.SubCategory = subcategory.CategoryName;
                        if (subsubcategory != null)
                            data.SubsubCategory = subsubcategory.CategoryName;
                        if (brandname != null)
                            data.BrandName = brandname.BrandName;                       

                        response.productDatas.Add(data);
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

        public async Task<ProductResponse> GetProductbyCategoryId(string Guid_CategoryId)
        {
            ProductResponse response = new ProductResponse();

            try
            {
                var result = await _productContext.TblProducts.Where(x => x.Date_Inactive == null && x.Guid_CategoryId==Guid_CategoryId).ToListAsync();

                if (result != null)
                {
                    foreach (var item in result)
                    {
                        var category = _categoryContext.TblCategories.Where(a => a.Guid_CategoryId == item.Guid_CategoryId).FirstOrDefault();
                        var subcategory = _categoryContext.TblCategories.Where(a => a.Guid_CategoryId == item.Guid_SubCategoryId).FirstOrDefault();
                        var subsubcategory = _categoryContext.TblCategories.Where(a => a.Guid_CategoryId == item.Guid_SubSubCategoryId).FirstOrDefault();
                        var brandname = _brandContext.TblBrands.Where(b => b.GuidBrandId == item.Guid_BrandId).FirstOrDefault();


                        ProductData data = new ProductData();
                        data.Guid_CategoryId = item.Guid_CategoryId;
                        data.ProductName = item.ProductName;
                        data.Short_Description = item.Short_Description;
                        data.Full_Description = item.Full_Description;
                        data.Is_InSale = item.Is_InSale;
                        data.Price = item.Price;
                        data.Discount = item.Discount;
                        data.Available_Stock = item.Available_Stock;
                        data.Guid_BrandId = item.Guid_BrandId;
                        data.Thumbnail_Image_Url = item.Thumbnail_Image_Url;

                        data.Guid_SubCategoryId = item.Guid_SubCategoryId;
                        data.Guid_SubSubCategoryId = item.Guid_SubSubCategoryId;
                        if (category != null)
                            data.Category = category.CategoryName;
                        if (subcategory != null)
                            data.SubCategory = subcategory.CategoryName;
                        if (subsubcategory != null)
                            data.SubsubCategory = subsubcategory.CategoryName;
                        if (brandname != null)
                            data.BrandName = brandname.BrandName;

                        response.productDatas.Add(data);
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

        public async Task<ProductResponse> GetproductbyId(string Guid_productId)
        {
            ProductResponse response = new ProductResponse();

            try
            {
                var result = await _productContext.TblProducts.Where(x => x.Date_Inactive == null && x.Guid_ProductId==Guid_productId).ToListAsync();

                if (result != null)
                {
                    foreach (var item in result)
                    {
                        var category = _categoryContext.TblCategories.Where(a => a.Guid_CategoryId == item.Guid_CategoryId).FirstOrDefault();
                        var subcategory = _categoryContext.TblCategories.Where(a => a.Guid_CategoryId == item.Guid_SubCategoryId).FirstOrDefault();
                        var subsubcategory = _categoryContext.TblCategories.Where(a => a.Guid_CategoryId == item.Guid_SubSubCategoryId).FirstOrDefault();
                        var brandname = _brandContext.TblBrands.Where(b => b.GuidBrandId == item.Guid_BrandId).FirstOrDefault();


                        ProductData data = new ProductData();
                        data.Guid_CategoryId = item.Guid_CategoryId;
                        data.ProductName = item.ProductName;
                        data.Short_Description = item.Short_Description;
                        data.Full_Description = item.Full_Description;
                        data.Is_InSale = item.Is_InSale;
                        data.Price = item.Price;
                        data.Discount = item.Discount;
                        data.Available_Stock = item.Available_Stock;
                        data.Guid_BrandId = item.Guid_BrandId;
                        data.Thumbnail_Image_Url = item.Thumbnail_Image_Url;

                        data.Guid_SubCategoryId = item.Guid_SubCategoryId;
                        data.Guid_SubSubCategoryId = item.Guid_SubSubCategoryId;
                        if (category != null)
                            data.Category = category.CategoryName;
                        if (subcategory != null)
                            data.SubCategory = subcategory.CategoryName;
                        if (subsubcategory != null)
                            data.SubsubCategory = subsubcategory.CategoryName;
                        if (brandname != null)
                            data.BrandName = brandname.BrandName;

                        response.productDatas.Add(data);
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

        public async Task<ProductResponse> GetProductbysubCategoryId(string Guid_SubCategoryId)
        {
            ProductResponse response = new ProductResponse();

            try
            {
                var result = await _productContext.TblProducts.Where(x => x.Date_Inactive == null && x.Guid_SubCategoryId == Guid_SubCategoryId).ToListAsync();

                if (result != null)
                {
                    foreach (var item in result)
                    {
                        var category = _categoryContext.TblCategories.Where(a => a.Guid_CategoryId == item.Guid_CategoryId).FirstOrDefault();
                        var subcategory = _categoryContext.TblCategories.Where(a => a.Guid_CategoryId == item.Guid_SubCategoryId).FirstOrDefault();
                        var subsubcategory = _categoryContext.TblCategories.Where(a => a.Guid_CategoryId == item.Guid_SubSubCategoryId).FirstOrDefault();
                        var brandname = _brandContext.TblBrands.Where(b => b.GuidBrandId == item.Guid_BrandId).FirstOrDefault();


                        ProductData data = new ProductData();
                        data.Guid_CategoryId = item.Guid_CategoryId;
                        data.ProductName = item.ProductName;
                        data.Short_Description = item.Short_Description;
                        data.Full_Description = item.Full_Description;
                        data.Is_InSale = item.Is_InSale;
                        data.Price = item.Price;
                        data.Discount = item.Discount;
                        data.Available_Stock = item.Available_Stock;
                        data.Guid_BrandId = item.Guid_BrandId;
                        data.Thumbnail_Image_Url = item.Thumbnail_Image_Url;

                        data.Guid_SubCategoryId = item.Guid_SubCategoryId;
                        data.Guid_SubSubCategoryId = item.Guid_SubSubCategoryId;
                        if (category != null)
                            data.Category = category.CategoryName;
                        if (subcategory != null)
                            data.SubCategory = subcategory.CategoryName;
                        if (subsubcategory != null)
                            data.SubsubCategory = subsubcategory.CategoryName;
                        if (brandname != null)
                            data.BrandName = brandname.BrandName;

                        response.productDatas.Add(data);
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

        public async Task<ProductResponse> Updateproduct(Updateproduct updateproduct)
        {
            ProductResponse response = new ProductResponse();
            try
            {
                var product = _productContext.TblProducts.Where(x => x.Guid_ProductId == updateproduct.Guid_ProductId).FirstOrDefault();
                if (product != null)
                {
                    product.Guid_ProductId = updateproduct.Guid_ProductId;
                    product.Guid_CategoryId = updateproduct.Guid_CategoryId;
                    product.ProductName = updateproduct.ProductName;
                    product.Guid_SubCategoryId = updateproduct.Guid_SubCategoryId;
                    product.Guid_SubSubCategoryId = updateproduct.Guid_SubSubCategoryId;
                    product.Short_Description = updateproduct.Short_Description;
                    product.Is_InSale = updateproduct.Is_InSale;
                    product.Guid_BrandId = updateproduct.Guid_BrandId;
                    product.Full_Description = updateproduct.Full_Description;
                    product.Price = Convert.ToDecimal(updateproduct.Price);
                    product.Discount = Convert.ToDecimal(updateproduct.Discount);
                    product.Available_Stock = Convert.ToDecimal(updateproduct.Available_Stock);

                    product.Date_Inactive = null;
                   

                    product.Date_Created = DateTime.Now;
                    product.Uid_Created = updateproduct.UserId;


                };


                _productContext.TblProducts.Update(product);
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

        public async Task<ProductResponse> UploadImage(IFormFile file, string guidproductid)
        {
            ProductResponse response = new ProductResponse();
            try
            {

                if (file == null || file.Length == 0)
                {
                    response.Status = false;
                    response.Message = "";
                    return response;
                }

                string uploadsFolder = Path.Combine(_imageSettings.ImageFolderPath);
                string uniqueFileName = RandomNumber(1000, 50000) + "_" + file.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }
                var product = _productContext.TblProducts.Where(x => x.Guid_ProductId == guidproductid).FirstOrDefault();

                if (product != null)
                {
                    product.Thumbnail_Image_Url = uniqueFileName;
                    _productContext.TblProducts.Update(product);
                    var result = await _categoryContext.SaveChangesAsync();
                    if (result > 0)
                    {
                        response.Status = true;
                        response.Message = "Image uploaded successfully.";
                    }
                    else
                    {
                        response.Status = false;
                        response.Message = "data already added";
                    }
                }

                return response;

            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.ToString();
            }
            return response;
        }

        public int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
    }
}
