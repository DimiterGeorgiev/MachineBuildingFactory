using MachineBuildingFactory.Data.Models;
using MachineBuildingFactory.Models;

namespace MachineBuildingFactory.Contracts
{
    public interface IPurchasedPartService
    {
        /// <summary>
        /// Returns all purchased parts
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<PurchasedPartViewModel>> GetAllPurchasedPartsAsync();

        /// <summary>
        /// Returns all manufacturers
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Manufacturer>> GetManufactursAsync();

        /// <summary>
        /// Returns all suppliers
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Supplier>> GetSuppliersAsync();

        /// <summary>
        /// Create new purchased part
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task CreatePurchasedPartAsync(CreatePurchasedPartViewModel model);

        /// <summary>
        /// Get purchased part for edit
        /// </summary>
        /// <param name="purchasedPartId"></param>
        /// <returns></returns>
        Task<EditPurchasedPartViewModel> GetPurchasedPartForEditAsync(int purchasedPartId);

        /// <summary>
        /// Edit purchased part
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task EditPurchasedPartAsync(EditPurchasedPartViewModel model);

        /// <summary>
        /// Delete purchsed part
        /// </summary>
        /// <param name="productionPartId"></param>
        /// <returns></returns>
        Task DeleteAsync(int productionPartId);

        /// <summary>
        /// Add purchased part to this assembly
        /// </summary>
        /// <param name="purchasedPartId"></param>
        /// <param name="assemblyId"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        Task AddPurchasedPartToAssemblyAsync(int purchasedPartId, int assemblyId, int quantity);

        /// <summary>
        /// Get purchsed part for edit quantity
        /// </summary>
        /// <param name="purchasedPartId"></param>
        /// <param name="assemblyId"></param>
        /// <returns></returns>
        Task<AddPurchasedPartToAssemblyViewModel> GetForEditQuantityAsync(int purchasedPartId, int assemblyId);

        /// <summary>
        /// Edit quantity of purchased part in assembly
        /// </summary>
        /// <param name="purchasedPartId"></param>
        /// <param name="assemblyId"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        Task EditQuantityOfPurchasedPartInAssemblyAsync(int purchasedPartId, int assemblyId, int quantity);

        /// <summary>
        /// Remove purchased part from this assembly
        /// </summary>
        /// <param name="purchasedPartId"></param>
        /// <param name="assemblyId"></param>
        /// <returns></returns>
        Task RemovePurchasedPartFromAssemblyAsync(int purchasedPartId, int assemblyId);
    }
}
