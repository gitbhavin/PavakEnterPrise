using Microsoft.EntityFrameworkCore;
using PVK.DTO.Account;
using PVK.DTO.BaseResponse;
using PVK.EFCore.Data.UserScope;
using PVK.Interfaces.Services.Account;
using PVK.QueryHandlers.Helper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PVK.Application.Services.Account
{
    public class AccountProcessor : IAccountProcessor
    {
        private UserContext _usercontext;

        public AccountProcessor(UserContext userContext)
        {
            this._usercontext = userContext;
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
                var user = _usercontext.TblUsers.FindAsync(userRequest.Email);
                if (user.IsCompletedSuccessfully == false)
                {
                    var newuser = new TblUser()
                    {
                        Guid_Userid=Guid.NewGuid().ToString(),
                        FirstName=userRequest.FirstName,
                        LastName=userRequest.LastName,
                        Email=userRequest.Email,
                        Phone=userRequest.MobileNumber,
                        UserName=userRequest.Email,
                        Password=PwdCryptography.HashPassword(userRequest.Password)

                    };

                    await _usercontext.TblUsers.AddAsync(newuser);
                    int result = await _usercontext.SaveChangesAsync();
                    if (result > 0)
                    {
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
