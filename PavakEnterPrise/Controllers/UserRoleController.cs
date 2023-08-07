using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PVK.DTO.UserRole;
using PVK.Interfaces.Services.UserRole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PVK.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRoleController : ControllerBase
    {
        private IUserRoleService _service;
        public UserRoleController(IUserRoleService userRoleService)
        {
            this._service = userRoleService;
        }
        [HttpGet("GetAllUserRole")]
        public async Task<UserRoleResponse> GetalluserRole()
        {
            return await _service.GetallUserrole();
        }

        [HttpPost("AddUserRole")]
        public async Task<UserRoleResponse> AdduserRole(AddUserRole addUserRole)
        {
            return await _service.AddNewUserRole(addUserRole);
        }

        [HttpPost("UpdateUserRole")]
        public async Task<UserRoleResponse> UpdateUserRole(UpdateUserRole updateUserRole)
        {
            return await _service.UpdateUserRole(updateUserRole);
        }

    }
}
