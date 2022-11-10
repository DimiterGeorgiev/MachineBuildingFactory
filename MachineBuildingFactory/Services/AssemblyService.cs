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

    }
}
