﻿using PVK.DTO.Account;
using PVK.DTO.BaseResponse;
using PVK.Interfaces.Services.Account;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PVK.Application.Services.Account
{
    public class AccountService : IAccountService
    {

        private IAccountProcessor _accountProcessor;

        public AccountService(IAccountProcessor accountProcessor)
        {
            this._accountProcessor = accountProcessor;
        }
        public async Task<BaseResponse> UserResgistration(UserRequest userRequest)
        {
            return await _accountProcessor.UserResgistration(userRequest);
        }
    }
}