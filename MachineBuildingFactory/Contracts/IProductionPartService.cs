using MachineBuildingFactory.Data.Models;
using MachineBuildingFactory.Models;

namespace MachineBuildingFactory.Contracts
{
    public interface IProductionPartService
    {
        /// <summary>
        /// Returns all Production parts
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<ProductionPartViewModel>> GetAllProductionPartsAsync();

        /// <summary>
        /// Returns all materilas
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Material>> GetMaterialsAsync();

        /// <summary>
        /// Returns all Type of Production parts
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<TypeOfProductionPart>> GetTypeOfProductionPartAsync();

        /// <summary>
        /// Create new Porduction part
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task CreateProductionPartAsync(CreateProductionPartViewModel model);

        /// <summary>
        /// Get Production part for edit
        /// </summary>
        /// <param name="productionPartId"></param>
        /// <returns></returns>
        Task<EditProductionPartViewModel> GetProductionPartForEditAsync(int productionPartId);

        /// <summary>
        /// Edti Porduction part
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task EditProductionPartAsync(EditProductionPartViewModel model);

        /// <summary>
        /// Delete production part
        /// </summary>
        /// <param name="productionPartId"></param>
        /// <returns></returns>
        Task DeleteAsync(int productionPartId);

        /// <summary>
        /// Add production part to this assembly
        /// </summary>
        /// <param name="productionPartId"></param>
        /// <param name="assemblyId"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        Task AddProductionPartToAssemblyAsync(int productionPartId, int assemblyId, int quantity);

        /// <summary>
        /// Get Production part from this assembly for edit quantity
        /// </summary>
        /// <param name="productionPartId"></param>
        /// <param name="assemblyId"></param>
        /// <returns></returns>
        Task<AddProducitonPartToAssemblyViewModel> GetForEditQuantityAsync(int productionPartId, int assemblyId);

        /// <summary>
        /// Edit quantity of production part in this assembly
        /// </summary>
        /// <param name="productionPartId"></param>
        /// <param name="assemblyId"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        Task EditQuantityOfProductionPartInAssemblyAsync(int productionPartId, int assemblyId, int quantity);

        /// <summary>
        /// Remove production part from this assembly
        /// </summary>
        /// <param name="productionPartId"></param>
        /// <param name="assemblyId"></param>
        /// <returns></returns>
        Task RemoveProductionPartFromAssemblyAsync(int productionPartId, int assemblyId);
    }
}
