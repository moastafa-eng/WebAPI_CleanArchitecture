using WebAPI_CleanArchitecture.Application.Abstraction.Messaging.Commands;
using WebAPI_CleanArchitecture.Domain.Abstraction;
using WebAPI_CleanArchitecture.Domain.Entities.Invoices;

namespace WebAPI_CleanArchitecture.Application.Features.Invoices.Commands.UpdateInvoice
{
    internal sealed class UpdateInvoiceCommandHandler(IUnitOfWork _unitOfWork)
        : ICommandHandler<UpdateInvoiceCommand>
    {
        public async Task<Result<NoContentDto>> Handle(UpdateInvoiceCommand request, CancellationToken cancellationToken)
        {
            // Get Invoice By ID
            var invoice = await _unitOfWork.GetRepository<Invoice>().GetByIdAsync(request.InvoiceId, cancellationToken);



            // Check is Invoice Exist or not
            if (invoice is null)
                return Result<NoContentDto>.Failed(404, "Null.Error", $"The invoice with id {request.InvoiceId} is not found!");

            invoice.Update(request.Dto);

            // Update Invoice And Save Changed On Database]
            _unitOfWork.GetRepository<Invoice>().Update(invoice);
            await _unitOfWork.CommitAsync(cancellationToken, CheckForConcurrency: true);


            // return Success Message with No Content
            return Result<NoContentDto>.Success(204);
        }
    }
}
