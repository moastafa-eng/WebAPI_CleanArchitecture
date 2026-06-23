using WebAPI_CleanArchitecture.Application.Abstraction.Messaging.Commands;
using WebAPI_CleanArchitecture.Domain.Entities.Customers.DTOs;

namespace WebAPI_CleanArchitecture.Application.Features.Customers.Commands.UpdateCustomer
{
    public record UpdateCustomerCommand(UpdateCustomerDto Dto) : ICommand;
}
