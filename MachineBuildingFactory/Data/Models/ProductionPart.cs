using MachineBuildingFactory.Data.Enums;
using Microsoft.EntityFrameworkCore.Storage;
using System.ComponentModel.DataAnnotations;

namespace MachineBuildingFactory.Data.Models
{
    public class ProductionPart
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string SecondTitle { get; set; } = null!;

        [Required]
        [StringLength(5000, MinimumLength = 5)]
        public string Description { get; set; } = null!;

        [Required]
        public string Image { get; set; } = null!;

        [Required]
        public TypeOfProductionPart TypeOfProductionPart { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        public string AuthorSignature { get; set; } = null!;

        [Required]
        public double Surface { get; set; }

        [Required]
        public string DrawingNumber { get; set; } = null!;

        [Required]
        public double Weight { get; set; }

        public TypeOfSurfaceTreatment? SurfaceTreatment { get; set; }

        public TypeOfPaint? TypeOfPaint { get; set; }

        public ColorOfPaintRal? ColorOfPaintRal { get; set; }

        public double? LaserCutLength { get; set; }

        [Required]
        public Material Material { get; set; } = null!;



    }
}
