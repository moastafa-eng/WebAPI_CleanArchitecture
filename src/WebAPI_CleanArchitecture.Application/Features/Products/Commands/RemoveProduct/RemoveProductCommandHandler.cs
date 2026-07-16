using WebAPI_CleanArchitecture.Application.Abstraction.Messaging.Commands;
using WebAPI_CleanArchitecture.Domain.Abstraction;
using WebAPI_CleanArchitecture.Domain.Entities.Products;

namespace WebAPI_CleanArchitecture.Application.Features.Products.Commands.RemoveProduct
{
    internal sealed class RemoveProductCommandHandler(IUnitOfWork _unitOfWork)
        : ICommandHandler<RemoveProductCommand>
    {
        public async Task<Result<NoContentDto>> Handle(RemoveProductCommand request, CancellationToken cancellationToken)
        {
            // Get Product by id
            var product = await _unitOfWork.GetRepository<Product>().GetByIdAsync(request.ProductId, cancellationToken);

            // check if product is null return Failed Message with status code 400
            if (product is null)
            {
                return Result<NoContentDto>.Failed(400, "Null.Error", $"The product with id {request.ProductId} is not found");
            }

            // else save changes on Database and return Success with Status code 204
            _unitOfWork.GetRepository<Product>().Delete(product);
            await _unitOfWork.CommitAsync(cancellationToken);

            return Result<NoContentDto>.Success(204);

        }
    }
}

