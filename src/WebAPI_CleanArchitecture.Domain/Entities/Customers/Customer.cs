using WebAPI_CleanArchitecture.Domain.Abstraction;
using WebAPI_CleanArchitecture.Domain.Entities.Customers.ValueObject;
using WebAPI_CleanArchitecture.Domain.Entities.Shared;
using WebAPI_CleanArchitecture.Domain.Entities.Customers.Events;
using WebAPI_CleanArchitecture.Domain.Entities.Customers.DTOs;

namespace WebAPI_CleanArchitecture.Domain.Entities.Customers
{
    public sealed class Customer : BaseEntity
    {
        private Customer(Title title, Address address, Money balance)
        {
            Title = title;
            Address = address;
            Balance = balance;
        }


        // << Empty Constructor For EFCore >>
        private Customer() { }



        // << Properties >>
        // => the value objects like Money gives Semantic meaning to the property in a class
        public Title Title { get; private set; } = null!;
        public Address Address { get; private set; } = null!;
        public Money Balance { get; private set; } = null!;



        // << Factory Design Pattern >>
        public static Customer Create(CreateCustomerDto request)
        {
            var customer = new Customer
                (new Title(request.Title),

                new Address
                (request.City,
                request.FirstLineAddress,
                request.SecondLineAddress,
                request.Country,
                request.PostCode),

                new Money(0));

            customer.RaiseDomainEvent(new CustomerCreatedDomainEvent(customer.Id));
            return customer;
        }
    }
}
