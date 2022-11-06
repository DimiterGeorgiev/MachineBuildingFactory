using MachineBuildingFactory.Data.Enums;
using MachineBuildingFactory.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace MachineBuildingFactory.Models
{
    public class CreateProductionPartViewModel
    {
        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(5000, MinimumLength = 5)]
        public string Description { get; set; } = null!;

        [Required]
        [StringLength(200, MinimumLength = 5)]
        public string Image { get; set; } = null!;

        public int TypeOfProductionPartId { get; set; }

        public IEnumerable<TypeOfProductionPart> TypeOfProductionParts { get; set; } = new List<TypeOfProductionPart>();

        [Required]
        public DateTime CreatedOn { get; set; } = DateTime.Now;

        [Required]
        [StringLength(3, MinimumLength = 2)]
        public string AuthorSignature { get; set; } = null!;

        [Required]
        [Range(typeof(double), "0.0", "50.0", ConvertValueInInvariantCulture = true)]
        public double SurfaceArea { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 5)]
        public string DrawingNumber { get; set; } = null!;

        [Required]
        [Range(typeof(double), "0.0", "10.0", ConvertValueInInvariantCulture = true)]
        public double Weight { get; set; }

        public TypeOfSurfaceTreatment? SurfaceTreatment { get; set; }

        public TypeOfPaint? TypeOfPaint { get; set; }

        public ColorOfPaintRal? ColorOfPaintRal { get; set; }

        [Required]
        [Range(typeof(double), "0.0", "10.0", ConvertValueInInvariantCulture = true)]
        public double LaserCutLength { get; set; } = 0;

        public int? MaterialId { get; set; }

        public IEnumerable<Material> Materials { get; set; } = new List<Material>();
    }
}
