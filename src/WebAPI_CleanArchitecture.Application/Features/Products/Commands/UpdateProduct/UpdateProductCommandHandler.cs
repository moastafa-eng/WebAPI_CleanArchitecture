using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI_CleanArchitecture.Application.Abstraction.Messaging.Commands;
using WebAPI_CleanArchitecture.Domain.Abstraction;
using WebAPI_CleanArchitecture.Domain.Entities.Products;

namespace WebAPI_CleanArchitecture.Application.Features.Products.Commands.UpdateProduct
{
    internal sealed class UpdateProductCommandHandler(IUnitOfWork _unitOfWork)
        : ICommandHandler<UpdateProductCommand>
    {
        public async Task<Result<NoContentDto>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            // Get Product by id
            var product = await _unitOfWork.GetRepository<Product>().GetByIdAsync(request.Dto.ProductId);

            // if product is null return Failed message with status code 404;
            if (product is null)
                return Result<NoContentDto>.Fail(404, "Null.Error", $"The product with id {request.Dto.ProductId} is not found");

            // Save changes on Database
            _unitOfWork.GetRepository<Product>().Update(product);
            await _unitOfWork.CommitAsync(cancellationToken);

            // return Success Messages with no content and status code 204
            return Result<NoContentDto>.Success(204);

        }
    }
}
