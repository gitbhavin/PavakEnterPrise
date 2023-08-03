using PVK.DTO.Account;
using PVK.DTO.BaseResponse;
using PVK.EFCore.Data.UserScope;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PVK.Interfaces.Services.Account
{
   public interface IAccountService
    {
        Task<BaseResponsedata> UserResgistration(UserRequest userRequest);

        Task<TblUser> GetUserByEmailOrMobile(LoginRequest userInputModel);

    }
}
