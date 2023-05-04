using System.ComponentModel.DataAnnotations;

namespace CarWorkshop.Application.CarWorkshop
{
    public class CarWorkshopDto
    {
        [Required]
        [StringLength(20, MinimumLength = 2)]
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        [Required]
        [Phone]
        public string? PhoneNumber { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 2)]
        public string? Street { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 2)]
        public string? City { get; set; }
        [Required]
        [StringLength(10, MinimumLength = 5)]
        [DataType(DataType.PostalCode)]
        public string? PostalCode { get; set; }
    }
}