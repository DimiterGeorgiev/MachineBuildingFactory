using MachineBuildingFactory.Contracts;
using MachineBuildingFactory.Data;
using MachineBuildingFactory.Data.Models;
using MachineBuildingFactory.Models;
using Microsoft.EntityFrameworkCore;

namespace MachineBuildingFactory.Services
{
    public class PurchasedPartService : IPurchasedPartService
    {
        private readonly ApplicationDbContext context;

        public PurchasedPartService(ApplicationDbContext _context)
        {
            context = _context;
        }

        public async Task CreatePurchasedPartAsync(CreatePurchasedPartViewModel model)
        {
            var entity = new PurchasedPart()
            {
                Name = model.Name,
                ItemNumber = model.ItemNumber,
                SupplierId = model.SupplierId,
                ManufacturerId = model.ManufacturerId,
                Description = model.Description,
                Image = model.Image,
                Weight = model.Weight,
                Standard = model.Standard
            };

            await context.PurchasedParts.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<PurchasedPartViewModel>> GetAllPurchasedPartsAsync()
        {
            var entities = await context.PurchasedParts
                .Include(p => p.Manufacturer)
                .Include(p => p.Supplier)
                .ToListAsync();

            return entities
                .Select(p => new PurchasedPartViewModel()
                {
                    Id = p.Id,
                    Name = p.Name,
                    ItemNumber = p.ItemNumber,
                    Supplier = p.Supplier.Name,
                    Manufacturer = p.Manufacturer.Name,
                    Description = p.Description,
                    Image = p.Image,
                    Weight = p.Weight.ToString(),
                    Standard = p.Standard
                });
        }

        public async Task<IEnumerable<Manufacturer>> GetManufactursAsync()
        {
            return await context.Manufacturers.ToListAsync();
        }

        public async Task<IEnumerable<Supplier>> GetSuppliersAsync()
        {
            return await context.Suppliers.ToListAsync();
        }
    }
}
