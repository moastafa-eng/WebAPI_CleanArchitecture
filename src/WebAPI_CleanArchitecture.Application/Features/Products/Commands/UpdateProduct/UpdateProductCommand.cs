using WebAPI_CleanArchitecture.Application.Abstraction.Messaging.Commands;
using WebAPI_CleanArchitecture.Domain.Entities.Products.DTOs;

namespace WebAPI_CleanArchitecture.Application.Features.Products.Commands.UpdateProduct
{
    public record UpdateProductCommand(UpdateProductDto Dto, Guid ProductId) : ICommand;
}
