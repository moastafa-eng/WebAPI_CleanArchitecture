using AutoMapper;
using WebAPI_CleanArchitecture.Domain.Abstraction;
using WebAPI_CleanArchitecture.Domain.Entities.Customers;
using WebAPI_CleanArchitecture.Domain.Entities.Customers.ValueObjects;

namespace WebAPI_CleanArchitecture.Application.Features.Customers
{
    public class CustomerResponse : IResult
    {
        public Guid Id { get; private set; }
        public string Title { get; private set; } = null!;
        public Address Address { get; private set; } = null!;
        public decimal Balance { get; private set; }

    }

    public class CustomerResponseCollection : IResult
    {
        public IReadOnlyCollection<CustomerResponse> Customers { get; set; } = null!;
    }

    public class CustomerMapper : Profile
    {
        public CustomerMapper()
        {
            CreateMap<Customer, CustomerResponse>()
                .ForMember(dto => dto.Title, opt => opt.MapFrom(ent => ent.Title.value))
                .ForMember(dto => dto.Balance, opt => opt.MapFrom(ent => ent.Balance.value));
        }
    }
}
