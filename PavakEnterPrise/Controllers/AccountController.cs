using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PVK.DTO.Account;
using PVK.DTO.BaseResponse;
using PVK.Interfaces.Services.Account;
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

        public AccountController(IAccountService accountService)
        {
            this._accountservice = accountService;
        }

        [HttpPost("CreateAccount")]
        public async Task<BaseResponse> Createnewaccount(UserRequest userRequest)
        {
            return await _accountservice.UserResgistration(userRequest);
        }
    }
}
