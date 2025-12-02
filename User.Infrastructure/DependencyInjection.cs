using KnowTask.Persistence;
using KnowTask.SharedInfra.Mediator;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using User.Application.Interfaces.Authentication;
using User.Application.Interfaces.Persistence;
using User.Domain.Interfaces;
using User.Infrastructure.Authentication;
using User.Infrastructure.Persistence;
using User.Infrastructure.Repositories;

namespace User.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddUserModule(this IServiceCollection services, IConfiguration configuration)
    {
        // register Application services, e.g. services.AddScoped<IUserService, UserService>();
        // register DbContext if Infrastructure is used (via connection string)
        
        // CQRS handlers
        services.AddModuleHandler(typeof(User.Application.AssemblyMarker).Assembly);
        
        // Repository
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<UserDbContext>());
        services.AddDbContext<UserDbContext>(options =>
        {
            options
                .UseNpgsql(configuration.GetConnectionString("DefaultConnection"))
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();
        });
        
        // Authentication
        services.AddSingleton<IPasswordHasher, BCryptPasswordHasher>();
        services.AddSingleton<ITokenGenerator, SimpleTokenGenerator>();
        
        return services;
    }
}
