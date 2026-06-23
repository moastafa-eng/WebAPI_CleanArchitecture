using AutoMapper;
using WebAPI_CleanArchitecture.Application.Abstraction.Messaging.Commands;
using WebAPI_CleanArchitecture.Domain.Abstraction;
using WebAPI_CleanArchitecture.Domain.Entities.Products;

namespace WebAPI_CleanArchitecture.Application.Features.Products.Commands.CreateProduct
{
    internal sealed class CreateProductCommandHandler (IUnitOfWork _unitOfWork, IMapper _mapper)
        : ICommandHandler<CreateProductCommand, ProductResponse>
    {
        public async Task<Result<ProductResponse>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            // Create a new Product
            var product = Product.Create(request.Dto);

            // Save changes on Database
            await _unitOfWork.GetRepository<Product>().CreateAsync(product, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);

            // Mapping
            var response = _mapper.Map<ProductResponse>(product);

            // return response with success code, using Result Design Pattern
            return Result<ProductResponse>.Success(response, 201);
        }
    }
}
