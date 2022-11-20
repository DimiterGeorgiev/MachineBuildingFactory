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




        //не работи
        Task<IEnumerable<ProductionPartViewModel>> GetProductionPartListFromAssemblyAsync(int assemblyId);

    }
}
