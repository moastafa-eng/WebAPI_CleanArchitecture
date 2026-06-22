using WebAPI_CleanArchitecture.Application.Abstraction.Messaging.Commands;
using WebAPI_CleanArchitecture.Domain.Entities.Products.DTOs;

namespace WebAPI_CleanArchitecture.Application.Features.Products.Commands.CreateProduct
{
    public record CreateProductCommand(CreateProductDto Dto) : ICommand<ProductResponse>;
}
