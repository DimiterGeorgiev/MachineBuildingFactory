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
                throw new ArgumentException("Imvalid userId");
            }

            var assembly = await context.Assemblies.FirstOrDefaultAsync(a => a.Id == id);

            if (assembly == null)
            {
                throw new ArgumentException("Imvalid AssemblyId");
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
        }

        public async Task EditAssemblyAsync(EditAssemblyViewModel model)
        {
            var entity = await context.Assemblies.FindAsync(model.Id);

            entity.Name = model.Name;
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

            var model = new EditAssemblyViewModel()
            {
                Id = id,
                Name = assembly.Name,
                Description = assembly.Description,
                Image = assembly.Image,
                DrawingNumber = assembly.DrawingNumber,
                AuthorSignature = assembly.AuthorSignature
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


        //още не работи
        public async Task<IEnumerable<ProductionPartViewModel>> GetProductionPartListFromAssemblyAsync(int assemblyId)
        {
            var assembly = await context.Assemblies
                .Where(a => a.Id == assemblyId)
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
                    Name = p.ProductionPart.Name,
                    DrawingNumber = p.ProductionPart.DrawingNumber,
                    Material = p.ProductionPart.Material.MaterialNumber,
                    AuthorSignature = p.ProductionPart.AuthorSignature
                });
        }

        public async Task<AssemblyViewModel> GetWorkingAssemblyAsync(string userId)
        {
            var user = await context.Users
                .Where(u => u.Id == userId)
                .Include(u => u.WorkingAssembly)
                .ThenInclude(ua => ua.Assembly)
                .ThenInclude(uaw => uaw.AssemblyProductionParts)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new ArgumentException("Invalid userId");
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
                throw new ArgumentException("Imvalid userId");
            }

            var assembly = await context.Assemblies.FirstOrDefaultAsync(a => a.Id == id);

            if (assembly == null)
            {
                throw new ArgumentException("Imvalid AssemblyId");
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
    }
}
