using WebAPI_CleanArchitecture.Application.Abstraction.Messaging.Commands;
using WebAPI_CleanArchitecture.Domain.Abstraction;
using WebAPI_CleanArchitecture.Domain.Entities.Invoices;

namespace WebAPI_CleanArchitecture.Application.Features.Invoices.Commands.RemoveInvoice
{
    internal sealed class RemoveInvoiceCommandHandler(IUnitOfWork _unitOfWork)
        : ICommandHandler<RemoveInvoiceCommand>
    {
        public async Task<Result<NoContentDto>> Handle(RemoveInvoiceCommand request, CancellationToken cancellationToken)
        {
            // Get Invoice By ID
            var invoice = await _unitOfWork.GetRepository<Invoice>().GetByIdAsync(request.InvoiceId, cancellationToken);



            // Check is Invoice Exist or not
            if (invoice is null)
                return Result<NoContentDto>.Fail(404, "Null.Error", $"The invoice with id {request.InvoiceId} is not found!");



            // Delete Target Invoice From Data Base And Save Changes
            _unitOfWork.GetRepository<Invoice>().Delete(invoice);
            await _unitOfWork.CommitAsync(cancellationToken);


            // return Success Message with no content
            return Result<NoContentDto>.Success(204);
            
        }
    }
}
