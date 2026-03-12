using MediatR;
using WebAPI_CleanArchitecture.Domain.Abstraction;

namespace WebAPI_CleanArchitecture.Application.Abstraction.Messaging.Commands
{
    public interface ICommandHandler<TCommand> : IRequestHandler<TCommand, Result<NoContentDto>>
        where TCommand : ICommand;

    public interface ICommandHandler<TCommand, TResponse> : IRequestHandler<TCommand, Result<TResponse>>
        where TCommand : ICommand<TResponse>
        where TResponse : IResult;
    
}
