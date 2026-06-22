using WebAPI_CleanArchitecture.Application.Abstraction.Messaging.Queries;

namespace WebAPI_CleanArchitecture.Application.Features.Products.Queries.GetProduct
{
    public record GetProductQuery(Guid ProductId) : IQuery<ProductResponse>;
}
