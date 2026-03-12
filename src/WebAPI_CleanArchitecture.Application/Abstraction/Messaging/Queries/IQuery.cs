using MediatR;
using WebAPI_CleanArchitecture.Domain.Abstraction;

namespace WebAPI_CleanArchitecture.Application.Abstraction.Messaging.Queries
{
    public interface IQuery<TResponse> : IRequest<Result<TResponse>>
        where TResponse : IResult;
}
