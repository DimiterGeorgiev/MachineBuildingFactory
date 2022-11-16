using MachineBuildingFactory.Data.Models;
using MachineBuildingFactory.Models;

namespace MachineBuildingFactory.Contracts
{
    public interface IProductionPartService
    {
        Task<IEnumerable<ProductionPartViewModel>> GetAllProductionPartsAsync();

        Task<IEnumerable<Material>> GetMaterialsAsync();

        Task<IEnumerable<TypeOfProductionPart>> GetTypeOfProductionPartAsync();

        Task CreateProductionPartAsync(CreateProductionPartViewModel model);

        Task<EditProductionPartViewModel> GetProductionPartForEditAsync(int productionPartId);

        Task EditProductionPartAsync(EditProductionPartViewModel model);

        Task DeleteAsync(int productionPartId);




        Task AddProductionPartToAssemblyAsync(int productionPartId, int assemblyId, int quantity);



        //Task<IEnumerable<ProductionPartViewModel>> GetProductionPartListFromAssemblyAsync(int assemblyId);



    }
}
