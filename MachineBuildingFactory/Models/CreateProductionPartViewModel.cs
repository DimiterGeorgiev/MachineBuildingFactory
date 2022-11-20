using MachineBuildingFactory.Data.Enums;
using MachineBuildingFactory.Data.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MachineBuildingFactory.Models
{
    public class CreateProductionPartViewModel
    {
        [Required]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Part Name must be between 5 and 50 characters")]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(5000, MinimumLength = 5, ErrorMessage = "Description must be between 5 and 5000 characters")]
        public string Description { get; set; } = null!;

        [Required]
        [Url]
        [StringLength(200, MinimumLength = 5, ErrorMessage = "Image link must be between 5 and 200 characters")]
        public string Image { get; set; } = null!;

        public int TypeOfProductionPartId { get; set; }

        public IEnumerable<TypeOfProductionPart> TypeOfProductionParts { get; set; } = new List<TypeOfProductionPart>();

        [Required]
        public DateTime CreatedOn { get; set; } = DateTime.Now;

        [Required]
        [StringLength(3, MinimumLength = 2, ErrorMessage = "Author signature must be between 2 and 3 characters")]
        [DisplayName("Author signature")]
        public string AuthorSignature { get; set; } = null!;

        [Required]
        [DisplayName("Surface area")]
        [Range(typeof(double), "0.0", "50.0", ConvertValueInInvariantCulture = true, ErrorMessage = "Surface area must be between 0 and 50 square meters")]
        public double SurfaceArea { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 5, ErrorMessage = "Drawing Number must be between 5 and 15 characters")]
        public string DrawingNumber { get; set; } = null!;

        [Required]
        [Range(typeof(double), "0.0", "500.0", ConvertValueInInvariantCulture = true, ErrorMessage = "Weight must be between 0 and 500 kilograms")]
        public double Weight { get; set; }

        public TypeOfSurfaceTreatment? SurfaceTreatment { get; set; }

        public TypeOfPaint? TypeOfPaint { get; set; }

        public ColorOfPaintRal? ColorOfPaintRal { get; set; }

        [Required]
        [Range(typeof(double), "0.0", "200.0", ConvertValueInInvariantCulture = true, ErrorMessage = "Lasecut length must be between 0 and 200 meters")]
        public double LaserCutLength { get; set; } = 0;


        public int? MaterialId { get; set; }

        public IEnumerable<Material> Materials { get; set; } = new List<Material>();
    }
}
