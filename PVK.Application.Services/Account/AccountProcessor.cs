using Microsoft.EntityFrameworkCore;
using PVK.DTO.Account;
using PVK.DTO.BaseResponse;
using PVK.EFCore.Data.RoleScope;
using PVK.EFCore.Data.UserRoleScope;
using PVK.EFCore.Data.UserScope;
using PVK.Interfaces.Services.Account;
using PVK.QueryHandlers.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVK.Application.Services.Account
{
    public class AccountProcessor : IAccountProcessor
    {
        private UserContext _usercontext;
        private UserRoleContext _userroleContext;
        private RoleContext _roleContext;
        public AccountProcessor(UserContext userContext, RoleContext roleContext, UserRoleContext userRoleContext)
        {
            this._usercontext = userContext;
            this._roleContext = roleContext;
            this._userroleContext = userRoleContext;
        }

        public async Task<TblUser> GetUserByEmailOrMobile(LoginRequest loginRequest)
        {
            return await _usercontext.TblUsers.FirstOrDefaultAsync(x => x.UserName == loginRequest.UserName);

        }

        public async Task<BaseResponsedata> UserResgistration(UserRequest userRequest)
        {
            BaseResponsedata response = new BaseResponsedata();
            try
            {
                string userguid = string.Empty;
                var user = await _usercontext.TblUsers.FindAsync(userRequest.Email);
                if (user == null)
                {
                    userguid = Guid.NewGuid().ToString();
                    var newuser = new TblUser()
                    {
                        Guid_Userid= userguid,
                        FirstName=userRequest.FirstName,
                        LastName=userRequest.LastName,
                        Email=userRequest.Email,
                        Phone=userRequest.MobileNumber,
                        UserName=userRequest.Email,
                        Source=userRequest.Source,
                        Password=PwdCryptography.HashPassword(userRequest.Password)

                    };

                   await _usercontext.TblUsers.AddAsync(newuser);
                    var result = await _usercontext.SaveChangesAsync();
                    if (result > 0)
                    {
                        var role = await _roleContext.TblRoles.FirstOrDefaultAsync(x=>x.RoleName=="User");
                        if (role != null)
                        {
                            var userrole = new TblUserRole()
                            {
                                Guid_UserRoleId = Guid.NewGuid().ToString(),
                                Guid_RoleId = role.Guid_RoleId,
                                Guid_UserId = userguid,
                                Uid_Created = userguid,
                                Date_Created = DateTime.Now,
                                Date_Inactive = null
                            };
                            await _userroleContext.TblUserRoles.AddAsync(userrole);
                            await _userroleContext.SaveChangesAsync();
                        }
                        response.Status = true;
                        response.Message = "registration Successfully";
                    }
                   
                }
                else
                {
                    response.Status = false;
                    response.Message = "Email already exists.";
                   
                }
                return response;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
