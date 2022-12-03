using System.ComponentModel.DataAnnotations;

namespace MachineBuildingFactory.Models
{
    public class AddPurchasedPartToAssemblyViewModel
    {
        [Required]
        public int currentPurchasedPartId { get; set; }

        [Range(1, 100, ErrorMessage = "Quantity must be between 1 and 100 only!!")]
        public int Quantity { get; set; }
    }
}