﻿using MachineBuildingFactory.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MachineBuildingFactory.Data.Models
{
    public class ProductionPart
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(5000, MinimumLength = 5)]
        public string Description { get; set; } = null!;

        [Required]
        public string Image { get; set; } = null!;

        public int? TypeOfProductionPartId { get; set; }

        [Required]
        [ForeignKey(nameof(TypeOfProductionPartId))]
        public TypeOfProductionPart TypeOfProductionPart { get; set; } = null!;

        [Required]
        public DateTime CreatedOn { get; set; } = DateTime.Now;

        public string AuthorSignature { get; set; } = null!;

        [Required]
        public double SurfaceArea { get; set; }

        [Required]
        public string DrawingNumber { get; set; } = null!;

        [Required]
        public double Weight { get; set; }

        public TypeOfSurfaceTreatment? SurfaceTreatment { get; set; }

        public TypeOfPaint? TypeOfPaint { get; set; }

        public ColorOfPaintRal? ColorOfPaintRal { get; set; }

        public double LaserCutLength { get; set; } = 0;

        public int? MaterialId { get; set; }

        [Required]
        [ForeignKey(nameof(MaterialId))]
        public Material Material { get; set; } = null!;

    }
}
