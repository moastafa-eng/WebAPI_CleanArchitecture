using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebAPI_CleanArchitecture.Application.Features.Invoices.Commands.CreateInvoice;
using WebAPI_CleanArchitecture.Application.Features.Invoices.Commands.RemoveInvoice;
using WebAPI_CleanArchitecture.Application.Features.Invoices.Commands.UpdateInvoice;
using WebAPI_CleanArchitecture.Application.Features.Invoices.Queries.GetAllInvoices;
using WebAPI_CleanArchitecture.Application.Features.Invoices.Queries.GetInvoice;
using WebAPI_CleanArchitecture.Domain.Entities.Invoices.DTOs;

namespace WebAPI_CleanArchitecture.APIs.Controllers.VersionOne.Invoices
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoicesController(ISender _sender) : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> CreateInvoice(CreateInvoiceDto request, CancellationToken cancellationToken = default)
        {
            // Send the Message(request) to the handler then return a response using ISender

            var response = await _sender.Send(new CreateInvoiceCommand(request), cancellationToken);

            return CreateResult(response);

        }

        [HttpGet("{InvoiceId}")]
        public async Task<IActionResult> GetInvoice(Guid invoiceId, CancellationToken cancellationToken = default)
        {
            var response = await _sender.Send(new GetInvoiceQuery(invoiceId), cancellationToken);

            return CreateResult(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllInvoices(CancellationToken cancellationToken = default)
        {
            var response = await _sender.Send(new GetAllInvoicesQuery(), cancellationToken);

            return CreateResult(response);
        }

        [HttpPut("{invoiceId}")]
        public async Task<IActionResult> UpdateInvoice(UpdateInvoiceDto request, Guid invoiceId, CancellationToken cancellationToken = default)
        {
            var response = await _sender.Send(new UpdateInvoiceCommand(request, invoiceId), cancellationToken);

            return CreateResult(response);
        }

        [HttpDelete("{invoiceId}")]
        public async Task<IActionResult> DeleteInvoice(Guid invoiceId, CancellationToken cancellationToken = default)
        {
            var response = await _sender.Send(new RemoveInvoiceCommand(invoiceId), cancellationToken);

            return CreateResult(response);
        }
    }
}
