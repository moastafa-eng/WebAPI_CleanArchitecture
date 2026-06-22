using AutoMapper;
using WebAPI_CleanArchitecture.Domain.Abstraction;
using WebAPI_CleanArchitecture.Domain.Entities.Products;

namespace WebAPI_CleanArchitecture.Application.Features.Products
{
    public class ProductResponse : IResult
    {
        public int Id { get; set; }
        public string Description { get; set; } = null!;
        public Decimal UnitPrice { get; set; }
    }

    public class ProductMapper : Profile
    {
        public ProductMapper()
        {
            CreateMap<Product, ProductResponse>()
                .ForMember(dto => dto.Description, opt => opt.MapFrom(ent => ent.Description.value))
                .ForMember(dto => dto.UnitPrice, opt => opt.MapFrom(ent => ent.UnitPrice.value));
        }
    }
}
