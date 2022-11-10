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

    }
}
