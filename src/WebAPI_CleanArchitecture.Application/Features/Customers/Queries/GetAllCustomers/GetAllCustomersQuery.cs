using WebAPI_CleanArchitecture.Application.Abstraction.Messaging.Queries;

namespace WebAPI_CleanArchitecture.Application.Features.Customers.Queries.GetAllCustomers
{
    internal record GetAllCustomersQuery : IQuery<CustomerResponseCollection>;
}
