using MachineBuildingFactory.Areas.Management.Contracts;
using MachineBuildingFactory.Areas.Management.Models;
using MachineBuildingFactory.Data;
using MachineBuildingFactory.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MachineBuildingFactory.Areas.Management.Services
{
    public class ManufacturerServices : IManufacturerServices
    {
        private readonly ApplicationDbContext context;

        public ManufacturerServices(ApplicationDbContext _context)
        {
            context = _context;
        }

        [HttpPost]
        public async Task CreateManufacturerAsync(CreateManufacturerViewModel model)
        {
            var entity = new Manufacturer()
            {
                Name = model.Name,
                Email = model.Email,
                UrlAddress = model.UrlAddress
            };

            await context.Manufacturers.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var manufacturer = await context.Manufacturers
                .Where(b => b.Id == id)
                .FirstOrDefaultAsync();

            if (manufacturer == null)
            {
                throw new ArgumentException("Invalid Id");
            }

            if (manufacturer != null)
            {
                context.Manufacturers.Remove(manufacturer);
                await context.SaveChangesAsync();
            }
        }

        public async Task EditManufacturerAsync(EditManufacturerViewModel model)
        {
            var entity = await context.Manufacturers.FindAsync(model.Id);

            entity!.Name = model.Name;
            entity.Email = model.Email;
            entity.UrlAddress = model.UrlAddress;

            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ManufacturerViewModel>> GetAllManufacturersAsync()
        {
            var entities = await context.Manufacturers
                .ToListAsync();

            return entities
                .Select(p => new ManufacturerViewModel()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Email = p.Email,
                    UrlAddress = p.UrlAddress
                });
        }

        public async Task<EditManufacturerViewModel> GetManufacturerForEditAsync(int id)
        {
            var manufacturer = await context.Manufacturers.FindAsync(id);

            if (manufacturer == null)
            {
                throw new ArgumentException("Invalid Id");
            }

            var model = new EditManufacturerViewModel()
            {
                Id = id,
                Name = manufacturer!.Name,
                Email = manufacturer.Email,
                UrlAddress = manufacturer.UrlAddress
            };

            return model;
        }
    }
}
