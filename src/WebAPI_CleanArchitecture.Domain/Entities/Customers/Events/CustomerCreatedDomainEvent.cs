using WebAPI_CleanArchitecture.Domain.Abstraction;

namespace WebAPI_CleanArchitecture.Domain.Entities.Customers.Events
{
    public record CustomerCreatedDomainEvent(Guid customerId) : IDomainEvent;
}
