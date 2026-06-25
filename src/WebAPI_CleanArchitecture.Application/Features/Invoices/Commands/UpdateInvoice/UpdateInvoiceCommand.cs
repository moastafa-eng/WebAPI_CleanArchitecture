using WebAPI_CleanArchitecture.Application.Abstraction.Messaging.Commands;
using WebAPI_CleanArchitecture.Domain.Entities.Invoices.DTOs;

namespace WebAPI_CleanArchitecture.Application.Features.Invoices.Commands.UpdateInvoice
{
    public record UpdateInvoiceCommand(UpdateInvoiceDto Dto) : ICommand;
}
