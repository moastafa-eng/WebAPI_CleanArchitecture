using WebAPI_CleanArchitecture.Application.Abstraction.Messaging.Queries;

namespace WebAPI_CleanArchitecture.Application.Features.Invoices.Queries.GetAllInvoices
{
    public record GetAllInvoicesQuery : IQuery<InvoiceResponseCollection>;
}
