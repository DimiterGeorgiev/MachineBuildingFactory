using System.ComponentModel.DataAnnotations;

namespace MachineBuildingFactory.Data.Models
{
    public class Material
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string MaterialNumber { get; set; } = null!;
    }
}