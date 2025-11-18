namespace KnowTask.Core.Interfaces.CQRS;

public interface ICommand
{
}
public interface ICommand<TResponse> : ICommand
{
}