using Microsoft.EntityFrameworkCore;
using PVK.DTO.UserRole;
using PVK.EFCore.Data.RoleScope;
using PVK.EFCore.Data.UserRoleScope;
using PVK.EFCore.Data.UserScope;
using PVK.Interfaces.Services.UserRole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVK.Application.Services.UserRole
{
    public class UserRoleProcessor : IUserRoleProcessor
    {
        private UserRoleContext _userroleContext;
        private RoleContext _roleContext;
        private UserContext _userContext;
        public UserRoleProcessor(UserRoleContext userroleContext,RoleContext roleContext, UserContext userContext)
        {
            this._userroleContext = userroleContext;
            this._roleContext = roleContext;
            this._userContext = userContext;
        }
        public async Task<UserRoleResponse> AddNewUserRole(AddUserRole addUserRole)
        {
            UserRoleResponse response = new UserRoleResponse();
            try
            {            

                    var role = new TblUserRole()
                    {
                        Guid_UserRoleId=Guid.NewGuid().ToString(),
                        Guid_RoleId = addUserRole.Guid_RoleId,
                        Guid_UserId = addUserRole.Guid_UserId,
                        Date_Inactive = null,
                        Date_Created = DateTime.Now,
                        Uid_Created = addUserRole.UserId


                    };

                    await _userroleContext.TblUserRoles.AddAsync(role);
                    var result = await _userroleContext.SaveChangesAsync();
                    if (result > 0)
                    {
                        response.Status = true;
                        response.Message = "User Role Assign successfully";


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

        public async Task<UserRoleResponse> GetallUserrole()
        {
            UserRoleResponse response = new UserRoleResponse();

            try
            {
                var result = await _userroleContext.TblUserRoles.Where(x => x.Date_Inactive == null).ToListAsync();

                if (result != null)
                {
                    foreach (var item in result)
                    {
                        UserRoleData data = new UserRoleData();
                        data.Guid_UserRoleId = item.Guid_UserRoleId;
                        data.Guid_UserId = item.Guid_UserId;
                        data.Guid_RoleId = item.Guid_RoleId;
                        data.RoleName = _roleContext.TblRoles.Where(r => r.Guid_RoleId == item.Guid_RoleId).FirstOrDefault().RoleName;
                        data.UserName = _userContext.TblUsers.Where(u => u.Guid_Userid == item.Guid_UserId).FirstOrDefault().UserName;
                        
                        response.userRoleDatas.Add(data);
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

        public async Task<UserRoleResponse> UpdateUserRole(UpdateUserRole updateUserRole)
        {
            UserRoleResponse response = new UserRoleResponse();
            try
            {
                var userrole = new TblUserRole()
                {
                    Guid_UserRoleId = updateUserRole.Guid_UserRoleId,
                    Guid_RoleId = updateUserRole.Guid_RoleId,
                    Guid_UserId=updateUserRole.Guid_UserId,
                    Date_Modified = DateTime.Now,
                    Uid_Modified = updateUserRole.Guid_UserId
                };

                _userroleContext.TblUserRoles.Update(userrole);
                var result = await _userroleContext.SaveChangesAsync();
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
