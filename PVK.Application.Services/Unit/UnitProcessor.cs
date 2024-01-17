using Microsoft.EntityFrameworkCore;
using PVK.DTO.Brand;
using PVK.DTO.Unit;
using PVK.EFCore.Data.BrandScope;
using PVK.EFCore.Data.UnitScope;
using PVK.Interfaces.Services.Unit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVK.Application.Services.Unit
{
    public class UnitProcessor : IUnitProcessor
    {

        private UnitContext _unitContext;
        public UnitProcessor(UnitContext unitContext)
        {
            this._unitContext = unitContext;
        }
        public async Task<unitresponse> Addnewunit(addunit addunit)
        {
            unitresponse response = new unitresponse();
            try
            {

                var unitname = _unitContext.TblUnits.Where(x => x.unitname == addunit.unitname).FirstOrDefault();
                if (unitname == null)
                {

                    var unit = new TblUnit()
                    {
                        unitguid = Guid.NewGuid().ToString(),
                        unitname = addunit.unitname,


                    };

                    await _unitContext.TblUnits.AddAsync(unit);
                    var result = await _unitContext.SaveChangesAsync();
                    if (result > 0)
                    {
                        response.Status = true;
                        response.Message = "unit save successfully";

                    }
                    else
                    {
                        response.Status = false;
                        response.Message = "unit already added";
                    }
                }
                else
                {
                    response.Status = false;
                    response.Message = "unit already added";
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

        public async Task<unitresponse> GetAllUnit()
        {
            unitresponse response = new unitresponse();

            try
            {
                var result = await _unitContext.TblUnits.OrderByDescending(a => a.unitname).ToListAsync();

                if (result != null)
                {
                    foreach (var item in result)
                    {
                        unitdata data = new unitdata();
                        data.unitguid = item.unitguid;
                        data.unitname = item.unitname;

                        response.unitdata.Add(data);
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

        public async Task<unitresponse> GetUnitbyId(string guidunitId)
        {
            unitresponse response = new unitresponse();

            try
            {
                var result = await _unitContext.TblUnits.Where(x => x.unitguid == guidunitId).ToListAsync();

                if (result != null)
                {
                    foreach (var item in result)
                    {
                        unitdata data = new unitdata();
                        data.unitguid = item.unitguid;
                        data.unitname = item.unitname;

                        response.unitdata.Add(data);
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

        public async Task<unitresponse> Removeunit(addunit removeunit)
        {
            unitresponse response = new unitresponse();

            try
            {
                var result = await _unitContext.TblUnits.Where(x => x.unitguid == removeunit.unitguid).FirstOrDefaultAsync();
                if (result != null)
                {

                    _unitContext.TblUnits.Remove(result);
                    var results = await _unitContext.SaveChangesAsync();
                    if (results > 0)
                    {
                        response.Status = true;
                        response.Message = "unit deleted successfully";


                    }
                    else
                    {
                        response.Status = false;
                        response.Message = "unit already added";
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

        public async Task<unitresponse> UpdateUnit(addunit updateunit)
        {
            unitresponse response = new unitresponse();

            try
            {
                var unitname = await _unitContext.TblUnits.Where(x => x.unitguid == updateunit.unitguid).ToListAsync();

                if (unitname != null)
                {

                    var unit = new TblUnit()
                    {
                        unitguid = updateunit.unitguid,
                        unitname = updateunit.unitname,

                    };

                    _unitContext.TblUnits.Update(unit);
                    var result = await _unitContext.SaveChangesAsync();
                    if (result > 0)
                    {
                        response.Status = true;
                        response.Message = "unit updated successfully";


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
    }
}
