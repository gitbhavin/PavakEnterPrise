using Microsoft.EntityFrameworkCore;
using PVK.DTO.BaseResponse;
using PVK.DTO.Role;
using PVK.EFCore.Data.RoleScope;
using PVK.Interfaces.Services.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVK.Application.Services.Role
{
    public class RoleProcessor : IRoleProcessor
    {
        private RoleContext _roleContext;
        public RoleProcessor(RoleContext roleContext)
        {
            this._roleContext = roleContext;
        }
        public async Task<RoleResponse> Addnewrole(AddNewRole addNewRole)
        {
            RoleResponse response = new RoleResponse();
            try
            {

                var rolename = _roleContext.TblRoles.Where(x => x.RoleName == addNewRole.RoleName).FirstOrDefault();
                if (rolename == null)
                {

                    var role = new tblRole()
                    {
                      Guid_RoleId=Guid.NewGuid().ToString(),
                      RoleName=addNewRole.RoleName,
                        Date_Inactive = null,
                        Date_Created = DateTime.Now,
                        Uid_Created = addNewRole.UserId


                    };

                    await _roleContext.TblRoles.AddAsync(role);
                    var result = await _roleContext.SaveChangesAsync();
                    if (result > 0)
                    {
                        response.Status = true;
                        response.Message = "Role save successfully";


                    }
                    else
                    {
                        response.Status = false;
                        response.Message = "Role already added";
                    }
                }
                else
                {
                    response.Status = false;
                    response.Message = "Role already added";
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

        public async Task<RoleResponse> Getallrole()
        {
            RoleResponse response = new RoleResponse();

            try
            {
                var result = await _roleContext.TblRoles.Where(x => x.Date_Inactive == null).ToListAsync();

                if (result != null)
                {
                    foreach (var item in result)
                    {
                        RoleData data = new RoleData();
                        data.Guid_RoleId = item.Guid_RoleId;
                        data.RoleName = item.RoleName;

                        response.RoleDatas.Add(data);
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
    }
}
