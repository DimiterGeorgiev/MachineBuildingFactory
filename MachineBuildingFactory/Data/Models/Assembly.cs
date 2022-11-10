using System.ComponentModel.DataAnnotations;

namespace MachineBuildingFactory.Data.Models
{
    public class Assembly
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(15, MinimumLength = 5)]
        public string DrawingNumber { get; set; } = null!;

        [Required]
        public DateTime CreatedOn { get; set; } = DateTime.Now;

        [Required]
        [StringLength(3, MinimumLength = 2)]
        public string AuthorSignature { get; set; } = null!;

        [Required]
        [StringLength(5000, MinimumLength = 5)]
        public string? Description { get; set; }

        [Required]
        public string? Image { get; set; }

        public List<AssemblyProductionPart> AssemblyProductionParts { get; set; } = new List<AssemblyProductionPart>();

        public List<AssemblyPurchasedPart> AssemblyPurchаsedParts { get; set; } = new List<AssemblyPurchasedPart>();

    }
}
