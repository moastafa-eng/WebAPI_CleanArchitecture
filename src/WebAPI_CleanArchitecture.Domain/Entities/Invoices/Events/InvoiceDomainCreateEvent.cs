using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI_CleanArchitecture.Domain.Abstraction;

namespace WebAPI_CleanArchitecture.Domain.Entities.Invoices.Events
{
    public record InvoiceDomainCreateEvent(Guid InvoiceId) : IDomainEvent;
}
