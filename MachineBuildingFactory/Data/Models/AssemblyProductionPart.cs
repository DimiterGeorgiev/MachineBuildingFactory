using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MachineBuildingFactory.Data.Models
{
    public class AssemblyProductionPart
    {
        [Required]
        public int AssemblyId { get; set; }

        [ForeignKey(nameof(AssemblyId))]
        public Assembly Assembly { get; set; } = null!;

        [Required]
        public int ProductionPartId { get; set; }

        [ForeignKey(nameof(ProductionPartId))]
        public ProductionPart ProductionPart { get; set; } = null!;

        [Required]
        public int Quantity { get; set; }
    }
}
