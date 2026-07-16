using AutoMapper;
using WebAPI_CleanArchitecture.Application.Abstraction.Messaging.Queries;
using WebAPI_CleanArchitecture.Domain.Abstraction;
using WebAPI_CleanArchitecture.Domain.Entities.Products;

namespace WebAPI_CleanArchitecture.Application.Features.Products.Queries.GetProduct
{
    internal sealed class GetProductQueryHandler(IUnitOfWork _unitOfWork, IMapper _mapper)
        : IQueryHandler<GetProductQuery, ProductResponse>
    {
        public async Task<Result<ProductResponse>> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var product = await _unitOfWork.GetRepository<Product>().GetByIdAsync(request.ProductId);

            if (product is null)
                return Result<ProductResponse>.Failed(400, "Null.Error", $"The Product with Id {request.ProductId} is not found");

            var response = _mapper.Map<ProductResponse>(product);

            return Result<ProductResponse>.Success(response,200);
        }
    }
}
