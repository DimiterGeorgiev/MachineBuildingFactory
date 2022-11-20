using MachineBuildingFactory.Data.Enums;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace MachineBuildingFactory.Data.Models
{
    public class ApplicationUser : IdentityUser
    {

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string LastName { get; set; } = null!;

        [Required]
        public Title? Title { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Phone { get; set; } = null!;

        [Required]
        public Department? Department { get; set; }

        [Required]
        [StringLength(5, MinimumLength = 2)]
        public string Signature { get; set; } = null!;

        public List<ApplicationUserAssembly> ApplicationUserAssemblys { get; set; } = new List<ApplicationUserAssembly>();

        public List<ApplicationUserWorkingAssembly> WorkingAssembly { get; set; } = new List<ApplicationUserWorkingAssembly>();

    }
}

