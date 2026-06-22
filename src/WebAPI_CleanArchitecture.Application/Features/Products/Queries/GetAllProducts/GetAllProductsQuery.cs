using WebAPI_CleanArchitecture.Application.Abstraction.Messaging.Queries;

namespace WebAPI_CleanArchitecture.Application.Features.Products.Queries.GetAllProducts
{
    //============================================================================================
    // I make ProductResponseCollection because IQeary takes TResponse where TResponse is TResult 
    // so i created this class and make it inheritance from TResult.
    //============================================================================================
    public class GetAllProductsQuery : IQuery<ProductResponseCollection>;
}
