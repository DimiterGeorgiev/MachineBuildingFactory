using MachineBuildingFactory.Areas.Management.Models;

namespace MachineBuildingFactory.Areas.Management.Contracts
{
    public interface ITypeOfProductionPartServices
    {
        Task<IEnumerable<TypeOfProductionPartViewModel>> GetAllTypeOfProductionPartsAsync();

        Task CreateTypeOfProductionPartAsync(CreateTypeOfProductionPartViewModel model);

        Task<EditTypeOfProductionPartViewModel> GetTypeOfProductionPartForEditAsync(int typeOfProductionPartId);

        Task EditTypeOfProductionPartAsync(EditTypeOfProductionPartViewModel model);

        Task DeleteAsync(int typeOfProductionPartId);
    }
}
