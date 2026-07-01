using WebAPI_CleanArchitecture.Application.Abstraction.Messaging.Queries;

namespace WebAPI_CleanArchitecture.Application.Features.Customers.Queries.GetAllCustomers
{
    public record GetAllCustomersQuery : IQuery<CustomerResponseCollection>;
}
