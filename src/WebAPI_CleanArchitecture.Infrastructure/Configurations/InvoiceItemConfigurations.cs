using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAPI_CleanArchitecture.Domain.Entities.InvoiceItems;
using WebAPI_CleanArchitecture.Domain.Entities.InvoiceItems.ValueObjects;
using WebAPI_CleanArchitecture.Domain.Entities.Shared;

namespace YouTubeApiCleanArchitecture.Infrastructure.Configurations;
public class InvoiceItemConfiguration : IEntityTypeConfiguration<InvoiceItem>
{
    public void Configure(EntityTypeBuilder<InvoiceItem> builder)
    {
        builder.Property(item => item.SellPrice)
            .HasConversion(
                sellPrice => sellPrice.value,
                value => new Money(value))
            .IsRequired()
            .HasPrecision(18, 2);

        builder.Property(item => item.TotalPrice)
            .HasConversion(
                totalPrice => totalPrice.value,
                value => new Money(value))
            .IsRequired()
            .HasPrecision(18, 2);

        builder.Property(item => item.Quantity)
            .HasConversion(
                quantity => quantity.value,
                value => new Quantity(value))
            .IsRequired();

        builder.Property(x => x.RowVersion)
           .IsRowVersion();

        builder.Property(item => item.Description)
           .HasConversion(
               description => description.value,
               value => new Title(value))
           .IsRequired()
           .HasMaxLength(45);
    }
}