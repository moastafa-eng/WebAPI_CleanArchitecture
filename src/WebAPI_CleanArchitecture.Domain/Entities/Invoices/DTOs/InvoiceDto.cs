// Ignore Spelling: Dto

using System.ComponentModel.DataAnnotations;
using WebAPI_CleanArchitecture.Domain.Entities.InvoiceItems.DTOs;

namespace WebAPI_CleanArchitecture.Domain.Entities.Invoices.DTOs
{
    public abstract class BaseInvoiceDto
    {
        [Required]
        [MaxLength(45)]
        public string PoNumber { get; set; } = null!;
    }

    public class CreateInvoiceDto : BaseInvoiceDto
    {
        [Required]
        public Guid CustomerId { get; set; }
        [Required]
        public ICollection<CreateInvoiceItemDto> PurchasedProducts { get; set; } = null!;
    }

    public class UpdateInvoiceDto : BaseInvoiceDto { }
}
