using System.Collections.Concurrent;
using KnowTask.Core.Interfaces.CQRS;
using KnowTask.Core.Interfaces.Mediator;
using Microsoft.Extensions.DependencyInjection;

namespace KnowTask.SharedInfra.Mediator;

public sealed class AppMediator(IServiceProvider serviceProvider) : IAppMediator
{
    private static readonly ConcurrentDictionary<Type, object> CommandHandlers = new();
    private static readonly ConcurrentDictionary<Type, object> QueryHandlers = new();
    public Task Send(ICommand command, CancellationToken cToken = default)
    {
        ArgumentNullException.ThrowIfNull(command);
        
        var commandType = command.GetType();
        var handler = (ICommandHandler<ICommand>)CommandHandlers.GetOrAdd(commandType, static (type, sp) =>
        {
            var handlerType = typeof(ICommandHandler<>).MakeGenericType(type);
            return sp.GetRequiredService(handlerType);
        }, serviceProvider);
        
        return handler.Handle(command, cToken);
    }

    public Task<TResponse> Send<TResponse>(ICommand<TResponse> command, CancellationToken cToken = default)
    {
        ArgumentNullException.ThrowIfNull(command);
        
        var commandType = command.GetType();
        var handler = (ICommandHandler<ICommand<TResponse>, TResponse>)CommandHandlers.GetOrAdd(commandType, static (type, sp) =>
        {
            var handlerType = typeof(ICommandHandler<,>).MakeGenericType(type);
            return sp.GetRequiredService(handlerType);
        }, serviceProvider);
        
        return handler.Handle(command, cToken);
    }

    public Task<TResponse> Send<TResponse>(IQuery<TResponse> query, CancellationToken cToken = default)
    {
        ArgumentNullException.ThrowIfNull(query);
        
        var commandType = query.GetType();
        var handler = (IQueryHandler<IQuery<TResponse>, TResponse>)QueryHandlers.GetOrAdd(commandType, static (type, sp) =>
        {
            var handlerType = typeof(IQueryHandler<,>).MakeGenericType(type);
            return sp.GetRequiredService(handlerType);
        }, serviceProvider);
        
        return handler.Handle(query, cToken);
    }
}