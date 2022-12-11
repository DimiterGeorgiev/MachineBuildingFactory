using MachineBuildingFactory.Areas.Management.Contracts;
using MachineBuildingFactory.Areas.Management.Models;
using MachineBuildingFactory.Data;
using MachineBuildingFactory.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MachineBuildingFactory.Areas.Management.Services
{
    public class TypeOfProductionPartServices : ITypeOfProductionPartServices
    {
        private readonly ApplicationDbContext context;

        public TypeOfProductionPartServices(ApplicationDbContext _context)
        {
            context = _context;
        }

        [HttpPost]
        public async Task CreateTypeOfProductionPartAsync(CreateTypeOfProductionPartViewModel model)
        {
            var entity = new TypeOfProductionPart()
            {
                Name = model.Name
            };

            await context.TypeOfProductionParts.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var typeOfProductionPart = await context.TypeOfProductionParts
                .Where(b => b.Id == id)
                .FirstOrDefaultAsync();

            if (typeOfProductionPart != null)
            {
                context.TypeOfProductionParts.Remove(typeOfProductionPart);
                await context.SaveChangesAsync();
            }
        }

        public async Task EditTypeOfProductionPartAsync(EditTypeOfProductionPartViewModel model)
        {
            var entity = await context.TypeOfProductionParts.FindAsync(model.Id);

            entity!.Name = model.Name;

            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TypeOfProductionPartViewModel>> GetAllTypeOfProductionPartsAsync()
        {
            var entities = await context.TypeOfProductionParts
                .ToListAsync();

            return entities
                .Select(p => new TypeOfProductionPartViewModel()
                {
                    Id = p.Id,
                    Name = p.Name
                });
        }

        public async Task<EditTypeOfProductionPartViewModel> GetTypeOfProductionPartForEditAsync(int id)
        {
            var typeOfProductionPart = await context.TypeOfProductionParts.FindAsync(id);

            var model = new EditTypeOfProductionPartViewModel()
            {
                Id = id,
                Name = typeOfProductionPart!.Name
            };

            return model;
        }
    }
}
