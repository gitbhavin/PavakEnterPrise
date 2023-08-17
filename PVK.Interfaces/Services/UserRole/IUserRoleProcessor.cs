using PVK.DTO.UserRole;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PVK.Interfaces.Services.UserRole
{
   public interface IUserRoleProcessor
    {
        Task<UserRoleResponse> AddNewUserRole(AddUserRole addUserRole);
        Task<UserRoleResponse> UpdateUserRole(UpdateUserRole updateUserRole);
        Task<UserRoleResponse> GetallUserrole();
    }
}
