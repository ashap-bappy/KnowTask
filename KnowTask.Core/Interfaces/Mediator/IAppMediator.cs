using KnowTask.Core.Interfaces.CQRS;

namespace KnowTask.Core.Interfaces.Mediator;

public interface IAppMediator
{
    Task Send(ICommand command, CancellationToken cancellationToken = default);
    Task<TResponse> Send<TResponse>(ICommand<TResponse> command, CancellationToken cToken = default);
    Task<TResponse> Send<TResponse>(IQuery<TResponse> query, CancellationToken cToken = default);
}