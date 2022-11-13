using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MachineBuildingFactory.Data.Models
{
    public class PurchasedPart
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string? ItemNumber { get; set; }

        [Required]
        public int SupplierId { get; set; }

        [Required]
        [ForeignKey(nameof(SupplierId))]
        public Supplier Supplier { get; set; } = null!;

        [Required]
        public int ManufacturerId { get; set; }

        [Required]
        [ForeignKey(nameof(ManufacturerId))]
        public Manufacturer Manufacturer { get; set; } = null!;

        [Required]
        [StringLength(5000, MinimumLength = 5)]
        public string? Description { get; set; }

        [Required]
        public string? Image { get; set; } = null!;

        [Required]
        public double Weight { get; set; }

        public string? Standard { get; set; }


    }
}