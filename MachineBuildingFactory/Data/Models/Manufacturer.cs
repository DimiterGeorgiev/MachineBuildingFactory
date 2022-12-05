using System.ComponentModel.DataAnnotations;

namespace MachineBuildingFactory.Data.Models
{
    public class Manufacturer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; } = null!;

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;

        [Required]
        [StringLength(100, MinimumLength = 5)]
        public string UrlAddress { get; set; } = null!;
    }
}