using MachineBuildingFactory.Areas.Management.Models;

namespace MachineBuildingFactory.Areas.Management.Contracts
{
    public interface ISupplierServices
    {
        Task<IEnumerable<SupplierViewModel>> GetAllSuppliersAsync();

        Task CreateSupplierAsync(CreateSupplierViewModel model);

        Task<EditSupplierViewModel> GetSupplierForEditAsync(int manufacturerId);

        Task EditSupplierAsync(EditSupplierViewModel model);

        Task DeleteAsync(int supplierId);
    }
}
