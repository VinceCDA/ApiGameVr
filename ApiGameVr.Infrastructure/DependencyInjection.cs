using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using ApiGameVr.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using ApiGameVr.Application.Interfaces.Repositories;
using Microsoft.AspNetCore.Identity;
using ApiGameVr.Infrastructure.Identity.Users;
using ApiGameVr.Infrastructure.Identity.Context;

namespace ApiGameVr.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration
        )
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase("UserTest"));
            services.AddDbContext<AdminDbContext>(options => options.UseInMemoryDatabase("AdminUserTest"));
            services.AddIdentityCore<IdentityAdminUser>().AddEntityFrameworkStores<AdminDbContext>();
            services.AddScoped<IApplicationUserRepository,UserRepository>();
            services.AddScoped<IAdminUserRepository,AdminUserRepository>();
            return services;
        }
    }
}
