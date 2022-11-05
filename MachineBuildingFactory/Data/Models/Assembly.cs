using System.ComponentModel.DataAnnotations;

namespace MachineBuildingFactory.Data.Models
{
    public class Assembly
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string SecondTitle { get; set; } = null!;

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string ProjectNummber { get; set; } = null!;

        [Required]
        [StringLength(5000, MinimumLength = 5)]
        public string Description { get; set; } = null!;

        [Required]
        public string Image { get; set; } = null!;

        [Required]
        public List<AssemblyProductionPart> AssemblyProductionParts { get; set; } = null!;

        [Required]
        public List<AssemblyPurchasedPart> AssemblyPurchаsedParts { get; set; } = null!;

    }
}
