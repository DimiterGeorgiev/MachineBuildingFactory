using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MachineBuildingFactory.Data.Models
{
    public class Part
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Author { get; set; } = null!;

        [Required]
        [StringLength(5000, MinimumLength = 5)]
        public string Description { get; set; } = null!;

        [Required]
        public string Image { get; set; } = null!;

        public int? TypeOfPartId { get; set; }

        [ForeignKey(nameof(TypeOfPartId))]
        public TypeOfPart? TypeOfPart { get; set; }

        public int? TypeOfProductionPartId { get; set; }

        [ForeignKey(nameof(TypeOfProductionPartId))]
        public TypeOfProductionPart? TypeOfProductionPart { get; set; }

        public DateTime CreatedOn { get; set; }

        public string OwnerId { get; set; } = null!;

        [Required]
        public double Surface { get; set; }

        [Required]
        public string DrawingNumber { get; set; } = null!;

        [Required]
        public double Weight { get; set; }







    }
}
