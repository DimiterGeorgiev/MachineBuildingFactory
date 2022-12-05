using System.ComponentModel.DataAnnotations;

namespace MachineBuildingFactory.Models
{
    public class CreateAssemblyViewModel
    {
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Assembly Name must be between 3 and 50 characters")]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(15, MinimumLength = 5, ErrorMessage = "Drawing Number must be between 5 and 15 characters")]
        public string DrawingNumber { get; set; } = null!;

        [Required]
        [StringLength(5000, MinimumLength = 5, ErrorMessage = "Description must be between 5 and 5000 characters")]
        public string Description { get; set; } = null!;

        [Required]
        [Url]
        [StringLength(200, MinimumLength = 5, ErrorMessage = "Image link must be between 5 and 200 characters")]
        public string Image { get; set; } = null!;

        [Required]
        [StringLength(3, MinimumLength = 2, ErrorMessage = "Author Signature must be between 2 and 3 characters")]
        public string AuthorSignature { get; set; } = null!;
    }
}
