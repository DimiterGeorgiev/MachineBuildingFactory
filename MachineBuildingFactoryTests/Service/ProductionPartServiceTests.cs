using FluentAssertions;
using MachineBuildingFactory.Data;
using MachineBuildingFactory.Data.Models;
using MachineBuildingFactory.Models;
using MachineBuildingFactory.Services;
using Microsoft.EntityFrameworkCore;
using System;
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
                        //SurfaceTreatment = (Enums.TypeOfSurfaceTreatment?)1,
                        //TypeOfPaint = (Enums.TypeOfPaint?)2,
                        //ColorOfPaintRal = (Enums.ColorOfPaintRal?)3,
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
                        //SurfaceTreatment = (Enums.TypeOfSurfaceTreatment?)2,
                        //TypeOfPaint = (Enums.TypeOfPaint?)3,
                        //ColorOfPaintRal = (Enums.ColorOfPaintRal?)1,
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
                        //SurfaceTreatment = (Enums.TypeOfSurfaceTreatment?)3,
                        //TypeOfPaint = (Enums.TypeOfPaint?)2,
                        //ColorOfPaintRal = (Enums.ColorOfPaintRal?)3,
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
                        //SurfaceTreatment = (Enums.TypeOfSurfaceTreatment?)3,
                        //TypeOfPaint = (Enums.TypeOfPaint?)1,
                        //ColorOfPaintRal = (Enums.ColorOfPaintRal?)1,
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
            var databaseContext = await GetDbContext();
            var countBefor = await databaseContext.ProductionParts.CountAsync();

            //Arrange
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

            var coutn = await databaseContext.ProductionParts.CountAsync();

            //Assert
            coutn.Should().Be(countBefor + 1);
        }
    }
}
