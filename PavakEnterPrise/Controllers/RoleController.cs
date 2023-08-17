using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PVK.DTO.BaseResponse;
using PVK.DTO.Role;
using PVK.Interfaces.Services.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PVK.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private IRoleService _service;
        public RoleController(IRoleService roleService)
        {
            this._service = roleService;
        }
        [HttpGet("GetAllRole")]
        public async Task<RoleResponse> GetAllBrands()
        {
            return await _service.Getallrole();
        }

        [HttpPost("Addnewbrand")]
        public async Task<RoleResponse> addnewbrand(AddNewRole addnewrole)
        {
            return await _service.Addnewrole(addnewrole);
        }
    }
}
