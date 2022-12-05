using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MachineBuildingFactory.Areas.Management.Models
{
    public class CreateMaterialViewModel
    {
        [Required]
        [DisplayName("Material Number")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Material Number must be between 3 and 50 characters")]
        public string MaterialNumber { get; set; } = null!;
    }
}