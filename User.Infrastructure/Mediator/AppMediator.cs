using KnowTask.Core.CQRS;
using KnowTask.Core.Mediator;
using MediatR;
using User.Infrastructure.Mediator.Adapters;

namespace User.Infrastructure.Mediator
{
    public class AppMediator(IMediator mediator) : IAppMediator
    {
        private readonly IMediator _mediator = mediator;

        public Task<TResponse> Send<TResponse>(ICommand<TResponse> command, CancellationToken cToken = default)
        {
            return _mediator.Send(new MediatRCommandAdapter<TResponse>(command), cToken);
        }

        public Task<TResponse> Send<TResponse>(IQuery<TResponse> query, CancellationToken cToken = default)
        {
            return _mediator.Send(new MediatRQueryAdapter<TResponse>(query), cToken);
        }
    }
}
