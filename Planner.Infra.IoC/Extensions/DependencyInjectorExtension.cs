using Microsoft.Extensions.DependencyInjection;
using Planner.Application.Application;
using Planner.Application.Interface;
using Planner.Domain.Domain.Interfaces;
using Planner.Domain.Domain.Interfaces.Repositories;
using Planner.Domain.Domain.Interfaces.Services;
using Planner.Domain.Domain.Services;
using Planner.Infra.Data.Repositories;

namespace Planner.Infra.IoC.Extensions;

public static class DependencyInjectorExtension
{
    public static IServiceCollection AddDependencyInjectorConfig(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserApplicationService, UserApplicationService>();
        
        services.AddScoped<ICalendarService, CalendarService>();
        services.AddScoped<ICalendarRepository, CalendarRepository>();
        services.AddScoped<ICalendarApplicationService, CalendarApplicationService>();
        return services;
    }
}
