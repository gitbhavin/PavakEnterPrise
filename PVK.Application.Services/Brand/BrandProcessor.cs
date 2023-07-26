using Microsoft.EntityFrameworkCore;
using PVK.DTO.Brand;
using PVK.EFCore.Data.BrandScope;
using PVK.Interfaces.Services.Brand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVK.Application.Services.Brand
{
    public class BrandProcessor : IBrandProcessor
    {
        private BrandContext _brandContext;
        public BrandProcessor(BrandContext brandContext)
        {
            this._brandContext = brandContext;
        }

        public async Task<BrandResponse> addnewbrand(Addbranddata addbranddata)
        {
            BrandResponse response = new BrandResponse();
            try
            {

                var brandname = _brandContext.TblBrands.Where(b => b.BrandName == addbranddata.BrandName).FirstOrDefault();
                if (brandname == null)
                {
                    var guid = Guid.NewGuid();
                    var brand = new TblBrand()
                    {
                        GuidBrandId = guid.ToString(),
                        BrandName = addbranddata.BrandName,
                        DateInactive = null
                    };                   
                   
                     await _brandContext.TblBrands.AddAsync(brand);
                    var result = await _brandContext.SaveChangesAsync();
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

        public async Task<BrandResponse> GetAllBrands()
        {
            BrandResponse response = new BrandResponse();

            try
            {
                var result = await _brandContext.TblBrands.Where(x => x.DateInactive == null).ToListAsync();

                if (result != null)
                {
                    foreach (var item in result)
                    {
                        BrandData data = new BrandData();
                        data.GuidBrandId = item.GuidBrandId;
                        data.BrandName = item.BrandName;

                        response.Brands.Add(data);
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

        public  async Task<BrandResponse> RemoveBrand(deletebrand tblBrand)
        {
            BrandResponse response = new BrandResponse();
            try
            {
                var brand = new TblBrand()
                {
                    GuidBrandId = tblBrand.GuidBrandId,
                  
                };
                _brandContext.TblBrands.Remove(brand);
               var result= await _brandContext.SaveChangesAsync();
                if (result > 0)
                {
                    response.Status = true;
                    response.Message = "data deleted successfully";


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

        public async Task<BrandResponse> UpdateBrand(updatebrand tblBrand)
        {
            BrandResponse response = new BrandResponse();
            try
            {
                var brand = new TblBrand()
                {
                    GuidBrandId = tblBrand.GuidBrandId,
                    BrandName = tblBrand.BrandName
                };

                _brandContext.TblBrands.Update(brand);
                var result = await _brandContext.SaveChangesAsync();
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
