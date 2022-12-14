using MachineBuildingFactory.Areas.Management.Contracts;
using MachineBuildingFactory.Areas.Management.Models;
using MachineBuildingFactory.Data;
using MachineBuildingFactory.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MachineBuildingFactory.Areas.Management.Services
{
    public class SupplierServices : ISupplierServices
    {
        private readonly ApplicationDbContext context;

        public SupplierServices(ApplicationDbContext _context)
        {
            context = _context;
        }

        [HttpPost]
        public async Task CreateSupplierAsync(CreateSupplierViewModel model)
        {
            var entity = new Supplier()
            {
                Name = model.Name,
                Email = model.Email,
                UrlAddress = model.UrlAddress
            };

            await context.Suppliers.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var supplier = await context.Suppliers
                .Where(b => b.Id == id)
                .FirstOrDefaultAsync();

            if (supplier == null)
            {
                throw new ArgumentException("Invalid Id");
            }

            if (supplier != null)
            {
                context.Suppliers.Remove(supplier);
                await context.SaveChangesAsync();
            }
        }

        public async Task EditSupplierAsync(EditSupplierViewModel model)
        {
            var entity = await context.Suppliers.FindAsync(model.Id);

            entity!.Name = model.Name;
            entity.Email = model.Email;
            entity.UrlAddress = model.UrlAddress;

            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<SupplierViewModel>> GetAllSuppliersAsync()
        {
            var entities = await context.Suppliers
                .ToListAsync();

            return entities
                .Select(p => new SupplierViewModel()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Email = p.Email,
                    UrlAddress = p.UrlAddress
                });
        }

        public async Task<EditSupplierViewModel> GetSupplierForEditAsync(int id)
        {
            var supplier = await context.Suppliers.FindAsync(id);

            if (supplier == null)
            {
                throw new ArgumentException("Invalid Id");
            }

            var model = new EditSupplierViewModel()
            {
                Id = id,
                Name = supplier!.Name,
                Email = supplier.Email,
                UrlAddress = supplier.UrlAddress
            };

            return model;
        }
    }
}
