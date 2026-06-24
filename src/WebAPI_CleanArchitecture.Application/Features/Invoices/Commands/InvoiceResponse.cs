using AutoMapper;
using System.Collections.ObjectModel;
using WebAPI_CleanArchitecture.Application.Features.Customers;
using WebAPI_CleanArchitecture.Domain.Abstraction;
using WebAPI_CleanArchitecture.Domain.Entities.Invoices;

namespace WebAPI_CleanArchitecture.Application.Features.Invoices.Commands
{
    // The Response
    public class InvoiceResponse : IResult
    {
        public Guid Id { get; set; }
        public string PoNumber { get; set; } = null!;
        public decimal InvoiceBalance { get; set; }
        public CustomerResponse Customer { get; set; } = null!;
        public ICollection<InvoiceItemResponse> PurchasedProducts { get; set; } = null!;
    }

    
    // The Collection Response
    public class  InvoiceResponseCollection : IResult
    {
        public IReadOnlyCollection<InvoiceResponse> Invoices { get; set; } = null!;
    }


    // Mapping Profile
    public class InvoiceMapper : Profile
    {
        public InvoiceMapper()
        {
            CreateMap<Invoice, InvoiceResponse>()
                .ForMember(dto => dto.PoNumber, opt => opt.MapFrom(ent => ent.PoNumber.value))
                .ForMember(dto => dto.InvoiceBalance, opt => opt.MapFrom(ent => ent.TotalBalance.value));
                //.ForMember(dto => dto.Customer, opt => opt.MapFrom(ent => ent.Customer));
                
        }
    }
}
