using PVK.DTO.UserRole;
using PVK.Interfaces.Services.UserRole;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PVK.Application.Services.UserRole
{
    public class UserRoleService : IUserRoleService
    {
        private IUserRoleProcessor _userRoleProcessor;
        public UserRoleService(IUserRoleProcessor userRoleProcessor)
        {
            this._userRoleProcessor = userRoleProcessor;
        }
        public async Task<UserRoleResponse> AddNewUserRole(AddUserRole addUserRole)
        {
            return await _userRoleProcessor.AddNewUserRole(addUserRole);
        }

        public async Task<UserRoleResponse> GetallUserrole()
        {
            return await _userRoleProcessor.GetallUserrole();
        }

        public async Task<UserRoleResponse> UpdateUserRole(UpdateUserRole updateUserRole)
        {
            return await _userRoleProcessor.UpdateUserRole(updateUserRole);
        }
    }
}
