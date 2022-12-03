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

        Task<EditPurchasedPartViewModel> GetPurchasedPartForEditAsync(int purchasedPartId);

        Task EditPurchasedPartAsync(EditPurchasedPartViewModel model);

        Task DeleteAsync(int productionPartId);

        Task AddPurchasedPartToAssemblyAsync(int purchasedPartId, int assemblyId, int quantity);

        Task<AddPurchasedPartToAssemblyViewModel> GetForEditQuantityAsync(int purchasedPartId, int assemblyId);

        Task EditQuantityOfPurchasedPartInAssemblyAsync(int purchasedPartId, int assemblyId, int quantity);

        Task RemovePurchasedPartFromAssemblyAsync(int purchasedPartId, int assemblyId);

    }
}
