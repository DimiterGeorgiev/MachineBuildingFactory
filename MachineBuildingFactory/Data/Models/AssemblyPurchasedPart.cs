using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MachineBuildingFactory.Data.Models
{
    public class AssemblyPurchasedPart
    {
        [Required]
        public int AssemblyId { get; set; }

        [ForeignKey(nameof(AssemblyId))]
        public Assembly Assembly { get; set; } = null!;

        [Required]
        public int PurchasedPartId { get; set; }

        [ForeignKey(nameof(PurchasedPartId))]
        public PurchasedPart PurchasedPart { get; set; } = null!;

        [Required]
        public int Quantity { get; set; }
    }
}
