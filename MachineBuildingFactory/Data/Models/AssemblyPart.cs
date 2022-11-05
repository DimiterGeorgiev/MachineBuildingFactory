using Microsoft.AspNetCore.Razor.Language.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MachineBuildingFactory.Data.Models
{
    public class AssemblyPart
    {
        [Required]
        public int AssemblyId { get; set; }

        public Assembly Assembly { get; set; } = null!;

        [Required]
        public int PartId { get; set; }

        [ForeignKey(nameof(PartId))]
        public Part Part { get; set; } = null!;
    }
}
