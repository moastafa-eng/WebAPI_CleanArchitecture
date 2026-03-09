// Ignore Spelling: Dto

namespace WebAPI_CleanArchitecture.Domain.Entities.InvoiceItems.DTOs
{
    public class CreateInvoiceItemDto
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
