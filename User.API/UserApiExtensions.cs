using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace User.API;

public static class UserApiExtensions
{
    public static IServiceCollection AddUserApi(this IServiceCollection services, IConfiguration configuration)
    {
        // Register controllers/endpoints from this module
        services.AddControllers()
            .AddApplicationPart(typeof(AssemblyMarker).Assembly);
        return services;
    }
}