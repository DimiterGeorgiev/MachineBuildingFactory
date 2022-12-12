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
    public class TypeOfProductionPartServiceTests
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
        public async void TypeOfProductionPartService_CreateTypeOfProductionPartAsync_ReturnsSuccess()
        {
            //Arrange
            var databaseContext = await GetDbContext();
            var countBefor = await databaseContext.TypeOfProductionParts.CountAsync();
            var typeOfProductionPartService = new TypeOfProductionPartServices(databaseContext);

            var typeOfProductionPartViewModel = new CreateTypeOfProductionPartViewModel()
            {
                Name = "NewName"
            };

            //Act
            _ = typeOfProductionPartService.CreateTypeOfProductionPartAsync(typeOfProductionPartViewModel);

            var countAfter = await databaseContext.TypeOfProductionParts.CountAsync();

            //Assert
            countAfter.Should().Be(countBefor + 1);
        }

        [Fact]
        public async void TypeOfProductionPartService_EditTypeOfProductionPartAsync_ReturnsSuccess()
        {
            //Arrange
            var databaseContext = await GetDbContext();
            var typeOfProductionPartService = new TypeOfProductionPartServices(databaseContext);
            var id = 4;
            var model = await databaseContext.TypeOfProductionParts.FindAsync(id);
            var oldName = model!.Name;

            var modelEidt = new EditTypeOfProductionPartViewModel()
            {
                Id = model!.Id,
                Name = "NewName",
            };

            //Act
            _ = typeOfProductionPartService.EditTypeOfProductionPartAsync(modelEidt);

            var typeOfProductionPartAfterUpdate = await databaseContext.TypeOfProductionParts.FindAsync(id);
            var materialNumber = typeOfProductionPartAfterUpdate?.Name;

            //Assert
            materialNumber.Should().NotBe(oldName);
            materialNumber.Should().Be("NewName");
        }

        [Fact]
        public async void TypeOfProductionPartService_DeleteAsync_ReturnsSuccess()
        {
            //Arrange
            var id = 4;
            var databaseContext = await GetDbContext();
            var typeOfProductionPartService = new TypeOfProductionPartServices(databaseContext);
            var countBeforDelete = await databaseContext.TypeOfProductionParts.CountAsync();

            //Act
            _ = typeOfProductionPartService.DeleteAsync(id);

            var countAfterDelete = await databaseContext.TypeOfProductionParts.CountAsync();

            //Assert
            countAfterDelete.Should().Be(countBeforDelete - 1);
        }

        [Fact]
        public async void TypeOfProductionPartService_GetAllTypeOfProductionPartsAsync_ReturnsViewModel()
        {
            //Arrange
            var databaseContext = await GetDbContext();
            var typeOfProductionPartService = new TypeOfProductionPartServices(databaseContext);
            var countAll = await databaseContext.TypeOfProductionParts.CountAsync();

            //Act
            var result = await typeOfProductionPartService.GetAllTypeOfProductionPartsAsync();

            var count = result.Count();

            //Assert
            count.Should().Be(countAll);
        }

        [Fact]
        public async void TypeOfProductionPartService_GetMaterialForEditAsync_ReturnModel()
        {
            //Arrange
            var id = 4;
            var databaseContext = await GetDbContext();
            var typeOfProductionPartService = new TypeOfProductionPartServices(databaseContext);

            //Act
            var result = await typeOfProductionPartService.GetTypeOfProductionPartForEditAsync(id);
            var outputId = result.Id;

            //Assert
            result.Should().BeOfType<EditTypeOfProductionPartViewModel>();
            outputId.Should().Be(id);
        }









    }
}
