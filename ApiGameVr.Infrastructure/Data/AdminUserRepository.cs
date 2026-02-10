using ApiGameVr.Application.Interfaces.Repositories;
using ApiGameVr.Domain.Entities;
using ApiGameVr.Infrastructure.Identity.Users;
using Microsoft.AspNetCore.Authentication.BearerToken;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.VisualBasic;
using Serilog;
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
        private readonly SignInManager<IdentityAdminUser> _signInManager;
        public AdminUserRepository(UserManager<IdentityAdminUser> userManager,IUserStore<IdentityAdminUser> userStore, SignInManager<IdentityAdminUser> signInManager)
        {
            _userManager = userManager;
            _userStore = userStore;
            _emailStore = (IUserEmailStore<IdentityAdminUser>)userStore;
            _signInManager = signInManager;
        }
        public async Task<AdminUser> AddAsync(AdminUser entity)
        {
            throw new NotImplementedException();
        }

        public async Task<AdminUser> CreateAsync(AdminUser adminUser, string password)
        {
            IdentityAdminUser user = new IdentityAdminUser { User = adminUser };
            user.TwoFactorEnabled = true;
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

        public async Task Login(string email, string password)
        {
            //var signInManager = sp.GetRequiredService<SignInManager<TUser>>();

            //var useCookieScheme = (useCookies == true) || (useSessionCookies == true);
            //var isPersistent = (useCookies == true) && (useSessionCookies != true);
            //_signInManager.AuthenticationScheme = IdentityConstants.ApplicationScheme;
            _signInManager.AuthenticationScheme = IdentityConstants.BearerScheme;
            var result = await _signInManager.PasswordSignInAsync(email, password, false, lockoutOnFailure: true);
            //if (result.RequiresTwoFactor)
            //{
            //    if (!string.IsNullOrEmpty(login.TwoFactorCode))
            //    {
            //        result = await _signInManager.TwoFactorAuthenticatorSignInAsync(login.TwoFactorCode, false, false);
            //    }
            //    else if (!string.IsNullOrEmpty(login.TwoFactorRecoveryCode))
            //    {
            //        result = await _signInManager.TwoFactorRecoveryCodeSignInAsync(login.TwoFactorRecoveryCode);
            //    }
            //}
        }

        public Task UpdateAsync(AdminUser entity)
        {
            throw new NotImplementedException();
        }
    }
}
