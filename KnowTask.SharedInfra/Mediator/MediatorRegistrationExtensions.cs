using System.Reflection;
using KnowTask.Core.Interfaces.CQRS;
using KnowTask.Core.Interfaces.Mediator;
using Microsoft.Extensions.DependencyInjection;

namespace KnowTask.SharedInfra.Mediator;

public static class MediatorRegistrationExtensions
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddAppMediator()
        {
            services.AddScoped<IAppMediator, AppMediator>();
            return services;
        }

        public IServiceCollection AddModuleHandler(Assembly moduleAssembly)
        {
            var handlerTypes = new []
            {
                typeof(ICommandHandler<>),
                typeof(ICommandHandler<,>),
                typeof(IQueryHandler<,>),
            };

            var handlers = moduleAssembly.GetExportedTypes()
                .Where(t => t is { IsClass: true, IsAbstract: false })
                .SelectMany(t => t.GetInterfaces()
                    .Where(i => i.IsGenericType && handlerTypes.Contains(i.GetGenericTypeDefinition()))
                    .Select(i => new {Interface = i, Implementation = t}))
                .ToArray();

            foreach (var handler in handlers)
            {
                services.AddScoped(handler.Interface, handler.Implementation);
            }
        
            return services;
        }
    }
}