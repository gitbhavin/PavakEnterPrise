using PVK.DTO.BaseResponse;
using PVK.DTO.Role;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PVK.Interfaces.Services.Role
{
    public interface IRoleProcessor
    {
        Task<RoleResponse> Getallrole();

        Task<RoleResponse> Addnewrole(AddNewRole addNewRole);
    }
}
