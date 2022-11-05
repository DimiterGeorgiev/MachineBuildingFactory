using System.ComponentModel.DataAnnotations;

namespace MachineBuildingFactory.Data.Models
{
    public class PurchasedPart
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string? ItemNumber { get; set; }

        [Required]
        public Supplier? Supplier { get; set; }

        [Required]
        public Manufacturer? Manufacturer { get; set; }

        [Required]
        [StringLength(5000, MinimumLength = 5)]
        public string? Description { get; set; }

        [Required]
        public string? Image { get; set; } = null!;

        [Required]
        public double Weight { get; set; }

        [Required]
        public string? Standard { get; set; }


    }
}