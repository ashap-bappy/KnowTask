using KnowTask.Core.CQRS;
namespace KnowTask.Core.Mediator;

public interface IAppMediator
{
    Task<TResponse> Send<TResponse>(ICommand<TResponse> command, CancellationToken cToken = default);
    Task<TResponse> Send<TResponse>(IQuery<TResponse> query, CancellationToken cToken = default);
}