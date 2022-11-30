namespace MachineBuildingFactory.Models
{
    public class AssemblyViewModel
    {
        public int Id { get; set; }

        public string? Name { get; set; } = null!;

        public string? DrawingNumber { get; set; } = null!;

        public string? Description { get; set; }

        public string? AuthorSignature { get; set; } = null!;

        public string CreatedOn { get; set; } = null!;

        public string? Image { get; set; }

        public string PaintSurface { get; set; } = null!;

        public string OxidizeSurface { get; set; } = null!;

        public string ElectrogalvanizedSurface { get; set; } = null!;

        public string UntreatedSurface { get; set; } = null!;

        public string LaserCutLength { get; set; } = null!;

    }
}
