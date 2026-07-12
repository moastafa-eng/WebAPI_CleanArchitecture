using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAPI_CleanArchitecture.Domain.Entities.Invoices;
using WebAPI_CleanArchitecture.Domain.Entities.Invoices.ValueObjects;
using WebAPI_CleanArchitecture.Domain.Entities.Shared;

namespace YouTubeApiCleanArchitecture.Infrastructure.Configurations;
public class InvoiceConfigurations : IEntityTypeConfiguration<Invoice>
{
    public void Configure(EntityTypeBuilder<Invoice> builder)
    {
        builder.Property(invoice => invoice.PoNumber)
           .HasConversion(
               poNumber => poNumber.value,
               value => new PoNumber(value))
           .IsRequired()
           .HasMaxLength(45);

        builder.Property(invoice => invoice.TotalBalance)
            .HasConversion(
                totalBalance => totalBalance.value,
                value => new Money(value))
            .IsRequired()
            .HasPrecision(18, 2);

        builder.HasMany(invoice => invoice.PurchasedProducts)
            .WithOne(x => x.Invoice)
            .HasForeignKey(x => x.InvoiceId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(invoice => invoice.Customer)
            .WithMany().HasForeignKey(invoice => invoice.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(x => x.RowVersion)
           .IsRowVersion();
    }
}