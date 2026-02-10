using ApiGameVr.Domain.Entities;
using Microsoft.AspNetCore.Authentication.BearerToken;
using Microsoft.AspNetCore.Http.HttpResults;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiGameVr.Application.Interfaces.Repositories
{
    public interface IAdminUserRepository :IRepository<AdminUser>
    {
        public Task<AdminUser> CreateAsync(AdminUser adminUser,string password);
        public Task Login(string email,string password);
    }
}
