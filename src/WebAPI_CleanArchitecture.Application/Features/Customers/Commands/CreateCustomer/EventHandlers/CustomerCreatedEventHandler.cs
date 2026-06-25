using MediatR;
using WebAPI_CleanArchitecture.Application.Abstraction.Emailing;
using WebAPI_CleanArchitecture.Domain.Abstraction;
using WebAPI_CleanArchitecture.Domain.Entities.Customers;
using WebAPI_CleanArchitecture.Domain.Entities.Customers.Events;

namespace WebAPI_CleanArchitecture.Application.Features.Customers.Commands.CreateCustomer.EventHandlers
{
    internal sealed class CustomerCreatedEventHandler(IUnitOfWork _unitOfWork, IEmailService  _emailService)
        : INotificationHandler<CustomerCreatedDomainEvent>
    {
        public async Task Handle(CustomerCreatedDomainEvent notification, CancellationToken cancellationToken)
        {
            var customer = await _unitOfWork.GetRepository<Customer>().GetByIdAsync(notification.CustomerId, cancellationToken);

            if (customer is null)
                return;

            await _emailService.SendAsync();
        }
    }
}
