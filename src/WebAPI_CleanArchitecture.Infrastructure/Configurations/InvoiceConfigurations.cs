using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAPI_CleanArchitecture.Domain.Entities.Invoices;
using WebAPI_CleanArchitecture.Domain.Entities.Invoices.ValueObjects;
using WebAPI_CleanArchitecture.Domain.Entities.Shared;

namespace WebAPI_CleanArchitecture.Infrastructure.Configurations
{
    public class InvoiceConfigurations : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.Property(invoice => invoice.PoNumber)
                .HasConversion(
                poNumber => poNumber.value, value => new PoNumber(value))
                .IsRequired()
                .HasMaxLength(45);

            builder.Property(Invoice => Invoice.TotalBalance)
                .HasConversion(
                totalBalance => totalBalance.value, value => new Money(value))
                .IsRequired()
                .HasPrecision(18, 2);


            builder.HasMany(invoice => invoice.PurchasedProducts)
                .WithOne(invoice => invoice.Invoice)
                .HasForeignKey(invoice => invoice.InvoiceId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(invoice => invoice.RowVersion)
                .IsRowVersion();
        }
    }
}
