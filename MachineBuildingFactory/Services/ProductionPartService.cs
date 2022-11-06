using MachineBuildingFactory.Contracts;
using MachineBuildingFactory.Data;
using MachineBuildingFactory.Data.Models;
using MachineBuildingFactory.Models;
using Microsoft.EntityFrameworkCore;

namespace MachineBuildingFactory.Services
{
    public class ProductionPartService : IProductionPartService
    {
        private readonly ApplicationDbContext context;

        public ProductionPartService(ApplicationDbContext _context)
        {
            context = _context;
        }

        public async Task CreateProductionPartsAsync(CreateProductionPartViewModel model)
        {
            var entity = new ProductionPart()
            {
                Name = model.Name,
                Description = model.Description,
                Image = model.Image,
                TypeOfProductionPartId = model.TypeOfProductionPartId,
                AuthorSignature = model.AuthorSignature,
                SurfaceArea = model.SurfaceArea,
                DrawingNumber = model.DrawingNumber,
                Weight = model.Weight,
                SurfaceTreatment = model.SurfaceTreatment,
                TypeOfPaint = model.TypeOfPaint,
                ColorOfPaintRal = model.ColorOfPaintRal,
                LaserCutLength = model.LaserCutLength,
                MaterialId = model.MaterialId


            };
            await context.ProductionParts.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ProductionPartViewModel>> GetAllProductionPartsAsync()
        {
            var entities = await context.ProductionParts
                .Include(p => p.Material)
                .Include(p => p.TypeOfProductionPart)
                .ToListAsync();

            return entities
                .Select(p => new ProductionPartViewModel()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Image = p.Image,
                    TypeOfProductionPart = p.TypeOfProductionPart.Name,
                    CreatedOn = p.CreatedOn.ToString(),
                    AuthorSignature = p.AuthorSignature,
                    SurfaceArea = p.SurfaceArea.ToString(),
                    DrawingNumber = p.DrawingNumber,
                    Weight = p.Weight.ToString(),
                    SurfaceTreatment = p.SurfaceTreatment.ToString(),
                    TypeOfPaint = p.TypeOfPaint.ToString(),
                    ColorOfPaintRal = p.ColorOfPaintRal.ToString(),
                    LaserCutLength = p.LaserCutLength.ToString(),
                    Material = p.Material.MaterialNumber

                });
        }

        public async Task<IEnumerable<Material>> GetMaterialsAsync()
        {
            return await context.Materials.ToListAsync();
        }

        public async Task<IEnumerable<TypeOfProductionPart>> GetTypeOfProductionPartAsync()
        {
            return await context.TypeOfProductionParts.ToListAsync();
        }
    }
}
