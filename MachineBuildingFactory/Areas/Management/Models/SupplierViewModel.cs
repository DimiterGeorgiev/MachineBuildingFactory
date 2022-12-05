namespace MachineBuildingFactory.Areas.Management.Models
{
    public class SupplierViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string UrlAddress { get; set; } = null!;
    }
}