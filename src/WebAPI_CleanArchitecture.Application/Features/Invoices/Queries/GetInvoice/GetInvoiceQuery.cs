using WebAPI_CleanArchitecture.Application.Abstraction.Messaging.Queries;

namespace WebAPI_CleanArchitecture.Application.Features.Invoices.Queries.GetInvoice
{
    public record GetInvoiceQuery(Guid InvoiceId) : IQuery<InvoiceResponse>;
}
