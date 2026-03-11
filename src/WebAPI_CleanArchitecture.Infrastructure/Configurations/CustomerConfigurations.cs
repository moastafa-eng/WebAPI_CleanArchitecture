using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAPI_CleanArchitecture.Domain.Entities.Customers;
using WebAPI_CleanArchitecture.Domain.Entities.Shared;

namespace WebAPI_CleanArchitecture.Infrastructure.Configurations
{
    public class CustomerConfigurations : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            // Customer table Owns the address record inside it
            builder.OwnsOne(customer => customer.Address, address =>
            {
                address.Property(address => address.FirstLineAddress)
                .IsRequired()
                .HasMaxLength(40);

                address.Property(address => address.SecondLineAddress)
                .HasMaxLength(40);

                address.Property(address => address.PostCode)
                .IsRequired()
                .HasMaxLength(10);

                address.Property(address => address.City)
                .IsRequired()
                .HasMaxLength(20);

                address.Property(address => address.Country)
                .IsRequired()
                .HasMaxLength(20);
            });




            // HasConversion: Maps the Title Value Object to a string in the DB (on save) 
            // and reconstructs it back into a Record (on load).
            builder.Property(customer => customer.Title)
                .HasConversion(
                title => title.value, value => new Title(value))
                .IsRequired()
                .HasMaxLength(45);


            builder.Property(customer => customer.Balance)
                .HasConversion(
                balance => balance.value, value => new Money(value))
                .IsRequired()
                .HasPrecision(18, 2);


            builder.HasMany(customer => customer.Invoices)
                .WithOne(customer => customer.Customer)
                .HasForeignKey(customer => customer.Id)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(customer => customer.RowVersion)
                .IsRowVersion();
        }
    }
}
