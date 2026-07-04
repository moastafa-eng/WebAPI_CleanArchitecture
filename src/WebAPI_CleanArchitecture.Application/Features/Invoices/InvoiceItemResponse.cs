using AutoMapper;
using WebAPI_CleanArchitecture.Domain.Entities.InvoiceItems;
using WebAPI_CleanArchitecture.Domain.Entities.Invoices;

namespace WebAPI_CleanArchitecture.Application.Features.Invoices
{
    public class InvoiceItemResponse
    {
        public string Description { get; set; } = null!;
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
    }


    public class InvoiceItemMapper : Profile
    {
        public InvoiceItemMapper()
        {
            CreateMap<InvoiceItem, InvoiceItemResponse>()
                .ForMember(dto => dto.Description, opt => opt.MapFrom(ent => ent.Description.value))
                .ForMember(dto => dto.UnitPrice, opt => opt.MapFrom(ent => ent.SellPrice.value))
                .ForMember(dto => dto.Quantity, opt => opt.MapFrom(ent => ent.Quantity.value))
                .ForMember(dto => dto.TotalPrice, opt => opt.MapFrom(ent => ent.TotalPrice.value));

        }
    }
}
