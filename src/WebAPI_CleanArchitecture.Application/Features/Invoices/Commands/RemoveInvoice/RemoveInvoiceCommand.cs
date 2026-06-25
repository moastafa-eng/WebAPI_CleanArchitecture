using WebAPI_CleanArchitecture.Application.Abstraction.Messaging.Commands;

namespace WebAPI_CleanArchitecture.Application.Features.Invoices.Commands.RemoveInvoice
{
    public record RemoveInvoiceCommand(Guid InvoiceId) : ICommand;
}
