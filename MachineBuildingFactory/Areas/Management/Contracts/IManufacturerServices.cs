using MachineBuildingFactory.Areas.Management.Models;


namespace MachineBuildingFactory.Areas.Management.Contracts
{
    public interface IManufacturerServices
    {
        Task<IEnumerable<ManufacturerViewModel>> GetAllManufacturersAsync();

        Task CreateManufacturerAsync(CreateManufacturerViewModel model);

        Task<EditManufacturerViewModel> GetManufacturerForEditAsync(int manufacturerId);

        Task EditManufacturerAsync(EditManufacturerViewModel model);

        Task DeleteAsync(int manufacturerId);
    }
}
