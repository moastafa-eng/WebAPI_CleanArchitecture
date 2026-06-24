using WebAPI_CleanArchitecture.Application.Abstraction.Messaging.Commands;
using WebAPI_CleanArchitecture.Domain.Entities.Customers.DTOs;

namespace WebAPI_CleanArchitecture.Application.Features.Customers.Commands.CreateCustomer
{
    public record CreateCustomerCommand(CreateCustomerDto Dto) : ICommand<CustomerResponse>;
}
