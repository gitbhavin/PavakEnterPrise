using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using PVK.DTO.Account;
using PVK.EFCore.Data.TokenScope;
using PVK.EFCore.Data.UserScope;
using PVK.Interfaces.Services.Token;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TokenContext = PVK.EFCore.Data.TokenScope.TokenContext;

namespace PVK.Application.Services.Token
{
  public  class TokenProcessor : ITokenProcessor
    {
        private readonly ILogger _logger;
        private readonly ITokenProcessor _tokenProcessor;
        private readonly BearerTokensOptions _configuration;
        private readonly ISecurityService _securityService;
        private readonly TokenContext _tokenContext;

        public TokenProcessor(TokenContext tokenContext, ILoggerFactory loggerFactory, BearerTokensOptions configuration, ISecurityService securityService)
        {
            _logger = loggerFactory.CreateLogger<TokenProcessor>();
            _configuration = configuration;
            _securityService = securityService;
            this._tokenContext = tokenContext;
        }
        public async Task<AccountResponse> CreateJwtTokens(TblUser user, string refreshTokenSource)
        {
            AccountResponse response = new AccountResponse();
            if (string.IsNullOrEmpty(refreshTokenSource))
                refreshTokenSource = _securityService.CreateCryptographicallySecureGuid().ToString().Replace("-", "");
            var accessToken = await CreateAccessTokenAsync(user);
            var refreshToken = Guid.NewGuid().ToString().Replace("-", "");
            await AddUserTokenAsync(user, refreshToken, accessToken, refreshTokenSource);
            //await _modelDbContext.SaveChangesAsync();
            response.AccessToken = accessToken;
            response.RefreshToken = refreshToken;
            response.Userid = user.Guid_Userid;
            response.Status = true;
            return response;
        }

        public async Task AddUserTokenAsync(TblUser user, string refreshToken, string accessToken, string refreshTokenSource)
        {
            var now = DateTimeOffset.UtcNow;
            var token = new UserToken
            {
                Guid_UserTokenId=Guid.NewGuid().ToString(),
                Guid_UserId = user.Guid_Userid,
                // Refresh token handles should be treated as secrets and should be stored hashed
                RefreshToken = _securityService.GetSha256Hash(refreshToken),
                AccessToken = _securityService.GetSha256Hash(accessToken),
                RefreshToken_Expiry = now.AddMinutes(_configuration.RefreshTokenExpirationMinutes),
                AccessToken_Expiry = now.AddMinutes(_configuration.AccessTokenExpirationMinutes),
            };
            await AddUserTokenAsync(token);
        }

        public async Task AddUserTokenAsync(UserToken userToken)
        {
            if (!_configuration.AllowMultipleLoginsFromTheSameUser)
            {
                await InvalidateUserTokensAsync(userToken.Guid_UserId);
            }
            await DeleteTokensWithSameRefreshTokenSourceAsync(userToken.RefreshToken);

            await _tokenContext.UserTokens.AddAsync(userToken);
            await _tokenContext.SaveChangesAsync();
        }

        public async Task DeleteTokensWithSameRefreshTokenSourceAsync(string refreshTokenIdHashSource)
        {
            if (string.IsNullOrWhiteSpace(refreshTokenIdHashSource))
            {
                return;
            }
            var userTokens = await _tokenContext.UserTokens.Where(x => x.RefreshToken == refreshTokenIdHashSource).ToListAsync();
            if (userTokens.Any())
            {
                _tokenContext.UserTokens.RemoveRange(userTokens);
                await _tokenContext.SaveChangesAsync();
            }
        }
        public async Task InvalidateUserTokensAsync(string userId)
        {
            try
            {
                var userTokens = await _tokenContext.UserTokens.Where(x => x.Guid_UserId == userId).ToListAsync();
                if (userTokens.Any())
                {
                    _tokenContext.UserTokens.RemoveRange(userTokens);
                    await _tokenContext.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        private async Task<string> CreateAccessTokenAsync(TblUser user)
        {
            var claims = new List<Claim>
            {
                // Unique Id for all Jwt tokes
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                // Issuer
                //new Claim(JwtRegisteredClaimNames.Iss, _configuration.Issuer),
                // Issued at
                new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64),
                // to invalidate the cookie
               // new Claim(ClaimTypes.SerialNumber, user.se),
                // custom data
                new Claim(ClaimTypes.UserData, JsonConvert.SerializeObject(user,new JsonSerializerSettings
                        {
                            ContractResolver = new CamelCasePropertyNamesContractResolver()
                        })),
                new Claim(ClaimTypes.Email, string.IsNullOrEmpty(user.Email) ? "":user.Email ),
                new Claim("PhoneNo", string.IsNullOrEmpty(user.Phone) ? "":user.Phone ),
                new Claim(ClaimTypes.Name, user.FirstName +' ' +user.LastName),
                //new Claim("RefenreceKey", user.ReferenceKey.ToString()),
                //new Claim(ClaimTypes.Role, JsonConvert.SerializeObject(user.UserRoles)),
                
                #region [extra claims if needed]
                new Claim(ClaimTypes.NameIdentifier, user.Guid_Userid.ToString()),
                #endregion
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.Key));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
            var now = DateTime.UtcNow;
            var token = new JwtSecurityToken(
                issuer: _configuration.Issuer,
                audience: _configuration.Audience,
                claims: claims,
                notBefore: now,
                expires: now.AddMinutes(_configuration.AccessTokenExpirationMinutes),
                signingCredentials: creds);
            return await Task.FromResult(new JwtSecurityTokenHandler().WriteToken(token));
        }
    }
}
