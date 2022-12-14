using MachineBuildingFactory.Contracts;
using MachineBuildingFactory.Data;
using MachineBuildingFactory.Data.Models;
using MachineBuildingFactory.Models;
using Microsoft.EntityFrameworkCore;

namespace MachineBuildingFactory.Services
{
    public class AssemblyService : IAssemblyService
    {
        private readonly ApplicationDbContext context;

        public AssemblyService(ApplicationDbContext _context)
        {
            context = _context;
        }

        public async Task AddAssemblyToCollectionAsync(int id, string userId)
        {
            var user = await context.Users
                .Where(u => u.Id == userId)
                .Include(u => u.ApplicationUserAssemblys)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new ArgumentException("Invalid userId");
            }

            var assembly = await context.Assemblies.FirstOrDefaultAsync(a => a.Id == id);

            if (assembly == null)
            {
                throw new ArgumentException("Invalid AssemblyId");
            }

            if (!user.ApplicationUserAssemblys.Any(a => a.AssemblyId == id)) //Ако го няма го добавяме
            {
                user.ApplicationUserAssemblys.Add(new ApplicationUserAssembly()
                {
                    AssemblyId = assembly.Id,
                    ApplicationUserId = user.Id,
                    Assembly = assembly,
                    ApplicationUser = user
                });

                await context.SaveChangesAsync();
            }

            else
            {
                throw new Exception();
            }
        }

        public async Task CreateAssemblyAsync(CreateAssemblyViewModel model)
        {
            var entity = new Assembly()
            {
                Name = model.Name,
                DrawingNumber = model.DrawingNumber,
                Description = model.Description,
                AuthorSignature = model.AuthorSignature,
                Image = model.Image
            };

            await context.Assemblies.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int assemblyId)
        {
            var assembly = await context.Assemblies
                .Where(a => a.Id == assemblyId)
                .FirstOrDefaultAsync();

            if (assembly != null)
            {
                context.Assemblies.Remove(assembly);
                await context.SaveChangesAsync();

            }
            else
            {
                throw new Exception();
            }
        }

        public async Task EditAssemblyAsync(EditAssemblyViewModel model)
        {
            var entity = await context.Assemblies.FindAsync(model.Id);

            entity!.Name = model.Name;
            entity.Description = model.Description;
            entity.AuthorSignature = model.AuthorSignature;
            entity.DrawingNumber = model.DrawingNumber;
            entity.Image = model.Image;

            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<AssemblyViewModel>> GetAllAssembliesAsync()
        {
            var entities = await context.Assemblies
                .ToListAsync();

            return entities
                .Select(a => new AssemblyViewModel()
                {
                    Id = a.Id,
                    Name = a.Name,
                    DrawingNumber = a.DrawingNumber,
                    Description = a.Description,
                    AuthorSignature = a.AuthorSignature,
                    CreatedOn = a.CreatedOn.ToString(),
                    Image = a.Image,
                });
        }

        public async Task<EditAssemblyViewModel> GetAssemblyForEditAsync(int id)
        {
            var assembly = await context.Assemblies.FindAsync(id); //когато търсим по PrimaryKey търсим FindAsync

            if (assembly == null)
            {
                throw new ArgumentException("Invalid assemblyId");
            }

            var model = new EditAssemblyViewModel()
            {
                Id = id,
                Name = assembly?.Name!,
                Description = assembly?.Description!,
                Image = assembly?.Image!,
                DrawingNumber = assembly?.DrawingNumber!,
                AuthorSignature = assembly?.AuthorSignature!
            };

            return model;
        }

        public async Task<IEnumerable<AssemblyViewModel>> GetMineAssembliesAsync(string userId)
        {
            var user = await context.Users
                .Where(u => u.Id == userId)
                .Include(u => u.ApplicationUserAssemblys)
                .ThenInclude(ua => ua.Assembly)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new ArgumentException("Invalid userId");
            }

            return user.ApplicationUserAssemblys
                .Select(a => new AssemblyViewModel()
                {
                    Id = a.AssemblyId,
                    Name = a.Assembly.Name,
                    Description = a.Assembly.Description,
                    Image = a.Assembly.Image,
                    AuthorSignature = a.Assembly.AuthorSignature,
                    CreatedOn = a.Assembly.CreatedOn.ToString(),
                    DrawingNumber = a.Assembly.DrawingNumber
                });
        }


        public async Task<IEnumerable<ProductionPartViewModel>> GetProductionPartListFromAssemblyAsync(int id)
        {
            var assembly = await context.Assemblies
                .Where(a => a.Id == id)
                .Include(a => a.AssemblyProductionParts)
                .ThenInclude(ap => ap.ProductionPart)
                .ThenInclude(a => a.Material)
                .FirstOrDefaultAsync();

            if (assembly == null)
            {
                throw new ArgumentException("Invalid assemblyId");
            }

            return assembly.AssemblyProductionParts
                .Select(p => new ProductionPartViewModel()
                {
                    Id = p.ProductionPartId,
                    Name = p.ProductionPart.Name,
                    Image = p.ProductionPart.Image,
                    DrawingNumber = p.ProductionPart.DrawingNumber,
                    Material = p.ProductionPart.Material.MaterialNumber,
                    AuthorSignature = p.ProductionPart.AuthorSignature,
                    TypeOfPaint = p.ProductionPart.TypeOfPaint.ToString(),
                    CreatedOn = p.Quantity.ToString(),
                    SurfaceArea = p.ProductionPart.SurfaceArea.ToString(),
                    LaserCutLength = p.ProductionPart.LaserCutLength.ToString(),
                    SurfaceTreatment = p.ProductionPart.SurfaceTreatment.ToString(),
                });
        }

        public async Task<IEnumerable<AssemblyViewModel>> GetWhereUsedAssembliesAsync(int partId)
        {
            if (await context.ProductionParts.FindAsync(partId) == null)
            {
                throw new ArgumentException("Invalid assemblyId");
            }

            var entities = await context.Assemblies
                .Where(a => a.AssemblyProductionParts.Any(a => a.ProductionPartId == partId))
                .ToListAsync();

            return entities
                .Select(a => new AssemblyViewModel()
                {
                    Id = a.Id,
                    Name = a.Name,
                    DrawingNumber = a.DrawingNumber,
                    Description = a.Description,
                    AuthorSignature = a.AuthorSignature,
                    CreatedOn = a.CreatedOn.ToString(),
                    Image = a.Image,
                });
        }

        public async Task<AssemblyViewModel> GetWorkingAssemblyAsync(string userId)
        {
            var user = await context.Users
                .Where(u => u.Id == userId)
                .Include(u => u.WorkingAssembly)
                .ThenInclude(ua => ua.Assembly)
                .ThenInclude(uaw => uaw.AssemblyProductionParts)

                .Include(u => u.WorkingAssembly)
                .ThenInclude(ua => ua.Assembly)
                .ThenInclude(uaw => uaw.AssemblyPurchаsedParts)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new ArgumentException("Invalid userId");
            }

            if (!user.WorkingAssembly.Any())
            {
                throw new ArgumentException("No Working Assembly");
            }

            var workingAssembly = user.WorkingAssembly
            .Select(a => new AssemblyViewModel()
            {
                Id = a.AssemblyId,
                Name = a.Assembly.Name,
                Description = a.Assembly.Description,
                Image = a.Assembly.Image,
                AuthorSignature = a.Assembly.AuthorSignature,
                CreatedOn = a.Assembly.CreatedOn.ToString(),
                DrawingNumber = a.Assembly.DrawingNumber,

            }).ToList().First();

            return workingAssembly;
        }

        public async Task RemoveAssemblyFromCollectionAsync(int id, string userId)
        {
            var user = await context.Users
                .Where(u => u.Id == userId)
                .Include(u => u.ApplicationUserAssemblys)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new ArgumentException("Invalid userId");
            }

            var assembly = user.ApplicationUserAssemblys.FirstOrDefault(a => a.AssemblyId == id);

            if (assembly != null)
            {
                user.ApplicationUserAssemblys.Remove(assembly);
                await context.SaveChangesAsync();
            }
        }

        public async Task SetAssemblyAsWorkingAsync(int id, string userId)
        {
            var user = await context.Users
                .Where(u => u.Id == userId)
                .Include(u => u.WorkingAssembly)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new ArgumentException("Invalid userId");
            }

            var assembly = await context.Assemblies.FirstOrDefaultAsync(a => a.Id == id);

            if (assembly == null)
            {
                throw new ArgumentException("Invalid AssemblyId");
            }

            user.WorkingAssembly.Clear();
            user.WorkingAssembly.Add(new ApplicationUserWorkingAssembly()
            {
                AssemblyId = assembly.Id,
                ApplicationUserId = user.Id,
                Assembly = assembly,
                ApplicationUser = user
            });

            await context.SaveChangesAsync();
        }

        public async Task<Assembly> GetAssemblyById(int assemblyId)
        {
            var assembly = await context.Assemblies.FindAsync(assemblyId);

            if (assembly == null)
            {
                throw new ArgumentException("Invalid AssemblyId");
            }

            return assembly;
        }

        public async Task<IEnumerable<AssemblyViewModel>> GetWhereUsedPurchasedPartAssembliesAsync(int partId)
        {
            if (await context.PurchasedParts.FindAsync(partId) == null)
            {
                throw new ArgumentException("Invalid assemblyId");
            }

            var entities = await context.Assemblies
               .Where(a => a.AssemblyPurchаsedParts.Any(a => a.PurchasedPartId == partId))
               .ToListAsync();

            return entities
                .Select(a => new AssemblyViewModel()
                {
                    Id = a.Id,
                    Name = a.Name,
                    DrawingNumber = a.DrawingNumber,
                    Description = a.Description,
                    AuthorSignature = a.AuthorSignature,
                    CreatedOn = a.CreatedOn.ToString(),
                    Image = a.Image,
                });
        }

        public async Task<IEnumerable<PurchasedPartViewModel>> GetPurchasedPartListFromAssemblyAsync(int id)
        {
            var assembly = await context.Assemblies
                .Where(a => a.Id == id)
                .Include(a => a.AssemblyPurchаsedParts)
                .ThenInclude(ap => ap.PurchasedPart)
                .ThenInclude(a => a.Manufacturer)
                .FirstOrDefaultAsync();

            if (assembly == null)
            {
                throw new ArgumentException("Invalid assemblyId");
            }

            return assembly.AssemblyPurchаsedParts
                .Select(p => new PurchasedPartViewModel()
                {
                    Id = p.PurchasedPartId,
                    Name = p.PurchasedPart.Name,
                    ItemNumber = p.PurchasedPart.ItemNumber,
                    Image = p.PurchasedPart.Image,
                    Manufacturer = p.PurchasedPart.Manufacturer.Name,
                    Description = p.PurchasedPart.Description,
                    Weight = p.PurchasedPart.Weight.ToString(),
                    Standard = p.Quantity.ToString(),
                });
        }

        public async Task<IEnumerable<AssemblyViewModel>> GetWhereUsedManufacturerAssembliesAsync(int manufacturerId)
        {
            var entities = await context.Assemblies
               .Where(a => a.AssemblyPurchаsedParts.Any(a => a.PurchasedPart.Manufacturer.Id == manufacturerId))
               .ToListAsync();

            if (entities == null)
            {
                throw new ArgumentException("Invalid manufacturerId");
            }

            return entities
                .Select(a => new AssemblyViewModel()
                {
                    Id = a.Id,
                    Name = a.Name,
                    DrawingNumber = a.DrawingNumber,
                    Description = a.Description,
                    AuthorSignature = a.AuthorSignature,
                    CreatedOn = a.CreatedOn.ToString(),
                    Image = a.Image,
                });
        }

        public async Task<IEnumerable<AssemblyViewModel>> GetWhereUsedSupplierAssembliesAsync(int supplierId)
        {
            var entities = await context.Assemblies
               .Where(a => a.AssemblyPurchаsedParts.Any(a => a.PurchasedPart.Supplier.Id == supplierId))
               .ToListAsync();

            if (entities == null)
            {
                throw new ArgumentException("Invalid supplierId");
            }

            return entities
                .Select(a => new AssemblyViewModel()
                {
                    Id = a.Id,
                    Name = a.Name,
                    DrawingNumber = a.DrawingNumber,
                    Description = a.Description,
                    AuthorSignature = a.AuthorSignature,
                    CreatedOn = a.CreatedOn.ToString(),
                    Image = a.Image,
                });
        }

        public async Task<IEnumerable<AssemblyViewModel>> GetWhereUsedMaterialAssembliesAsync(int materialId)
        {
            var entities = await context.Assemblies
                .Where(a => a.AssemblyProductionParts.Any(a => a.ProductionPart.Material.Id == materialId))
                .ToListAsync();

            if (entities == null)
            {
                throw new ArgumentException("Invalid materialId");
            }

            return entities
                .Select(a => new AssemblyViewModel()
                {
                    Id = a.Id,
                    Name = a.Name,
                    DrawingNumber = a.DrawingNumber,
                    Description = a.Description,
                    AuthorSignature = a.AuthorSignature,
                    CreatedOn = a.CreatedOn.ToString(),
                    Image = a.Image,
                });

        }

        public async Task<IEnumerable<AssemblyViewModel>> GetWhereUsedTypeOfProductionPartAssembliesAsync(int TypeOfProductionPartId)
        {
            var entities = await context.Assemblies
                .Where(a => a.AssemblyProductionParts.Any(a => a.ProductionPart.TypeOfProductionPart.Id == TypeOfProductionPartId))
                .ToListAsync();

            if (entities == null)
            {
                throw new ArgumentException("Invalid TypeOfProductionPartId");
            }

            return entities
                .Select(a => new AssemblyViewModel()
                {
                    Id = a.Id,
                    Name = a.Name,
                    DrawingNumber = a.DrawingNumber,
                    Description = a.Description,
                    AuthorSignature = a.AuthorSignature,
                    CreatedOn = a.CreatedOn.ToString(),
                    Image = a.Image,
                });

        }
    }
}
