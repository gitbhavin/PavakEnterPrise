using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PVK.DTO.Account;
using PVK.DTO.BaseResponse;
using PVK.EFCore.Data.UserScope;
using PVK.Interfaces.Services.Account;
using PVK.Interfaces.Services.Token;
using PVK.QueryHandlers.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PVK.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IAccountService _accountservice;
        private ITokenService _tokenservice;

        public AccountController(IAccountService accountService, ITokenService tokenService)
        {
            this._accountservice = accountService;
            this._tokenservice = tokenService;
        }

        [HttpPost("CreateAccount")]
        public async Task<BaseResponsedata> Createnewaccount(UserRequest userRequest)
        {
            return await _accountservice.UserResgistration(userRequest);
        }
        [HttpPost("GetUserInfo")]
        public async Task<TblUser> GetUserInfo(string userid)
        {
            return await _accountservice.GetUserInfo(userid);
        }
        [HttpGet]
        [Route("GetAllUser")]

        public async Task<userresponse> getalluser()
        {
            return await _accountservice.getallusers();
        }

        [HttpPost("login")]
        public async Task<AccountResponse> Login(LoginRequest loginRequest)
        {
            AccountResponse response = new AccountResponse();
            try
            {

                var user = await _accountservice.GetUserByEmailOrMobile(loginRequest);
                if (user != null)
                {
                    return await _tokenservice.CreateJwtTokens(user, Guid.NewGuid().ToString().Replace("-", ""));

                }
                response.Status = true;
                
                return response;

            }
            catch(Exception ex)
            {
                response.Status = false;                
                return response;
            }
           }
    }
}
