using WebAPI_CleanArchitecture.Domain.Abstraction;

namespace WebAPI_CleanArchitecture.Domain.Entities.Customers.Events
{
    //===========================================================================
    //inherits from IDomainEvent not INotification Directly, because the Domain
    // layer dose not depend of any libraries
    //===========================================================================
    public record CustomerCreatedDomainEvent(Guid CustomerId) : IDomainEvent;
}
