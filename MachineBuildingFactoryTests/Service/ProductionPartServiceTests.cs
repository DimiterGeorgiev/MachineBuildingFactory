using FluentAssertions;
using MachineBuildingFactory.Data;
using MachineBuildingFactory.Data.Models;
using MachineBuildingFactory.Models;
using MachineBuildingFactory.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace MachineBuildingFactoryTests.Service
{
    public class ProductionPartServiceTests
    {
        private async Task<ApplicationDbContext> GetDbContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            var databaseContext = new ApplicationDbContext(options);
            databaseContext.Database.EnsureCreated();
            //databaseContext.Database.EnsureDeleted(); // // Не трием базата. За улеснение ще използваме базата, която се сийдва през ApplicatioDbContext за тестовете
            if (await databaseContext.ProductionParts.CountAsync() < 0)
            {
                databaseContext.Add(
                    new ProductionPart
                    {
                        Id = 5,
                        Name = "Consol",
                        Description = "This is just a probe part.",
                        Image = "https://files.fm/thumb_show.php?i=wuvwwvyyu",
                        TypeOfProductionPartId = 1,
                        CreatedOn = DateTime.Now,
                        AuthorSignature = "PP",
                        SurfaceArea = 2.3,
                        DrawingNumber = "CL-025-001",
                        Weight = 5.6,
                        SurfaceTreatment = (MachineBuildingFactory.Data.Enums.TypeOfSurfaceTreatment?)1,
                        TypeOfPaint = (MachineBuildingFactory.Data.Enums.TypeOfPaint?)2,
                        ColorOfPaintRal = (MachineBuildingFactory.Data.Enums.ColorOfPaintRal?)3,
                        LaserCutLength = 4.3,
                        MaterialId = 2
                    });
                databaseContext.Add(
                    new ProductionPart()
                    {
                        Id = 6,
                        Name = "Shaft",
                        Description = "Shaft for all target.",
                        Image = "https://files.fm/thumb_show.php?i=yanftmubg",
                        TypeOfProductionPartId = 2,
                        CreatedOn = DateTime.Now,
                        AuthorSignature = "TT",
                        SurfaceArea = 1.3,
                        DrawingNumber = "CL-025-002",
                        Weight = 8.6,
                        SurfaceTreatment = (MachineBuildingFactory.Data.Enums.TypeOfSurfaceTreatment?)2,
                        TypeOfPaint = (MachineBuildingFactory.Data.Enums.TypeOfPaint?)3,
                        ColorOfPaintRal = (MachineBuildingFactory.Data.Enums.ColorOfPaintRal?)1,
                        LaserCutLength = 5.9,
                        MaterialId = 3
                    });
                databaseContext.Add(
                    new ProductionPart()
                    {
                        Id = 7,
                        Name = "Base plate",
                        Description = "For all type of construction",
                        Image = "https://files.fm/thumb_show.php?i=avqbb8jgk",
                        TypeOfProductionPartId = 2,
                        CreatedOn = DateTime.Now,
                        AuthorSignature = "DD",
                        SurfaceArea = 5.3,
                        DrawingNumber = "BP-080-008",
                        Weight = 12.6,
                        SurfaceTreatment = (MachineBuildingFactory.Data.Enums.TypeOfSurfaceTreatment?)3,
                        TypeOfPaint = (MachineBuildingFactory.Data.Enums.TypeOfPaint?)2,
                        ColorOfPaintRal = (MachineBuildingFactory.Data.Enums.ColorOfPaintRal?)3,
                        LaserCutLength = 8.9,
                        MaterialId = 5
                    });
                databaseContext.Add(
                    new ProductionPart()
                    {
                        Id = 8,
                        Name = "Gear 34/69",
                        Description = "Gear for gearbox",
                        Image = "https://files.fm/thumb_show.php?i=n62awsh2s",
                        TypeOfProductionPartId = 1,
                        CreatedOn = DateTime.Now,
                        AuthorSignature = "TT",
                        SurfaceArea = 8.3,
                        DrawingNumber = "GB-200-036",
                        Weight = 6.6,
                        SurfaceTreatment = (MachineBuildingFactory.Data.Enums.TypeOfSurfaceTreatment?)3,
                        TypeOfPaint = (MachineBuildingFactory.Data.Enums.TypeOfPaint?)1,
                        ColorOfPaintRal = (MachineBuildingFactory.Data.Enums.ColorOfPaintRal?)1,
                        LaserCutLength = 0,
                        MaterialId = 4

                    });
                await databaseContext.SaveChangesAsync();
            }

            await databaseContext.SaveChangesAsync();
            return databaseContext;
        }

        [Fact]
        public async void ProductionPartService_CreatProductionPart_ReturnsSuccess()
        {
            //Arrange
            var databaseContext = await GetDbContext();
            var countBefor = await databaseContext.ProductionParts.CountAsync();

            var productionPartViewModel = new CreateProductionPartViewModel()
            {
                Name = "Brackets",
                Description = "Brackets for Frame",
                Image = "https://files.fm/thumb_show.php?i=qjugekfuf",
                TypeOfProductionPartId = 2,
                CreatedOn = DateTime.Now,
                AuthorSignature = "TT",
                SurfaceArea = 8.3,
                DrawingNumber = "GB-200-036",
                Weight = 6.6,
                SurfaceTreatment = (MachineBuildingFactory.Data.Enums.TypeOfSurfaceTreatment?)3,
                TypeOfPaint = (MachineBuildingFactory.Data.Enums.TypeOfPaint?)1,
                ColorOfPaintRal = (MachineBuildingFactory.Data.Enums.ColorOfPaintRal?)1,
                LaserCutLength = 0,
                MaterialId = 1
            };

            var productionPartService = new ProductionPartService(databaseContext);

            //Act
            _ = productionPartService.CreateProductionPartAsync(productionPartViewModel);

            var coutnAfter = await databaseContext.ProductionParts.CountAsync();

            //Assert
            coutnAfter.Should().Be(countBefor + 1);
        }

        [Fact]
        public async void ProductionPartService_AddProductionPartToAssemblyAsync_Success()
        {
            //Arrange
            var databaseContext = await GetDbContext();
            var productionPartService = new ProductionPartService(databaseContext);
            var productionPartId = 6;
            var assemblyId = 5;
            var quantity = 1;
            var assembly = await databaseContext.Assemblies.FindAsync(assemblyId); //.Result?.AssemblyProductionParts.Count();
            var countBefor = assembly?.AssemblyProductionParts.Count;

            //Act
            _ = productionPartService.AddProductionPartToAssemblyAsync(productionPartId, assemblyId, quantity);

            var currAssembly = await databaseContext.Assemblies.FindAsync(assemblyId); //.Result?.AssemblyProductionParts.Count();

            var count = currAssembly?.AssemblyProductionParts.Count;

            //Assert
            count.Should().Be(countBefor + 1);
        }

        [Fact]
        public async void DeleteAsync_Success()
        {
            //Arrange
            var id = 7;
            var databaseContext = await GetDbContext();
            var productionPartService = new ProductionPartService(databaseContext);
            var countBeforDelete = databaseContext.ProductionParts.Count();

            //Act
            _ = productionPartService.DeleteAsync(id);

            var count = databaseContext.ProductionParts.Count();

            //Assert
            count.Should().Be(countBeforDelete - 1);
        }

        [Fact]
        public async void EditProductionPartAsync_Success()
        {
            //Arrange
            var id = 8;
            var databaseContext = await GetDbContext();
            var productionPartService = new ProductionPartService(databaseContext);
            //var productionPart = await databaseContext.ProductionParts.FindAsync(id);  //FindAsync(id).Result?.Name;
            //var nameBeforEdit = productionPart?.Name;
            var model = await databaseContext.ProductionParts.FindAsync(id);

            var modelEdit = new EditProductionPartViewModel()
            {
                Id = model!.Id,
                Name = "NewName",
                Description = model.Description,
                Image = model.Image,
                TypeOfProductionPartId = model.TypeOfProductionPartId,
                CreatedOn = model.CreatedOn,
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

            //Act
            _ = productionPartService.EditProductionPartAsync(modelEdit);

            var productionPartAfterUpdate = await databaseContext.ProductionParts.FindAsync(id);  //.Result?.Name;
            var name = productionPartAfterUpdate?.Name;

            //Assert
            name.Should().Be("NewName");
        }

        [Fact]
        public async void EditQuantityOfProductionPartInAssemblyAsync_Success()
        {
            //Arrange
            var productionPartId = 10;
            var assemblyId = 4;
            var quantity = 2;
            var databaseContext = await GetDbContext();
            var productionPartService = new ProductionPartService(databaseContext);
            var assembly = await databaseContext.Assemblies.FindAsync(assemblyId);
            var model = await databaseContext.ProductionParts.FindAsync(productionPartId);
            var assemblyProductionPart = new AssemblyProductionPart();

            assembly?.AssemblyProductionParts.Add(assemblyProductionPart);

            assemblyProductionPart.ProductionPartId = model!.Id;
            assemblyProductionPart.AssemblyId = assembly!.Id;
            assemblyProductionPart.Quantity = 1;

            var currQuantity = assembly?.AssemblyProductionParts.FirstOrDefault(p => p.ProductionPartId == productionPartId)?.Quantity;

            //Act
            _ = productionPartService.EditQuantityOfProductionPartInAssemblyAsync(productionPartId, assemblyId, quantity);

            var assemblyAfter = await databaseContext.Assemblies.FindAsync(assemblyId);
            var newQuantity = assemblyAfter?.AssemblyProductionParts.FirstOrDefault(p => p.ProductionPartId == productionPartId)?.Quantity;

            //Assert
            newQuantity.Should().Be(quantity);
        }

        [Fact]
        public async void GetAllProductionPartsAsync_Success()
        {
            //Arrange
            var databaseContext = await GetDbContext();
            var productionPartService = new ProductionPartService(databaseContext);
            var countAll = await databaseContext.ProductionParts.CountAsync();

            //Act
            var result = await productionPartService.GetAllProductionPartsAsync();

            var count = result.Count();

            //Assert
            count.Should().Be(countAll);
        }

        [Fact]
        public async void GetForEditQuantityAsync_AddProducitonPartToAssemblyViewModel()
        {
            //Arrange
            var productionPartId = 10;
            var assemblyId = 4;
            var quantity = 2;
            var databaseContext = await GetDbContext();
            var productionPartService = new ProductionPartService(databaseContext);
            var assembly = await databaseContext.Assemblies.FindAsync(assemblyId);
            var model = await databaseContext.ProductionParts.FindAsync(productionPartId);

            var assemblyProductionPart = new AssemblyProductionPart();

            assembly?.AssemblyProductionParts.Add(assemblyProductionPart);

            assemblyProductionPart.ProductionPartId = model!.Id;
            assemblyProductionPart.AssemblyId = assembly!.Id;
            assemblyProductionPart.Quantity = quantity;

            //Act
            var result = await productionPartService.GetForEditQuantityAsync(productionPartId, assemblyId);

            var resulutQuantity = result.Quantity;

            //Assert
            resulutQuantity.Should().Be(quantity);
        }

        [Fact]
        public async void GetMaterialsAsync_ListMaterials()
        {
            //Arrenge
            var databaseContext = await GetDbContext();
            var productionPartService = new ProductionPartService(databaseContext);
            var expetedQuantityOfMaterials = await databaseContext.Materials.CountAsync();

            //Act
            var materialList = await productionPartService.GetMaterialsAsync();
            var quantityOfMaterials = materialList.Count();

            //Assert
            materialList.Should().BeOfType<List<Material>>();
            quantityOfMaterials.Should().Be(expetedQuantityOfMaterials);
        }

        [Fact]
        public async void GetProductionPartForEditAsync_EditProductionPartViewModel()
        {
            //Arrenge
            var databaseContext = await GetDbContext();
            var productionPartService = new ProductionPartService(databaseContext);
            var productionPartId = 10;

            //Act
            var result = await productionPartService.GetProductionPartForEditAsync(productionPartId);
            var resultProductionPartId = result.Id;

            //Assert
            result.Should().BeOfType<EditProductionPartViewModel>();
            resultProductionPartId.Should().Be(productionPartId);
        }

        [Fact]
        public async void GetTypeOfProductionPartAsync_ListTypeOfProductionPart()
        {
            //Arrenge
            var databaseContext = await GetDbContext();
            var productionPartService = new ProductionPartService(databaseContext);
            var expetedQuantityOfTypeOfProductionPart = await databaseContext.TypeOfProductionParts.CountAsync();

            //Act
            var TypeOfProductionPartList = await productionPartService.GetTypeOfProductionPartAsync();
            var quantityOfTypeOfProductionPart = TypeOfProductionPartList.Count();

            //Assert
            TypeOfProductionPartList.Should().BeOfType<List<TypeOfProductionPart>>();
            quantityOfTypeOfProductionPart.Should().Be(expetedQuantityOfTypeOfProductionPart);
        }

        [Fact]
        public async void RemoveProductionPartFromAssemblyAsync_Success()
        {
            //Arrange
            var databaseContext = await GetDbContext();
            var productionPartService = new ProductionPartService(databaseContext);
            var productionPartId = 6;
            var assemblyId = 5;
            var quantity = 1;
            var assembly = await databaseContext.Assemblies.FindAsync(assemblyId); //.Result?.AssemblyProductionParts.Count();

            _ = productionPartService.AddProductionPartToAssemblyAsync(productionPartId, assemblyId, quantity);
            var currAssembly = await databaseContext.Assemblies.FindAsync(assemblyId); //.Result?.AssemblyProductionParts.Count();
            var countBeforRemovePart = currAssembly?.AssemblyProductionParts.Count;

            //Act
            _ = productionPartService.RemoveProductionPartFromAssemblyAsync(productionPartId, assemblyId);
            var countAfterRemovePart = currAssembly?.AssemblyProductionParts.Count;

            //Assert
            countAfterRemovePart.Should().Be(countBeforRemovePart - 1);
        }
    }
}
