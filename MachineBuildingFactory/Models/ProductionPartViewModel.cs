namespace MachineBuildingFactory.Models
{
    public class ProductionPartViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string Image { get; set; } = null!;

        public string TypeOfProductionPart { get; set; } = null!;

        public string CreatedOn { get; set; } = null!;

        public string AuthorSignature { get; set; } = null!;

        public string SurfaceArea { get; set; } = null!;

        public string DrawingNumber { get; set; } = null!;

        public string Weight { get; set; } = null!;

        public string? SurfaceTreatment { get; set; } = null!;

        public string? TypeOfPaint { get; set; } = null!;

        public string? ColorOfPaintRal { get; set; } = null!;

        public string LaserCutLength { get; set; } = null!;

        public string Material { get; set; } = null!;

    }
}
