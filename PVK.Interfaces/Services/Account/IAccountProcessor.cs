using PVK.DTO.Account;
using PVK.DTO.BaseResponse;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PVK.Interfaces.Services.Account
{
    public interface IAccountProcessor
    {
        Task<BaseResponse> UserResgistration(UserRequest userRequest);
    }
}
