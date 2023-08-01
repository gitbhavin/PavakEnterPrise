using PVK.DTO.Account;
using PVK.EFCore.Data.UserScope;
using PVK.Interfaces.Services.Token;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PVK.Application.Services.Token
{
   public class TokenService : ITokenService
    {
        private ITokenProcessor _tokenProcessor;

        public TokenService(ITokenProcessor tokenProcessor)
        {
            this._tokenProcessor = tokenProcessor;
        }
        public async Task<AccountResponse> CreateJwtTokens(TblUser user, string refreshTokenSource)
        {
            return await _tokenProcessor.CreateJwtTokens(user, refreshTokenSource);
        }
    }
}
