using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using ApiGameVr.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using ApiGameVr.Application.Interfaces.Repositories;

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
            services.AddScoped<IUserRepository,UserRepository>();
            return services;
        }
    }
}
