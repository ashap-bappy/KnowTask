using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace User.API;

public static class UserApiExtensions
{
    public static IServiceCollection AddUserApi(this IServiceCollection services, IConfiguration configuration)
    {
        // Register controllers/endpoints from this module
        /*
            * AssemblyMarker → dummy class inside each *.API to identify the assembly.
            * AddApplicationPart → tells ASP.NET Core to look for controllers in those assemblies.
        */
        services.AddControllers()
            .AddApplicationPart(typeof(AssemblyMarker).Assembly);
        return services;
    }
}