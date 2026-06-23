using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI_CleanArchitecture.Application.Abstraction.Messaging.Commands;

namespace WebAPI_CleanArchitecture.Application.Features.Customers.Commands.RemoveCustomer
{
    public record RemoveCustomerCommand(Guid CustomerId) : ICommand;
}
