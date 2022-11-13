using MachineBuildingFactory.Data.Models;
using MachineBuildingFactory.Models;

namespace MachineBuildingFactory.Contracts
{
    public interface IPurchasedPartService
    {
        Task<IEnumerable<PurchasedPartViewModel>> GetAllPurchasedPartsAsync();

        Task<IEnumerable<Manufacturer>> GetManufactursAsync();

        Task<IEnumerable<Supplier>> GetSuppliersAsync();

        Task CreatePurchasedPartAsync(CreatePurchasedPartViewModel model);
    }
}
