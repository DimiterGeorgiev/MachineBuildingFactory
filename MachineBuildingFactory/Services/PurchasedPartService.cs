using MachineBuildingFactory.Contracts;
using MachineBuildingFactory.Data;
using MachineBuildingFactory.Data.Models;
using MachineBuildingFactory.Models;
using Microsoft.AspNetCore.Mvc;
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

        [HttpPost]
        public async Task AddPurchasedPartToAssemblyAsync(int purchasedPartId, int assemblyId, int quantity)
        {
            var assembly = await context.Assemblies
                .Where(a => a.Id == assemblyId)
                .Include(a => a.AssemblyProductionParts)
                .FirstOrDefaultAsync();

            if (assembly == null)
            {
                throw new ArgumentException("Invalid assemblyId");
            }

            var purchasedPart = await context.PurchasedParts.FirstOrDefaultAsync(p => p.Id == purchasedPartId);

            if (purchasedPart == null)
            {
                throw new ArgumentException("Invalid purchasedPartId");
            }

            if (!assembly.AssemblyPurchаsedParts.Any(p => p.PurchasedPartId == purchasedPartId)) // Ако няма такъв Purchased part го добави
            {
                assembly.AssemblyPurchаsedParts.Add(new AssemblyPurchasedPart()
                {
                    PurchasedPartId = purchasedPart.Id,
                    AssemblyId = assembly.Id,
                    PurchasedPart = purchasedPart,
                    Assembly = assembly,
                    Quantity = quantity
                });

                await context.SaveChangesAsync();
            }
        }

        [HttpPost]
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

        public async Task DeleteAsync(int id)
        {
            var purchasedPart = await context.PurchasedParts
                .Where(b => b.Id == id)
                .FirstOrDefaultAsync();

            if (purchasedPart != null)
            {
                context.PurchasedParts.Remove(purchasedPart);
                await context.SaveChangesAsync();
            }
        }

        public async Task EditPurchasedPartAsync(EditPurchasedPartViewModel model)
        {
            var entity = await context.PurchasedParts.FindAsync(model.Id);

            entity!.Name = model.Name;
            entity.ItemNumber = model.ItemNumber;
            entity.SupplierId = model.SupplierId;
            entity.ManufacturerId = model.ManufacturerId;
            entity.Description = model.Description;
            entity.Image = model.Image;
            entity.Weight = model.Weight;
            entity.Standard = model.Standard;

            await context.SaveChangesAsync();
        }

        [HttpPost]
        public async Task EditQuantityOfPurchasedPartInAssemblyAsync(int purchasedPartId, int assemblyId, int quantity)
        {
            var assembly = await context.Assemblies
               .Where(a => a.Id == assemblyId)
               .Include(a => a.AssemblyProductionParts)
               .FirstOrDefaultAsync();

            if (assembly == null)
            {
                throw new ArgumentException("Invalid assemblyId");
            }

            var purchasedPart = await context.PurchasedParts.FirstOrDefaultAsync(p => p.Id == purchasedPartId);

            if (purchasedPart == null)
            {
                throw new ArgumentException("Invalid purchasedPartId");
            }

            if (assembly.AssemblyPurchаsedParts.Any(p => p.PurchasedPartId == purchasedPartId)) // Ако има такъв Purchased part променяме колиеството
            {
                var currAssemblyPurchasedPart = assembly.AssemblyPurchаsedParts.Find(p => p.PurchasedPartId == purchasedPartId);

                currAssemblyPurchasedPart!.Quantity = quantity;

                await context.SaveChangesAsync();
            }
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

        public async Task<AddPurchasedPartToAssemblyViewModel> GetForEditQuantityAsync(int purchasedPartId, int assemblyId)
        {
            var purchasedPart = await context.PurchasedParts.FindAsync(purchasedPartId);

            if (purchasedPart == null)
            {
                throw new ArgumentException("Invalid purchasedPartId");
            }

            var assembly = await context.Assemblies
               .Where(a => a.Id == assemblyId)
               .Include(a => a.AssemblyPurchаsedParts)
               .FirstOrDefaultAsync();

            if (assembly == null)
            {
                throw new ArgumentException("Invalid assemblyId");
            }

            var quantity = assembly.AssemblyPurchаsedParts.Find(p => p.PurchasedPartId == purchasedPartId)!.Quantity;

            var model = new AddPurchasedPartToAssemblyViewModel()
            {
                Quantity = quantity
            };

            return model;
        }

        public async Task<IEnumerable<Manufacturer>> GetManufactursAsync()
        {
            return await context.Manufacturers.ToListAsync();
        }

        public async Task<EditPurchasedPartViewModel> GetPurchasedPartForEditAsync(int id)
        {
            var purchasedPart = await context.PurchasedParts.FindAsync(id); //когато търсим по PrimaryKey търсим с FindAsync

            var model = new EditPurchasedPartViewModel()
            {
                Id = id,
                Name = purchasedPart!.Name,
                ItemNumber = purchasedPart.ItemNumber,
                SupplierId = purchasedPart.SupplierId,
                ManufacturerId = purchasedPart.ManufacturerId,
                Description = purchasedPart.Description!,
                Image = purchasedPart.Image!,
                Weight = purchasedPart.Weight,
                Standard = purchasedPart.Standard,
            };

            model.Suppliers = await GetSuppliersAsync();
            model.Manufacturers = await GetManufactursAsync();

            return model;
        }

        public async Task<IEnumerable<Supplier>> GetSuppliersAsync()
        {
            return await context.Suppliers.ToListAsync();
        }

        public async Task RemovePurchasedPartFromAssemblyAsync(int purchasedPartId, int assemblyId)
        {
            var assembly = await context.Assemblies
                .Where(a => a.Id == assemblyId)
                .Include(a => a.AssemblyPurchаsedParts)
                .FirstOrDefaultAsync();

            if (assembly == null)
            {
                throw new ArgumentException("Invalid assemblyId");
            }

            var purchasedPart = assembly.AssemblyPurchаsedParts.FirstOrDefault(p => p.PurchasedPartId == purchasedPartId);

            if (purchasedPart == null)
            {
                throw new ArgumentException("Invalid productionPartId");
            }

            if (assembly.AssemblyPurchаsedParts.Any(p => p.PurchasedPartId == purchasedPartId)) // Ако има такъв Purchased part го махаме
            {
                assembly.AssemblyPurchаsedParts.Remove(purchasedPart);

                await context.SaveChangesAsync();
            }
        }
    }
}
