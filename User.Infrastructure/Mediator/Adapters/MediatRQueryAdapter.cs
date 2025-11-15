using KnowTask.Core.CQRS;
using MediatR;

namespace User.Infrastructure.Mediator.Adapters
{
    public class MediatRQueryAdapter<TResponse>(IQuery<TResponse> query) : IRequest<TResponse>
    {
        public IQuery<TResponse> Query { get; set; } = query;
    }
}
