using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAPI_CleanArchitecture.Domain.Entities.Products;
using WebAPI_CleanArchitecture.Domain.Entities.Shared;

namespace WebAPI_CleanArchitecture.Infrastructure.Configurations
{
    public class ProductConfigurations : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(product => product.Description)
                .HasConversion(
                description => description.value, value => new Title(value))
                .IsRequired()
                .HasMaxLength(45);

            builder.Property(product => product.UnitPrice)
                .HasConversion(unitPrice => unitPrice.value, value => new Money(value))
                .IsRequired()
                .HasPrecision(18, 2);

            builder.Property(product => product.RowVersion)
                .IsRowVersion();
        }
    }
}
