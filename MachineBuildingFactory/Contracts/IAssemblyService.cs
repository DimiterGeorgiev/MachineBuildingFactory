using MachineBuildingFactory.Data.Models;
using MachineBuildingFactory.Models;

namespace MachineBuildingFactory.Contracts
{
    public interface IAssemblyService
    {
        Task<IEnumerable<AssemblyViewModel>> GetAllAssembliesAsync();

        Task CreateAssemblyAsync(CreateAssemblyViewModel model);

        Task AddAssemblyToCollectionAsync(int assemblyId, string userId);

        Task<IEnumerable<AssemblyViewModel>> GetMineAssembliesAsync(string userId);

        Task RemoveAssemblyFromCollectionAsync(int assemblyId, string userId);

        Task<EditAssemblyViewModel> GetAssemblyForEditAsync(int assemblyId);

        Task EditAssemblyAsync(EditAssemblyViewModel model);

        Task DeleteAsync(int assemblyId);

        Task SetAssemblyAsWorkingAsync(int assemblyId, string userId);

        Task<AssemblyViewModel> GetWorkingAssemblyAsync(string userId);

        Task<IEnumerable<AssemblyViewModel>> GetWhereUsedAssembliesAsync(int partId);

        Task<IEnumerable<AssemblyViewModel>> GetWhereUsedPurchasedPartAssembliesAsync(int partId);

        Task<IEnumerable<AssemblyViewModel>> GetWhereUsedManufacturerAssembliesAsync(int manufacturerId);

        Task<IEnumerable<AssemblyViewModel>> GetWhereUsedSupplierAssembliesAsync(int supplierId);

        Task<IEnumerable<AssemblyViewModel>> GetWhereUsedMaterialAssembliesAsync(int materialId);

        Task<IEnumerable<AssemblyViewModel>> GetWhereUsedTypeOfProductionPartAssembliesAsync(int TypeOfProductionPartId);

        Task<IEnumerable<ProductionPartViewModel>> GetProductionPartListFromAssemblyAsync(int assemblyId);

        Task<IEnumerable<PurchasedPartViewModel>> GetPurchasedPartListFromAssemblyAsync(int assemblyId);

        Task<Assembly> GetAssemblyById(int assemblyId);

    }
}
