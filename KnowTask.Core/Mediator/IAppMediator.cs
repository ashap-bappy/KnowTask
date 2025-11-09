using KnowTask.Core.CQRS;

public interface IAppMediator
{
    Task<TResponse> Send<TResponse>(ICommand<TResponse> command, CancellationToken cToken = default);
    Task<TResponse> Send<TResponse>(IQuery<TResponse> query, CancellationToken cToken = default);
}