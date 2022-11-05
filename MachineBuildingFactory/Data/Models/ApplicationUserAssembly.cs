using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MachineBuildingFactory.Data.Models
{
    public class ApplicationUserAssembly
    {
        [Required]
        public string ApplicationUserId { get; set; } = null!;

        [ForeignKey(nameof(ApplicationUserId))]
        public ApplicationUser ApplicationUser { get; set; } = null!;

        [Required]
        public int AssemblyId { get; set; }

        [ForeignKey(nameof(AssemblyId))]
        public Assembly Assembly { get; set; } = null!;

    }
}