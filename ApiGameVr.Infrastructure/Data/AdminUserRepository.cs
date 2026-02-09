using ApiGameVr.Application.Interfaces.Repositories;
using ApiGameVr.Domain.Entities;
using ApiGameVr.Infrastructure.Identity.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiGameVr.Infrastructure.Data
{
    public class AdminUserRepository : IAdminUserRepository
    {
        private readonly UserManager<IdentityAdminUser> _userManager;
        private readonly IUserStore<IdentityAdminUser> _userStore;
        private readonly IUserEmailStore<IdentityAdminUser> _emailStore;
        public AdminUserRepository(UserManager<IdentityAdminUser> userManager,IUserStore<IdentityAdminUser> userStore)
        {
            _userManager = userManager;
            _userStore = userStore;
            _emailStore = (IUserEmailStore<IdentityAdminUser>)userStore;
        }
        public async Task<AdminUser> AddAsync(AdminUser entity)
        {
            throw new NotImplementedException();
        }

        public async Task<AdminUser> CreateAsync(AdminUser adminUser, string password)
        {
            IdentityAdminUser user = new IdentityAdminUser { User = adminUser };
            await _userStore.SetUserNameAsync(user, adminUser.Email, CancellationToken.None);
            await _emailStore.SetEmailAsync(user, adminUser.Email, CancellationToken.None);
            IdentityResult request = await _userManager.CreateAsync(user,password);
            if (!request.Succeeded)
            {
                throw new ArgumentException($"{request.Errors?.FirstOrDefault()?.Description}");
            }
            return adminUser;
        }

        public Task DeleteAsync(AdminUser entity)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<AdminUser>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<AdminUser> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(AdminUser entity)
        {
            throw new NotImplementedException();
        }
    }
}
