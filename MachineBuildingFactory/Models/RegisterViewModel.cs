using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MachineBuildingFactory.Models
{
    public class RegisterViewModel
    {
        [Required]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "User Name must be between 5 and 20 characters")]
        [DisplayName("User Name")]
        public string UserName { get; set; } = null!;

        [Required]
        [EmailAddress]
        [StringLength(60, MinimumLength = 8, ErrorMessage = "Email must be between 8 and 60 characters")]
        [DisplayName("Email")]
        public string Email { get; set; } = null!;

        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "First Name must be between 2 and 50 characters")]
        [DisplayName("First Name")]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Last Name must be between 2 and 50 characters")]
        [DisplayName("Last Name")]
        public string LastName { get; set; } = null!;

        [Required]
        public string Title { get; set; } = null!;

        [Required]
        [Phone]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Phone number must be between 2 and 50 characters")]
        [DisplayName("Phone number")]
        public string Phone { get; set; } = null!;

        [Required]
        public string Department { get; set; } = null!;

        [Required]
        [StringLength(5, MinimumLength = 2, ErrorMessage = "Signature must be between 2 and 5 characters")]
        [DisplayName("Signature")]
        public string Signature { get; set; } = null!;

        [Required]
        [StringLength(20, MinimumLength = 5)] // изискванията към паролата се слага и другаде
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Compare(nameof(Password))]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; } = null!;
    }
}
