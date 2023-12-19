
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Vezeeta.Infrastructure.Data;
namespace Vezeeta.Infrastructure;

public static class InfrastructureExtension
{
    public static IServiceCollection RegisterInfrastructureServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        });

       
        return services;
    }
}
