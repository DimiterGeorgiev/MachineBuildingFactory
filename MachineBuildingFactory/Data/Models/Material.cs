using System.ComponentModel.DataAnnotations;
using MachineBuildingFactory.Data.Enums;

namespace MachineBuildingFactory.Data.Models
{
    public class Material
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public MaterialNumber MaterialNumber { get; set; }
    }
}