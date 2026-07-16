// Ignore Spelling: Dto

using System.ComponentModel.DataAnnotations;

namespace WebAPI_CleanArchitecture.Domain.Entities.Products.DTOs
{
    public abstract class BaseProductDto
    {
        [Required]
        [MaxLength(45)]
        public string Description { get; set; } = null!;
        [Required]
        public decimal UnitPrice { get; set; }
    }

    public class CreateProductDto : BaseProductDto;
    public class UpdateProductDto : BaseProductDto;

}
