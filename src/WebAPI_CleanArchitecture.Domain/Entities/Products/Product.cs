using WebAPI_CleanArchitecture.Domain.Abstraction;
using WebAPI_CleanArchitecture.Domain.Entities.Products.DTOs;
using WebAPI_CleanArchitecture.Domain.Entities.Shared;

namespace WebAPI_CleanArchitecture.Domain.Entities.Products
{
    public sealed class Product : BaseEntity
    {
        // << ParameterLess Constructor, Parameterized Constructor >>
        private Product() { }
        private Product(Title description, Money unitPrice, Guid id) : base(id)
        {
            
            Description = description;
            UnitPrice = unitPrice;
        }


        
        // << Value Object Properties >>
        public Title Description { get; private set; } = null!;
        public Money UnitPrice { get; private set; } = null!;



        // << Methods - Factory Design Pattern >>
        public static Product Create(CreateProductDto request)
        => new (new Title (request.Description),
            new Money(request.UnitPrice), Guid.NewGuid()); // Generate New Guid

        public void Update(UpdateProductDto request)
        {
            Description = new Title(request.Description);
            UnitPrice = new Money (request.UnitPrice);
        }
    }
}
