using WebAPI_CleanArchitecture.Domain.Abstraction;
using WebAPI_CleanArchitecture.Domain.Entities.InvoiceItems.ValueObjects;
using WebAPI_CleanArchitecture.Domain.Entities.Invoices;
using WebAPI_CleanArchitecture.Domain.Entities.Shared;

namespace WebAPI_CleanArchitecture.Domain.Entities.InvoiceItems
{
    public sealed class InvoiceItem : BaseEntity
    {
        internal InvoiceItem(Money sellPrice, Quantity quantity, Guid invoiceId, Guid id, Title description) : base(id)
        {
            Description = description;
            SellPrice = sellPrice;
            Quantity = quantity;
            TotalPrice = new Money (sellPrice.value * quantity.value);
            InvoiceId = invoiceId;
        }

        // << Properties >>
        public Title Description { get; private set; } = null!;
        public Money SellPrice { get; private set; } = null!;
        public Quantity Quantity { get; private set; } = null!;
        public Money TotalPrice { get; private set; } = null!;


        // << Navigational Properties >>
        public Invoice Invoice { get; private set; } = null!;
        public Guid InvoiceId { get; private set; } // FK
    }
}
