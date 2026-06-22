using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using WebAPI_CleanArchitecture.Application.Abstraction.Messaging.Queries;
using WebAPI_CleanArchitecture.Domain.Abstraction;
using WebAPI_CleanArchitecture.Domain.Entities.Products;

namespace WebAPI_CleanArchitecture.Application.Features.Products.Queries.GetAllProducts
{
    internal sealed class GetAllProductsQueryHandler(IUnitOfWork _unitOfWork, IMapper _mapper)
        : IQueryHandler<GetAllProductsQuery, ProductResponseCollection>
    {
        public async Task<Result<ProductResponseCollection>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _unitOfWork.GetRepository<Product>()
                .GetAll().ProjectTo<ProductResponse>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
            //=================================================================================
            // Project to => Get only the requerd Fields from Database Based on PorductResponse
            // by other meaning Database return dto by self and this method is very fast
            //=================================================================================


            // Make Products immutable so the caller can't modify the collection (best practice for DTOs)
            var response = new ProductResponseCollection
            {
                Products = products.AsReadOnly()
            };



            return Result<ProductResponseCollection>.Success(response, 200);
        }
    }
}
