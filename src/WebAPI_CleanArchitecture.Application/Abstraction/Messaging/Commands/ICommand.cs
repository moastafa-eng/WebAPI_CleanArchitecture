using MediatR;
using WebAPI_CleanArchitecture.Domain.Abstraction;

namespace WebAPI_CleanArchitecture.Application.Abstraction.Messaging.Commands
{
    public interface ICommand : IRequest<Result<NoContentDto>>, IBaseCommand; // for Update of Delete Commands
    public interface ICommand<TResponse> : IRequest<Result<TResponse>>, IBaseCommand where TResponse : IResult;
    public interface IBaseCommand; // market interface
}
