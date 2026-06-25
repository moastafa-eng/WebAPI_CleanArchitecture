using MediatR;
using Microsoft.EntityFrameworkCore;
using WebAPI_CleanArchitecture.Application.Abstraction.Emailing;
using WebAPI_CleanArchitecture.Domain.Abstraction;
using WebAPI_CleanArchitecture.Domain.Entities.Invoices;
using WebAPI_CleanArchitecture.Domain.Entities.Invoices.Events;

namespace WebAPI_CleanArchitecture.Application.Features.Invoices.Commands.CreateInvoice.EventHandlers
{
    internal sealed class InvoiceCreatedDomainEventHandler(IUnitOfWork _unitOfWork, IEmailService  _emailService)
        : INotificationHandler<InvoiceDomainCreateEvent>
    {
        public async Task Handle(InvoiceDomainCreateEvent notification, CancellationToken cancellationToken)
        {
            // Get Invoice With Target Id
            var invoice = await _unitOfWork.GetRepository<Invoice>()
                .GetAll()
                .Include(i => i.Customer)
                .FirstOrDefaultAsync(i => i.Id == notification.InvoiceId, cancellationToken);


            // Check is invoice null
            if (invoice is null)
                return; // search


            // Update Customer Balance
            invoice.Customer.UpdateBalance(invoice.TotalBalance);

            // Update this Row and Save changes
            _unitOfWork.GetRepository<Invoice>().Update(invoice);
            await _unitOfWork.CommitAsync(cancellationToken);

        }
    }
}
