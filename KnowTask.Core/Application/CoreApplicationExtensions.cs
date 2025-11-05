using Microsoft.Extensions.DependencyInjection;

namespace KnowTask.Core.Application
{
    public static class CoreApplicationExtensions
    {
        public static IServiceCollection AddCoreApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
            });
            return services;
        }
    }
}
