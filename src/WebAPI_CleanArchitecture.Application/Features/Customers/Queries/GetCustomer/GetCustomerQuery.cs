using WebAPI_CleanArchitecture.Application.Abstraction.Messaging.Queries;

namespace WebAPI_CleanArchitecture.Application.Features.Customers.Queries.GetCustomer
{
    public record GetCustomerQuery(Guid CustomerId) : IQuery<CustomerResponse>;
}
