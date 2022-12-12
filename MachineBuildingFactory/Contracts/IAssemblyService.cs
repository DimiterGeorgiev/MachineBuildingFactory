using MachineBuildingFactory.Data.Models;
using MachineBuildingFactory.Models;

namespace MachineBuildingFactory.Contracts
{
    public interface IAssemblyService
    {
        /// <summary>
        /// Get All Assemblies
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<AssemblyViewModel>> GetAllAssembliesAsync();

        /// <summary>
        /// Create new Assembly
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task CreateAssemblyAsync(CreateAssemblyViewModel model);

        /// <summary>
        /// Add Assembly to collection of this user
        /// </summary>
        /// <param name="assemblyId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task AddAssemblyToCollectionAsync(int assemblyId, string userId);

        /// <summary>
        /// Get collection of assemblies of this user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<IEnumerable<AssemblyViewModel>> GetMineAssembliesAsync(string userId);


        /// <summary>
        /// Remove assemblie from collection of this user
        /// </summary>
        /// <param name="assemblyId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task RemoveAssemblyFromCollectionAsync(int assemblyId, string userId);

        /// <summary>
        /// Get assembly for edit
        /// </summary>
        /// <param name="assemblyId"></param>
        /// <returns></returns>
        Task<EditAssemblyViewModel> GetAssemblyForEditAsync(int assemblyId);

        /// <summary>
        /// Edit assembly
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task EditAssemblyAsync(EditAssemblyViewModel model);

        /// <summary>
        /// Delete Assembly
        /// </summary>
        /// <param name="assemblyId"></param>
        /// <returns></returns>
        Task DeleteAsync(int assemblyId);

        /// <summary>
        /// Set working assembly of this user
        /// </summary>
        /// <param name="assemblyId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task SetAssemblyAsWorkingAsync(int assemblyId, string userId);

        /// <summary>
        /// Returns working assembly
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<AssemblyViewModel> GetWorkingAssemblyAsync(string userId);

        /// <summary>
        /// Returns all assemblies where this Production part is used
        /// </summary>
        /// <param name="partId"></param>
        /// <returns></returns>
        Task<IEnumerable<AssemblyViewModel>> GetWhereUsedAssembliesAsync(int partId);

        /// <summary>
        /// Returns all assemblies where this Purchased part is used
        /// </summary>
        /// <param name="partId"></param>
        /// <returns></returns>
        Task<IEnumerable<AssemblyViewModel>> GetWhereUsedPurchasedPartAssembliesAsync(int partId);

        /// <summary>
        /// Returns all assemblies where there is a Purchased parts with this Manufacturer.
        /// </summary>
        /// <param name="manufacturerId"></param>
        /// <returns></returns>
        Task<IEnumerable<AssemblyViewModel>> GetWhereUsedManufacturerAssembliesAsync(int manufacturerId);

        /// <summary>
        /// Returns all assemblies where there is a Purchased parts with this Supplier.
        /// </summary>
        /// <param name="supplierId"></param>
        /// <returns></returns>
        Task<IEnumerable<AssemblyViewModel>> GetWhereUsedSupplierAssembliesAsync(int supplierId);

        /// <summary>
        /// Returns all assemblies where there is a Production parts with this Material.
        /// </summary>
        /// <param name="materialId"></param>
        /// <returns></returns>
        Task<IEnumerable<AssemblyViewModel>> GetWhereUsedMaterialAssembliesAsync(int materialId);

        /// <summary>
        /// Returns all assemblies where there is a Production parts from this Type.
        /// </summary>
        /// <param name="TypeOfProductionPartId"></param>
        /// <returns></returns>
        Task<IEnumerable<AssemblyViewModel>> GetWhereUsedTypeOfProductionPartAssembliesAsync(int TypeOfProductionPartId);

        /// <summary>
        /// Returns all production parts in this assembly
        /// </summary>
        /// <param name="assemblyId"></param>
        /// <returns></returns>
        Task<IEnumerable<ProductionPartViewModel>> GetProductionPartListFromAssemblyAsync(int assemblyId);

        /// <summary>
        /// Returns all purchased parts in this assembly
        /// </summary>
        /// <param name="assemblyId"></param>
        /// <returns></returns>
        Task<IEnumerable<PurchasedPartViewModel>> GetPurchasedPartListFromAssemblyAsync(int assemblyId);

        /// <summary>
        /// Returns assembly with this Id
        /// </summary>
        /// <param name="assemblyId"></param>
        /// <returns></returns>
        Task<Assembly> GetAssemblyById(int assemblyId);

    }
}
