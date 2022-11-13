﻿using MachineBuildingFactory.Contracts;
using MachineBuildingFactory.Data;
using MachineBuildingFactory.Data.Models;
using MachineBuildingFactory.Models;
using Microsoft.AspNetCore.Mvc;
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

        public async Task AddProductionPartToAssemblyAsync(int productionPartId, int assemblyId, int quantity)
        {
            var assembly = await context.Assemblies
                .Where(a => a.Id == assemblyId)
                .Include(a => a.AssemblyProductionParts)
                .FirstOrDefaultAsync();

            if (assembly == null)
            {
                throw new ArgumentException("Invalid assemblyId");
            }

            var productionPart = await context.ProductionParts.FirstOrDefaultAsync(p => p.Id == productionPartId);

            if (productionPart == null)
            {
                throw new ArgumentException("Invalid productionPartId");
            }

            if (!assembly.AssemblyProductionParts.Any(p => p.ProductionPartId == productionPartId)) // Ако няма такъв Production part го добави
            {
                assembly.AssemblyProductionParts.Add(new AssemblyProductionPart()
                {
                    ProductionPartId = productionPart.Id,
                    AssemblyId = assembly.Id,
                    ProductionPart = productionPart,
                    Assembly = assembly,
                    Quantaty = quantity
                });

                await context.SaveChangesAsync();
            }
        }

        [HttpPost]
        public async Task CreateProductionPartAsync(CreateProductionPartViewModel model)
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

        public async Task EditProductionPartAsync(EditProductionPartViewModel model)
        {
            var entity = await context.ProductionParts.FindAsync(model.Id);

            entity.Name = model.Name;
            entity.Description = model.Description;
            entity.Image = model.Image;
            entity.TypeOfProductionPartId = model.TypeOfProductionPartId;
            entity.CreatedOn = model.CreatedOn;
            entity.AuthorSignature = model.AuthorSignature;
            entity.SurfaceArea = model.SurfaceArea;
            entity.DrawingNumber = model.DrawingNumber;
            entity.Weight = model.Weight;
            entity.SurfaceTreatment = model.SurfaceTreatment;
            entity.TypeOfPaint = model.TypeOfPaint;
            entity.ColorOfPaintRal = model.ColorOfPaintRal;
            entity.LaserCutLength = model.LaserCutLength;
            entity.MaterialId = model.MaterialId;

            await context.SaveChangesAsync();


        }

        //public async Task<ProductionPartViewModel> DetailsAsync(int productionPartId)
        //{
        //    //if(productionPartId == null || context.ProductionParts == null)
        //    //{
        //    //    return NotFoundObjectResult();
        //    //}

        //    var part = await context.ProductionParts.FindAsync(productionPartId);
        //        //.FirstOrDefaultAsync(p => p.Id == productionPartId);

        //    if (part == null)
        //    {
        //        throw new ArgumentException("Invalid productionPartId");
        //    }

        //    return entity
        //}

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

        public async Task<EditProductionPartViewModel> GetProductionPartForEditAsync(int id)
        {
            var productionPart = await context.ProductionParts.FindAsync(id); //когато търсим по PrimaryKey търсим с FindAsync

            var model = new EditProductionPartViewModel()
            {
                Id = id,
                Name = productionPart.Name,
                Description = productionPart.Description,
                Image = productionPart.Image,
                TypeOfProductionPartId = productionPart.TypeOfProductionPartId,    // ?? -1, // ако CateglryId e null тук ще бъде записано -1 ако не е null ще бъде записана стойността
                CreatedOn = productionPart.CreatedOn,
                AuthorSignature = productionPart.AuthorSignature,
                SurfaceArea = productionPart.SurfaceArea,
                DrawingNumber = productionPart.DrawingNumber,
                Weight = productionPart.Weight,
                SurfaceTreatment = productionPart.SurfaceTreatment,
                TypeOfPaint = productionPart.TypeOfPaint,
                ColorOfPaintRal = productionPart.ColorOfPaintRal,
                LaserCutLength = productionPart.LaserCutLength,
                MaterialId = productionPart.MaterialId
            };

            model.TypeOfProductionParts = await GetTypeOfProductionPartAsync();
            model.Materials = await GetMaterialsAsync();

            return model;

        }

        //public async Task<IEnumerable<ProductionPartViewModel>> GetProductionPartListFromAssemblyAsync(int assemblyId)
        //{
        //    var assembly = await context.Assemblies
        //        .Where(a => a.Id == assemblyId)
        //        .Include(a => a.AssemblyProductionParts)
        //        .ThenInclude(ap => ap.ProductionPart)
        //        .ThenInclude(a => a.Material)
        //        .FirstOrDefaultAsync();

        //    if (assembly == null)
        //    {
        //        throw new ArgumentException("Invalid assemblyId");
        //    }

        //    return assembly.AssemblyProductionParts
        //        .Select(p => new ProductionPartViewModel()
        //        {
        //            Name = p.ProductionPart.Name,
        //            DrawingNumber = p.ProductionPart.DrawingNumber,
        //            Material = p.ProductionPart.Material.MaterialNumber,
        //            AuthorSignature = p.ProductionPart.AuthorSignature
        //        });
        //}

        public async Task<IEnumerable<TypeOfProductionPart>> GetTypeOfProductionPartAsync()
        {
            return await context.TypeOfProductionParts.ToListAsync();
        }
    }
}
