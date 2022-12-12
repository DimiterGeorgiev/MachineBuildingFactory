using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MachineBuildingFactory.Areas.Management.Models
{
    public class CreateManufacturerViewModel
    {
        [Required]
        [DisplayName("Name")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Manufacturer Name must be between 2 and 50 characters")]
        public string Name { get; set; } = null!;

        [Required]
        [DataType(DataType.EmailAddress)]
        [DisplayName("Email")]
        [StringLength(60, MinimumLength = 5, ErrorMessage = "Email must be between 5 and 60 characters")]
        public string Email { get; set; } = null!;

        [Required]
        [DisplayName("Home page")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Home page must be between 5 and 100 characters")]
        public string UrlAddress { get; set; } = null!;
    }
}