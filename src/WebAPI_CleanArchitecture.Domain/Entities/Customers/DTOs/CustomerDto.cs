// Ignore Spelling: Dto

using System.ComponentModel.DataAnnotations;

namespace WebAPI_CleanArchitecture.Domain.Entities.Customers.DTOs
{
    public abstract class BaseCustomerDto
    {
        [Required]
        [MaxLength(45)]
        public string Title { get; set; } = null!;
        [Required]
        [MaxLength(40)]
        public string FirstLineAddress { get; set; } = null!;
        [MaxLength(40)]
        public string? SecondLineAddress { get; set; }
        [Required]
        [MaxLength(10)]
        public string PostCode { get; set; } = null!;
        [Required]
        [MaxLength(20)]
        public string Country { get; set; } = null!;
        [Required]
        [MaxLength(20)]
        public string City { get; set; } = null!;
    }

    public class CreateCustomerDto : BaseCustomerDto;
    public class UpdateCustomerDto : BaseCustomerDto;
}
