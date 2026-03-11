using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAPI_CleanArchitecture.Domain.Entities.InvoiceItems;
using WebAPI_CleanArchitecture.Domain.Entities.InvoiceItems.ValueObjects;
using WebAPI_CleanArchitecture.Domain.Entities.Shared;

namespace WebAPI_CleanArchitecture.Infrastructure.Configurations
{
    public class InvoiceItemConfigurations : IEntityTypeConfiguration<InvoiceItem>
    {
        public void Configure(EntityTypeBuilder<InvoiceItem> builder)
        {
            builder.Property(invoiceItem => invoiceItem.SellPrice)
                .HasConversion(
                sellPrice => sellPrice.value, value => new Money(value))
                .IsRequired()
                .HasPrecision(18, 2);

            builder.Property(invoiceItem => invoiceItem.Quantity)
                .HasConversion(
                quantity => quantity.value, value => new Quantity(value))
                .IsRequired();

            builder.Property(invoiceItem => invoiceItem.TotalPrice)
                .HasConversion(
                totalPrice => totalPrice.value, value => new Money(value))
                .IsRequired()
                .HasPrecision(18, 2);



            builder.Property(invoiceItem => invoiceItem.RowVersion)
                .IsRowVersion();
        }
    }
}
