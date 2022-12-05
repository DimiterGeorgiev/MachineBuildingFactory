using MachineBuildingFactory.Areas.Management.Models;

namespace MachineBuildingFactory.Areas.Management.Contracts
{
    public interface IMaterialService
    {
        Task<IEnumerable<MaterialViewModel>> GetAllMaterialsAsync();

        Task CreateMaterialAsync(CreateMaterialViewModel model);

        Task<EditMaterialViewModel> GetMaterialForEditAsync(int manufacturerId);

        Task EditMaterialAsync(EditMaterialViewModel model);

        Task DeleteAsync(int materialId);
    }
}
