using FluentAssertions;
using MachineBuildingFactory.Areas.Management.Models;
using MachineBuildingFactory.Areas.Management.Services;
using MachineBuildingFactory.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace MachineBuildingFactoryTests.Service
{
    public class ManufacturerServiceTests
    {
        private async Task<ApplicationDbContext> GetDbContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            var databaseContext = new ApplicationDbContext(options);
            databaseContext.Database.EnsureCreated();
            //databaseContext.Database.EnsureDeleted(); // Не трием базата. За улеснение ще използваме базата, която се сийдва през ApplicatioDbContext за тестовете

            await databaseContext.SaveChangesAsync();
            return databaseContext;
        }

        [Fact]
        public async void ManufacturerService_CreateManufacturerAsync_ReturnsSuccess()
        {
            //Arrange
            var databaseContext = await GetDbContext();
            var countBefor = await databaseContext.Manufacturers.CountAsync();
            var manufacturerService = new ManufacturerServices(databaseContext);

            var manufacturerViewModel = new CreateManufacturerViewModel()
            {
                Name = "ManufacturerName",
                Email = "ManufacturerEmail",
                UrlAddress = "WebSite"
            };

            //Act
            _ = manufacturerService.CreateManufacturerAsync(manufacturerViewModel);

            var countAfter = await databaseContext.Manufacturers.CountAsync();

            //Assert
            countAfter.Should().Be(countBefor + 1);
        }

        [Fact]
        public async void ManufacturerService_EditManufacturerAsync_ReturnsSuccess()
        {
            //Arrange
            var databaseContext = await GetDbContext();
            var manufacturerService = new ManufacturerServices(databaseContext);
            var id = 6;
            var model = await databaseContext.Manufacturers.FindAsync(id);
            var oldName = model!.Name;

            var modelEidt = new EditManufacturerViewModel()
            {
                Id = model!.Id,
                Name = "NewName",
                Email = model.Email,
                UrlAddress = model.UrlAddress
            };

            //Act
            _ = manufacturerService.EditManufacturerAsync(modelEidt);

            var manufacturerAfterUpdate = await databaseContext.Manufacturers.FindAsync(id);
            var name = manufacturerAfterUpdate?.Name;

            //Assert
            name.Should().NotBe(oldName);
            name.Should().Be("NewName");
        }

        [Fact]
        public async void ManufacturerService_DeleteAsync_ReturnsSuccess()
        {
            //Arrange
            var id = 7;
            var databaseContext = await GetDbContext();
            var manufacturerService = new ManufacturerServices(databaseContext);
            var countBeforDelete = await databaseContext.Manufacturers.CountAsync();

            //Act
            _ = manufacturerService.DeleteAsync(id);

            var countAfterDelete = await databaseContext.Manufacturers.CountAsync();

            //Assert
            countAfterDelete.Should().Be(countBeforDelete - 1);
        }

        [Fact]
        public async void ManufacturerService_GetAllManufacturersAsync_ReturnsViewModel()
        {
            //Arrange
            var databaseContext = await GetDbContext();
            var manufacturerService = new ManufacturerServices(databaseContext);
            var countAll = await databaseContext.Manufacturers.CountAsync();

            //Act
            var result = await manufacturerService.GetAllManufacturersAsync();

            var count = result.Count();

            //Assert
            count.Should().Be(countAll);
        }

        [Fact]
        public async void ManufacturerService_GetManufacturerForEditAsync_ReturnModel()
        {
            //Arrange
            var id = 7;
            var databaseContext = await GetDbContext();
            var manufacturerService = new ManufacturerServices(databaseContext);

            //Act
            var result = await manufacturerService.GetManufacturerForEditAsync(id);
            var outputId = result.Id;

            //Assert
            result.Should().BeOfType<EditManufacturerViewModel>();
            outputId.Should().Be(id);
        }





    }
}
