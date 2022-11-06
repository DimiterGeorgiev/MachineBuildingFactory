using MachineBuildingFactory.Data.Models;
using MachineBuildingFactory.Models;

namespace MachineBuildingFactory.Contracts
{
    public interface IProductionPartService
    {
        Task<IEnumerable<ProductionPartViewModel>> GetAllProductionPartsAsync();

        Task<IEnumerable<Material>> GetMaterialsAsync();

        Task<IEnumerable<TypeOfProductionPart>> GetTypeOfProductionPartAsync();

        Task CreateProductionPartsAsync(CreateProductionPartViewModel model);

    }
}
