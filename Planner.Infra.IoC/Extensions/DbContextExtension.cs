using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Planner.Infra.Data.Data;

namespace Planner.Infra.IoC.Extensions;

public static class DbContextExtension
{
    public static IServiceCollection AddDbContextConfig(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<PlannerDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("PlannerConnection")));
        return services;
    }
}
