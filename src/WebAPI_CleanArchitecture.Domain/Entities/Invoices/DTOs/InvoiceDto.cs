// Ignore Spelling: Dto

using WebAPI_CleanArchitecture.Domain.Entities.InvoiceItems.DTOs;

namespace WebAPI_CleanArchitecture.Domain.Entities.Invoices.DTOs
{
    public abstract class BaseInvoiceDto
    {
        public string PoNumber { get; set; } = null!;
    }

    public class CreateInvoiceDto : BaseInvoiceDto
    { 
        public Guid CustomerId { get; set; }
        public ICollection<CreateInvoiceItemDto> PurchasedProducts { get; set; } = null!;
    }

    public class UpdateInvoiceDto : BaseInvoiceDto
    {
        public Guid InvoiceId { get; set; }
    }
}
