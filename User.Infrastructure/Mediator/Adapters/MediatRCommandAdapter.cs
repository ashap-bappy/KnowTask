using KnowTask.Core.CQRS;
using MediatR;

namespace User.Infrastructure.Mediator.Adapters
{
    public class MediatRCommandAdapter<TResponse>(ICommand<TResponse> command) : IRequest<TResponse>
    {
        public ICommand<TResponse> Command { get; set; } = command;
    }
}
