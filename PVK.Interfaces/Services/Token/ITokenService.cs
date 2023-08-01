using PVK.DTO.Account;
using PVK.EFCore.Data.UserScope;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PVK.Interfaces.Services.Token
{
   public interface ITokenService
    {
        Task<AccountResponse> CreateJwtTokens(TblUser user, string refreshTokenSource);
    }
}
