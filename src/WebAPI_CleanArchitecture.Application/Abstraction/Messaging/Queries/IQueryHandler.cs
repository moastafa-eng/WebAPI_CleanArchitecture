using MediatR;
using WebAPI_CleanArchitecture.Domain.Abstraction;

namespace WebAPI_CleanArchitecture.Application.Abstraction.Messaging.Queries
{
    public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
        where TQuery : IQuery<TResponse>
        where TResponse : IResult;
}