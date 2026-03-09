using WebAPI_CleanArchitecture.Domain.Abstraction;
using WebAPI_CleanArchitecture.Domain.Entities.InvoiceItems.ValueObjects;
using WebAPI_CleanArchitecture.Domain.Entities.Invoices;
using WebAPI_CleanArchitecture.Domain.Entities.Shared;

namespace WebAPI_CleanArchitecture.Domain.Entities.InvoiceItems
{
    public sealed class InvoiceItem : BaseEntity
    {
        internal InvoiceItem(Money sellPrice, Quantity quantity, Guid invoiceId, Guid id) : base(id)
        {
            SellPrice = sellPrice;
            Quantity = quantity;
            TotalPrice = new Money (sellPrice.value * quantity.value);
            InvoiceId = invoiceId;
        }

        // << Properties >>
        public Money SellPrice { get; set; } = null!;
        public Quantity Quantity { get; set; } = null!;
        public Money TotalPrice { get; set; } = null!;


        // << Navigational Properties >>
        public Invoice Invoice { get; set; } = null!;
        public Guid InvoiceId { get; set; } // FK
    }
}
