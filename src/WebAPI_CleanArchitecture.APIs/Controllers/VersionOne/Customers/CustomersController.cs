using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebAPI_CleanArchitecture.Application.Features.Customers.Commands.CreateCustomer;
using WebAPI_CleanArchitecture.Application.Features.Customers.Commands.RemoveCustomer;
using WebAPI_CleanArchitecture.Application.Features.Customers.Commands.UpdateCustomer;
using WebAPI_CleanArchitecture.Application.Features.Customers.Queries.GetAllCustomers;
using WebAPI_CleanArchitecture.Application.Features.Customers.Queries.GetCustomer;
using WebAPI_CleanArchitecture.Domain.Entities.Customers.DTOs;

namespace WebAPI_CleanArchitecture.APIs.Controllers.VersionOne.Customers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController(ISender _sender) : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> CreateCustomer(CreateCustomerDto request, CancellationToken cancellationToken = default)
        {
            // Send the Message(request) to the handler then return a response using ISender

            var response = await _sender.Send(new CreateCustomerCommand(request), cancellationToken);

            return CreateResult(response);

        }

        [HttpGet("{customerId}")] 
        public async Task<IActionResult> GetCustomer(Guid customerId, CancellationToken cancellationToken = default)
        {
            var response = await _sender.Send(new GetCustomerQuery(customerId), cancellationToken);

            return CreateResult(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCustomers(CancellationToken cancellationToken = default)
        {
            var response = await _sender.Send(new GetAllCustomersQuery(), cancellationToken);

            return CreateResult(response);
        }

        [HttpPut("{customerId}")]
        public async Task<IActionResult> UpdateCustomer(UpdateCustomerDto request, Guid customerId ,CancellationToken cancellationToken = default)
        {
            var response = await _sender.Send(new UpdateCustomerCommand(request, customerId), cancellationToken);

            return CreateResult(response);
        }

        [HttpDelete("{customerId}")]
        public async Task<IActionResult> DeleteCustomer(Guid customerId ,CancellationToken cancellationToken = default)
        {
            var response = await _sender.Send(new RemoveCustomerCommand(customerId), cancellationToken);

            return CreateResult(response);
        }
    }
}
