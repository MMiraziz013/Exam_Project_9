using Clean.Application.Abstractions;
using Clean.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Clean.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddTransient<IStudentService, StudentService>();
        
        return services;
    }
}