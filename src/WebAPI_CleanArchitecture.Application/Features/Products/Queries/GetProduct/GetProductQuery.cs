using WebAPI_CleanArchitecture.Application.Abstraction.Messaging.Queries;

namespace WebAPI_CleanArchitecture.Application.Features.Products.Queries.GetProduct
{
    // i will set this Id from ProductController
    public record GetProductQuery(Guid ProductId) : IQuery<ProductResponse>;
}
