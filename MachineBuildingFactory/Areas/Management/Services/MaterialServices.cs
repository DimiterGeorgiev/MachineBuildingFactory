using MachineBuildingFactory.Areas.Management.Contracts;
using MachineBuildingFactory.Areas.Management.Models;
using MachineBuildingFactory.Data;
using MachineBuildingFactory.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MachineBuildingFactory.Areas.Management.Services
{
    public class MaterialServices : IMaterialService
    {
        private readonly ApplicationDbContext context;

        public MaterialServices(ApplicationDbContext _context)
        {
            context = _context;
        }

        [HttpPost]
        public async Task CreateMaterialAsync(CreateMaterialViewModel model)
        {
            var entity = new Material()
            {
                MaterialNumber = model.MaterialNumber
            };

            await context.Materials.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var material = await context.Materials
                .Where(b => b.Id == id)
                .FirstOrDefaultAsync();

            if (material == null)
            {
                throw new ArgumentException("Invalid Id");
            }

            if (material != null)
            {
                context.Materials.Remove(material);
                await context.SaveChangesAsync();
            }
        }

        public async Task EditMaterialAsync(EditMaterialViewModel model)
        {
            var entity = await context.Materials.FindAsync(model.Id);

            entity!.MaterialNumber = model.MaterialNumber;

            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<MaterialViewModel>> GetAllMaterialsAsync()
        {
            var entities = await context.Materials
                .ToListAsync();

            return entities
                .Select(p => new MaterialViewModel()
                {
                    Id = p.Id,
                    MaterialNumber = p.MaterialNumber,
                });
        }

        public async Task<EditMaterialViewModel> GetMaterialForEditAsync(int id)
        {
            var material = await context.Materials.FindAsync(id);

            if (material == null)
            {
                throw new ArgumentException("Invalid Id");
            }

            var model = new EditMaterialViewModel()
            {
                Id = id,
                MaterialNumber = material!.MaterialNumber
            };

            return model;
        }
    }
}
