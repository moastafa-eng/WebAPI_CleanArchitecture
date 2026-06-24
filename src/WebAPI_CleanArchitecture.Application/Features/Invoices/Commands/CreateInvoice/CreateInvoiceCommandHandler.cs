using AutoMapper;
using WebAPI_CleanArchitecture.Application.Abstraction.Messaging.Commands;
using WebAPI_CleanArchitecture.Domain.Abstraction;
using WebAPI_CleanArchitecture.Domain.Entities.Invoices;

namespace WebAPI_CleanArchitecture.Application.Features.Invoices.Commands.CreateInvoice
{
    internal sealed class CreateInvoiceCommandHandler(IUnitOfWork _unitOfWork, IMapper _mapper)
        : ICommandHandler<CreateInvoiceCommand, InvoiceResponse>
    {
        public async Task<Result<InvoiceResponse>> Handle(CreateInvoiceCommand request, CancellationToken cancellationToken)
        {
            //Create Invoice =>
            var invoice = await Invoice.Create(request.Dto, _unitOfWork);

            // save Invoice in the Database and saveChanges =>
            await _unitOfWork.GetRepository<Invoice>().CreateAsync(invoice, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);

            
            // Do Mapping =>
            var response = _mapper.Map<InvoiceResponse>(invoice);


            // return Result =>
            return Result<InvoiceResponse>.Success(response, 201);
        }
    }
}
