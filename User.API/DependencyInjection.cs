using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace User.API;

public static class DependencyInjection
{
    public static IServiceCollection AddUserModule(this IServiceCollection services, IConfiguration configuration)
    {
        // register Application services, e.g. services.AddScoped<IUserService, UserService>();
        // register DbContext if Infrastructure is used (via connection string)
        return services;
    }
}
