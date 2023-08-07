using PVK.DTO.BaseResponse;
using PVK.DTO.Role;
using PVK.Interfaces.Services.Role;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PVK.Application.Services
{
    public class RoleService : IRoleService
    {
        private IRoleProcessor _roleProcessor;
        public RoleService(IRoleProcessor roleProcessor)
        {
            this._roleProcessor = roleProcessor;
        }
        public async Task<RoleResponse> Addnewrole(AddNewRole addNewRole)
        {
            return await _roleProcessor.Addnewrole(addNewRole);
        }

        public async Task<RoleResponse> Getallrole()
        {
            return await _roleProcessor.Getallrole();
        }
    }
}
