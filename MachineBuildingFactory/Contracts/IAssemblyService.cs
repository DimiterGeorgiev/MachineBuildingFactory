using MachineBuildingFactory.Models;

namespace MachineBuildingFactory.Contracts
{
    public interface IAssemblyService
    {
        Task<IEnumerable<AssemblyViewModel>> GetAllAssembliesAsync();

        Task CreateAssemblyAsync(CreateAssemblyViewModel model);

        Task<IEnumerable<ProductionPartViewModel>> GetProductionPartListFromAssemblyAsync(int assemblyId);

    }
}
