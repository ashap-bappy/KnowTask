using KnowTask.SharedInfra.Mediator;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace User.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddUserModule(this IServiceCollection services, IConfiguration configuration)
    {
        // register Application services, e.g. services.AddScoped<IUserService, UserService>();
        // register DbContext if Infrastructure is used (via connection string)
        services.AddModuleHandler(typeof(User.Application.AssemblyMarker).Assembly);
        return services;
    }
}
