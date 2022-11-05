using System.ComponentModel.DataAnnotations;

namespace MachineBuildingFactory.Models
{
    public class RegisterViewModel
    {
        [Required]
        [StringLength(20, MinimumLength = 5)]
        public string UserName { get; set; } = null!;

        [Required]
        [EmailAddress]
        [StringLength(60, MinimumLength = 10)]
        public string Email { get; set; } = null!;

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string LastName { get; set; } = null!;

        [Required]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Phone { get; set; } = null!;

        [Required]
        //[StringLength(50, MinimumLength = 2)]
        public string Department { get; set; } = null!;

        [Required]
        [StringLength(5, MinimumLength = 2)]
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
