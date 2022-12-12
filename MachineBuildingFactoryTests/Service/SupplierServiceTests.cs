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
    public class SupplierServiceTests
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
        public async void SupplierService_CreateSupplierAsync_ReturnsSuccess()
        {
            //Arrange
            var databaseContext = await GetDbContext();
            var countBefor = await databaseContext.Manufacturers.CountAsync();
            var supplierService = new SupplierServices(databaseContext);

            var supplierViewModel = new CreateSupplierViewModel()
            {
                Name = "SupplierName",
                Email = "SupplierEmail",
                UrlAddress = "WebSite"
            };

            //Act
            _ = supplierService.CreateSupplierAsync(supplierViewModel);

            var countAfter = await databaseContext.Suppliers.CountAsync();

            //Assert
            countAfter.Should().Be(countBefor + 1);
        }

        [Fact]
        public async void SupplierService_EditSupplierAsync_ReturnsSuccess()
        {
            //Arrange
            var databaseContext = await GetDbContext();
            var supplierService = new SupplierServices(databaseContext);
            var id = 14;
            var model = await databaseContext.Suppliers.FindAsync(id);
            var oldName = model!.Name;

            var modelEidt = new EditSupplierViewModel()
            {
                Id = model!.Id,
                Name = "NewName",
                Email = model.Email,
                UrlAddress = model.UrlAddress
            };

            //Act
            _ = supplierService.EditSupplierAsync(modelEidt);

            var supplierAfterUpdate = await databaseContext.Suppliers.FindAsync(id);
            var name = supplierAfterUpdate?.Name;

            //Assert
            name.Should().NotBe(oldName);
            name.Should().Be("NewName");
        }

        [Fact]
        public async void SupplierService_DeleteAsync_ReturnsSuccess()
        {
            //Arrange
            var id = 14;
            var databaseContext = await GetDbContext();
            var supplierService = new SupplierServices(databaseContext);
            var countBeforDelete = await databaseContext.Suppliers.CountAsync();

            //Act
            _ = supplierService.DeleteAsync(id);

            var countAfterDelete = await databaseContext.Suppliers.CountAsync();

            //Assert
            countAfterDelete.Should().Be(countBeforDelete - 1);
        }

        [Fact]
        public async void SupplierService_GetAllSuppliersAsync_ReturnsViewModel()
        {
            //Arrange
            var databaseContext = await GetDbContext();
            var supplierService = new SupplierServices(databaseContext);
            var countAll = await databaseContext.Suppliers.CountAsync();

            //Act
            var result = await supplierService.GetAllSuppliersAsync();

            var count = result.Count();

            //Assert
            count.Should().Be(countAll);
        }

        [Fact]
        public async void SupplierService_GetSupplierForEditAsync_ReturnModel()
        {
            //Arrange
            var id = 14;
            var databaseContext = await GetDbContext();
            var supplierService = new SupplierServices(databaseContext);

            //Act
            var result = await supplierService.GetSupplierForEditAsync(id);
            var outputId = result.Id;

            //Assert
            result.Should().BeOfType<EditSupplierViewModel>();
            outputId.Should().Be(id);
        }
    }
}
