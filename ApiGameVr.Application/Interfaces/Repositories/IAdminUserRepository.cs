using ApiGameVr.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiGameVr.Application.Interfaces.Repositories
{
    public interface IAdminUserRepository :IRepository<AdminUser>
    {
        public Task<AdminUser> CreateAsync(AdminUser adminUser,string password);
    }
}
