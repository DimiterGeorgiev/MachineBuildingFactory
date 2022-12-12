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
    public class MaterialServiceTests
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
        public async void MaterialService_CreateMaterialAsync_ReturnsSuccess()
        {
            //Arrange
            var databaseContext = await GetDbContext();
            var countBefor = await databaseContext.Materials.CountAsync();
            var materialService = new MaterialServices(databaseContext);

            var materialViewModel = new CreateMaterialViewModel()
            {
                MaterialNumber = "NewMaterial"
            };

            //Act
            _ = materialService.CreateMaterialAsync(materialViewModel);

            var countAfter = await databaseContext.Materials.CountAsync();

            //Assert
            countAfter.Should().Be(countBefor + 1);
        }

        [Fact]
        public async void MaterialService_EditMaterialAsync_ReturnsSuccess()
        {
            //Arrange
            var databaseContext = await GetDbContext();
            var materialService = new MaterialServices(databaseContext);
            var id = 4;
            var model = await databaseContext.Materials.FindAsync(id);
            var oldName = model!.MaterialNumber;

            var modelEidt = new EditMaterialViewModel()
            {
                Id = model!.Id,
                MaterialNumber = "NewMaterialNumber",
            };

            //Act
            _ = materialService.EditMaterialAsync(modelEidt);

            var materialAfterUpdate = await databaseContext.Materials.FindAsync(id);
            var materialNumber = materialAfterUpdate?.MaterialNumber;

            //Assert
            materialNumber.Should().NotBe(oldName);
            materialNumber.Should().Be("NewMaterialNumber");
        }

        [Fact]
        public async void MaterialService_DeleteAsync_ReturnsSuccess()
        {
            //Arrange
            var id = 4;
            var databaseContext = await GetDbContext();
            var materialService = new MaterialServices(databaseContext);
            var countBeforDelete = await databaseContext.Materials.CountAsync();

            //Act
            _ = materialService.DeleteAsync(id);

            var countAfterDelete = await databaseContext.Materials.CountAsync();

            //Assert
            countAfterDelete.Should().Be(countBeforDelete - 1);
        }

        [Fact]
        public async void MaterialService_GetAllMaterialsAsync_ReturnsViewModel()
        {
            //Arrange
            var databaseContext = await GetDbContext();
            var materialService = new MaterialServices(databaseContext);
            var countAll = await databaseContext.Materials.CountAsync();

            //Act
            var result = await materialService.GetAllMaterialsAsync();

            var count = result.Count();

            //Assert
            count.Should().Be(countAll);
        }

        [Fact]
        public async void MateraialService_GetMaterialForEditAsync_ReturnModel()
        {
            //Arrange
            var id = 4;
            var databaseContext = await GetDbContext();
            var materialService = new MaterialServices(databaseContext);

            //Act
            var result = await materialService.GetMaterialForEditAsync(id);
            var outputId = result.Id;

            //Assert
            result.Should().BeOfType<EditMaterialViewModel>();
            outputId.Should().Be(id);
        }





    }
}
