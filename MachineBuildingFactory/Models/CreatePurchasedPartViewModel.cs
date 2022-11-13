using MachineBuildingFactory.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace MachineBuildingFactory.Models
{
    public class CreatePurchasedPartViewModel
    {
        [Required]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Part Name must be between 5 and 50 characters")]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Item Number must be between 5 and 50 characters")]
        public string? ItemNumber { get; set; }

        public int SupplierId { get; set; }

        public IEnumerable<Supplier> Suppliers { get; set; } = new List<Supplier>();

        public int ManufacturerId { get; set; }

        public IEnumerable<Manufacturer> Manufacturers { get; set; } = new List<Manufacturer>();

        [Required]
        [StringLength(5000, MinimumLength = 5, ErrorMessage = "Description must be between 5 and 5000 characters")]
        public string Description { get; set; } = null!;

        [Required]
        [StringLength(200, MinimumLength = 5, ErrorMessage = "Image link must be between 5 and 200 characters")]
        public string Image { get; set; } = null!;

        [Required]
        [Range(typeof(double), "0.0", "500.0", ConvertValueInInvariantCulture = true, ErrorMessage = "Weight must be between 0 and 500 kilograms")]
        public double Weight { get; set; }


        [StringLength(50, MinimumLength = 0, ErrorMessage = "Item Number must be between 0 and 50 characters")]
        public string? Standard { get; set; }

    }
}
