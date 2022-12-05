using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MachineBuildingFactory.Areas.Management.Models
{
    public class CreateTypeOfProductionPartViewModel
    {
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 characters")]
        [Required]
        [DisplayName("Name")]
        public string Name { get; set; } = null!;
    }
}