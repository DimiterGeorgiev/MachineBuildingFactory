using System.ComponentModel.DataAnnotations;

namespace MachineBuildingFactory.Data.Models
{
    public class TypeOfProductionPart
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50, MinimumLength = 3)]
        [Required]
        public string Name { get; set; } = null!;
    }
}
