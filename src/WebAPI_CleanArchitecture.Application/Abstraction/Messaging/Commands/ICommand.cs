using MediatR;
using WebAPI_CleanArchitecture.Domain.Abstraction;

namespace WebAPI_CleanArchitecture.Application.Abstraction.Messaging.Commands
{
    public interface ICommand : IRequest<Result<NoContentDto>>, IBaseCommand;
    public interface ICommand<TResponse> : IRequest<Result<TResponse>>, IBaseCommand where TResponse : IResult;
    public interface IBaseCommand;
}
