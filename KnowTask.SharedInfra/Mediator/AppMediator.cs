using KnowTask.Core.Interfaces.CQRS;
using KnowTask.Core.Interfaces.Mediator;
using Microsoft.Extensions.DependencyInjection;

namespace KnowTask.SharedInfra.Mediator;

public sealed class AppMediator(IServiceProvider serviceProvider) : IAppMediator
{
    private readonly IServiceProvider _serviceProvider = serviceProvider;

    public Task Send(ICommand command, CancellationToken cancellationToken = default)
    {
        var handler = _serviceProvider.GetRequiredService<ICommandHandler<ICommand>>();
        return handler.Handle(command, cancellationToken);
    }

    public Task<TResponse> Send<TResponse>(ICommand<TResponse> command, CancellationToken cToken = default)
    {
        var handler = _serviceProvider.GetRequiredService<ICommandHandler<ICommand<TResponse>,  TResponse>>();
        return handler.Handle(command, cToken);
    }

    public Task<TResponse> Send<TResponse>(IQuery<TResponse> query, CancellationToken cToken = default)
    {
        var handler = _serviceProvider.GetRequiredService<IQueryHandler<IQuery<TResponse>,  TResponse>>();
        return handler.Handle(query, cToken);
    }
}