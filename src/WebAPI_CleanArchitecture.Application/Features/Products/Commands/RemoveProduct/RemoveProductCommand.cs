
using WebAPI_CleanArchitecture.Application.Abstraction.Messaging.Commands;

namespace WebAPI_CleanArchitecture.Application.Features.Products.Commands.RemoveProduct
{
    public record RemoveProductCommand(Guid ProductId) : ICommand;
}
