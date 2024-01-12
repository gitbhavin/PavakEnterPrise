using Microsoft.EntityFrameworkCore;
using PVK.DTO.Wholeseller;
using PVK.EFCore.Data.WholesellerScope;
using PVK.Interfaces.Services.Wholeseller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVK.Application.Services.Wholeseller
{
    public class WholesellerProcessor : IWholesellerProcessor
    {
        private readonly WholesellerContext _wholesellerContext;

        public WholesellerProcessor(WholesellerContext wholesellerContext)
        {
            this._wholesellerContext = wholesellerContext;
        }
        public async Task<WholesellerResponse> Addwholeseller(Addwholeseller addwholeseller)
        {
            WholesellerResponse response = new WholesellerResponse();
            try
            {


                var wholeseller = new TblWholeseller()
                {
                    Guid_Wholesellerid = Guid.NewGuid().ToString(),
                    Name = addwholeseller.Name,
                    Email = addwholeseller.Email,
                    Phonenumber = addwholeseller.Phonenumber,
                    Companyname=addwholeseller.Companyname,
                    Message = addwholeseller.Message,
                    Date_Inactive = null,
                    Date_Created = DateTime.Now,
                    Uid_Created = addwholeseller.UserId


                };

                await _wholesellerContext.TblWholesellers.AddAsync(wholeseller);
                var result = await _wholesellerContext.SaveChangesAsync();
                if (result > 0)
                {
                    response.Status = true;
                    response.Message = "data save successfully";


                }

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
            }

            return response;


        }

        public async Task<WholesellerResponse> Deletewholeseller(Deletewholeseller deletewholeseller)
        {
            WholesellerResponse response = new WholesellerResponse();
            try
            {

                var wholeseller = _wholesellerContext.TblWholesellers.Where(x => x.Guid_Wholesellerid == deletewholeseller.Guid_Wholesellerid).FirstOrDefault();

                if (wholeseller != null)
                {




                    wholeseller.Date_Inactive = DateTime.Now;
                    wholeseller.Uid_Modified = deletewholeseller.UserId;


                    _wholesellerContext.TblWholesellers.Update(wholeseller);
                    var result = await _wholesellerContext.SaveChangesAsync();
                    if (result > 0)
                    {
                        response.Status = true;
                        response.Message = "wholeseller deleted successfully";


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

        public async Task<WholesellerResponse> Getallwholeseller()
        {
            WholesellerResponse response = new WholesellerResponse();

            try
            {
                var result = await _wholesellerContext.TblWholesellers.Where(x => x.Date_Inactive == null).OrderByDescending(a => a.Date_Created).ToListAsync();

                if (result != null)
                {
                    foreach (var item in result)
                    {
                        WholesellerData data = new WholesellerData();
                        data.Guid_Wholesellerid = item.Guid_Wholesellerid;
                        data.Name = item.Name;
                        data.Email = item.Email;
                        data.Phonenumber = item.Phonenumber;
                        data.Message = item.Message;
                        data.Companyname = item.Companyname;

                        response.wholesellerDatas.Add(data);
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

        public async Task<WholesellerResponse> GetWholesellerbyId(string GuidWholesellerid)
        {
            WholesellerResponse response = new WholesellerResponse();

            try
            {
                var result = await _wholesellerContext.TblWholesellers.Where(x => x.Date_Inactive == null && x.Guid_Wholesellerid == GuidWholesellerid).ToListAsync();

                if (result != null)
                {
                    foreach (var item in result)
                    {
                        WholesellerData data = new WholesellerData();
                        data.Guid_Wholesellerid = item.Guid_Wholesellerid;
                        data.Name = item.Name;
                        data.Email = item.Email;
                        data.Phonenumber = item.Phonenumber;
                        data.Message = item.Message;
                        data.Companyname = item.Companyname;
                        response.wholesellerDatas.Add(data);
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

        public async Task<WholesellerResponse> UpdateWholeseller(UpdateWholeseller updateWholeseller)
        {
            WholesellerResponse response = new WholesellerResponse();
            try
            {

                var wholeseller = new TblWholeseller()
                {
                    Guid_Wholesellerid = updateWholeseller.Guid_Wholesellerid,
                    Name = updateWholeseller.Name,
                    Email = updateWholeseller.Email,
                    Phonenumber = updateWholeseller.Phonenumber,
                    Message = updateWholeseller.Message,
                    Companyname=updateWholeseller.Companyname,
                    Date_Inactive = null,
                    Date_Created = DateTime.Now,
                    Uid_Created = updateWholeseller.UserId


                };

                 _wholesellerContext.TblWholesellers.Update(wholeseller);
                var result = await _wholesellerContext.SaveChangesAsync();
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
