using System.ComponentModel.DataAnnotations;
using System.Drawing.Imaging;
using MachineBuildingFactory.Data.Enums;

namespace MachineBuildingFactory.Data.Models
{
    public class Paint
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public ColorRal ColorRal { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public TypeOfPaint TypeOfPaint { get; set; } = null!;

    }
}