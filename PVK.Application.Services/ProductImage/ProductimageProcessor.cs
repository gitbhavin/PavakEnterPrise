using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using PVK.DTO.ProductImage;
using PVK.EFCore.Data.ProductImageScope;
using PVK.EFCore.Data.ProductScope;
using PVK.Interfaces.Services.ProductImage;
using PVK.QueryHandlers.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVK.Application.Services.ProductImage
{
    public class ProductimageProcessor : IProductimageProcessor
    {
        private readonly ProductImageContext _productimageContext;
        private readonly ProductContext _productContext;
        private readonly ImageSettings _imageSettings;
        public ProductimageProcessor(ProductImageContext productImageContext, ProductContext productContext, ImageSettings imageSettings)
        {
            this._productimageContext = productImageContext;
            this._imageSettings = imageSettings;
            this._productContext = productContext;
        }

        public async Task<ProdcutimageResponse> AddProductimages(IFormFile file, Addproductimage addproductimage)
        {
            ProdcutimageResponse response = new ProdcutimageResponse();
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

                var productimage = new TblProductImage()
                {
                   Guid_ProductImageId=Guid.NewGuid().ToString(),
                   Guid_ProductId=addproductimage.Guid_ProductId,
                   Is_Primary=addproductimage.Is_Primary,
                   Image_Url= uniqueFileName,
                    Date_Inactive = null,

                    Date_Created = DateTime.Now,
                    Uid_Created = addproductimage.UserId


                };

                await _productimageContext.TblProductImages.AddAsync(productimage);
                var result = await _productimageContext.SaveChangesAsync();
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
               

                return response;

            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.ToString();
            }
            return response;
        }

        public async Task<ProdcutimageResponse> deleteproductimage(Deleteproductimage deleteproductimage)
        {
            ProdcutimageResponse response = new ProdcutimageResponse();
            try
            {

                var productimage = _productimageContext.TblProductImages.Where(x => x.Guid_ProductImageId == deleteproductimage.Guid_ProductImageId).FirstOrDefault();

                if (productimage != null)
                {




                    productimage.Date_Inactive = DateTime.Now;
                    productimage.Uid_Modified = deleteproductimage.UserId;


                    _productimageContext.TblProductImages.Update(productimage);
                    var result = await _productimageContext.SaveChangesAsync();
                    if (result > 0)
                    {
                        response.Status = true;
                        response.Message = "deleted successfully";


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
                response.Message = ex.Message;
                response.Status = false;

                return response;
            }
        }

        public async Task<ProdcutimageResponse> GetallImagesbyProductId(string guidProductId)
        {
            ProdcutimageResponse response = new ProdcutimageResponse();

            try
            {
                var result = await _productimageContext.TblProductImages.Where(x => x.Date_Inactive == null && x.Guid_ProductId == guidProductId).ToListAsync();

                if (result != null)
                {
                    foreach (var item in result)
                    {
                        var product = _productContext.TblProducts.Where(a => a.Guid_ProductId == item.Guid_ProductId).FirstOrDefault();
                       
                        Productimagedata data = new Productimagedata();
                        data.Guid_ProductImageId = item.Guid_ProductImageId;
                        data.Guid_ProductId = item.Guid_ProductId;
                        data.Is_Primary = item.Is_Primary;
                        data.Image_Url = item.Image_Url;
                       
                        if (product != null)
                            data.ProductName = product.ProductName;
                       
                        response.productimagedatas.Add(data);
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

        public Task<ProdcutimageResponse> UploadProductimages(IFormFile file, Updateproductimage updateproductimage)
        {
            throw new NotImplementedException();
        }

        public int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
    }
}
