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
    public class AssemblyServiceTests
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
        public async void AssemblyService_AddAssemblyToCollectionAsync_Success()
        {
            //Arrange
            var id = 6;
            var userId = "a719be14-6ee5-4a10-a1b6-382fc43c4d0b";
            var databaseContext = await GetDbContext();
            var assebmlyService = new AssemblyService(databaseContext);
            var user = await databaseContext.Users.FindAsync(userId);
            var resultBefor = user?.ApplicationUserAssemblys.FirstOrDefault();

            //Act
            _ = assebmlyService.AddAssemblyToCollectionAsync(id, userId);

            var resultAfter = user?.ApplicationUserAssemblys.FirstOrDefault();

            //Assert
            resultBefor.Should().BeNull();
            resultAfter.Should().NotBeNull();
        }

        [Fact]
        public async void AssemblySerivce_CreateAssemblyAsync_ReturnsSuccess()
        {
            //Arrange
            var databaseContext = await GetDbContext();
            var coutnBefor = await databaseContext.Assemblies.CountAsync();

            var assemblyCreateViewModel = new CreateAssemblyViewModel()
            {
                Name = "Weld construction",
                DrawingNumber = "CW-001-00",
                Description = "Base support for hole construction",
                Image = "https://files.fm/thumb_show.php?i=e3en9mxbj",
                AuthorSignature = "GG",
            };

            var asseblyService = new AssemblyService(databaseContext);

            //Act
            _ = asseblyService.CreateAssemblyAsync(assemblyCreateViewModel);

            var coutnAfter = await databaseContext.Assemblies.CountAsync();

            //Assert
            coutnAfter.Should().Be(coutnBefor + 1);
        }

        [Fact]
        public async void AssemblyService_EditAssemblyAsync_ReturnsSuccess()
        {
            //Arrange
            var id = 6;
            var databaseContext = await GetDbContext();
            var asseblyService = new AssemblyService(databaseContext);
            var model = await databaseContext.Assemblies.FindAsync(id);

            var nameBeforUpdate = model!.Name;

            var modelEdit = new EditAssemblyViewModel()
            {
                Id = model!.Id,
                Name = "NewName",
                Description = model.Description!,
                DrawingNumber = model.DrawingNumber,
                Image = model.Image!,
                AuthorSignature = model.AuthorSignature
            };

            //Act
            _ = asseblyService.EditAssemblyAsync(modelEdit);

            var assemblyAfterUpdate = await databaseContext.Assemblies.FindAsync(id);
            var nameAfterUpdate = assemblyAfterUpdate?.Name;

            //Assert
            nameBeforUpdate.Should().NotBe("NewName");
            nameAfterUpdate.Should().Be("NewName");
        }

        [Fact]
        public async void AssemblyService_GetAssemblyForEditAsync_ReturnsModel()
        {
            //Arrange
            var assemblyId = 6;
            var databaseContext = await GetDbContext();
            var asseblyService = new AssemblyService(databaseContext);

            //Act
            var result = await asseblyService.GetAssemblyForEditAsync(assemblyId);
            var resultAssemblyId = result.Id;

            //Assert
            result.Should().BeOfType<EditAssemblyViewModel>();
            resultAssemblyId.Should().Be(assemblyId);
        }

        [Fact]
        public async void AssemblyServic_GetMineAssembliesAsync_ReturnsTask()
        {
            //Arrange
            var id = 6;
            var userId = "a719be14-6ee5-4a10-a1b6-382fc43c4d0b";
            var databaseContext = await GetDbContext();
            var assebmlyService = new AssemblyService(databaseContext);
            var user = await databaseContext.Users.FindAsync(userId);
            //var resultBefor = user?.ApplicationUserAssemblys.FirstOrDefault();
            _ = assebmlyService.AddAssemblyToCollectionAsync(id, userId);

            //Act
            var resultAsTask = assebmlyService.GetMineAssembliesAsync(userId);
            var result = await assebmlyService.GetMineAssembliesAsync(userId);
            var resultCount = result.Count();

            //Assert
            resultAsTask.Should().BeOfType<Task<IEnumerable<AssemblyViewModel>>>();
            resultCount.Should().NotBe(0);
        }


        [Fact]
        public async void AssemblyService_GetProductionPartListFromAssemblyAsync_ReturnsTask()
        {
            //Arrange
            var databaseContext = await GetDbContext();
            var assebmlyService = new AssemblyService(databaseContext);
            var productionPartService = new ProductionPartService(databaseContext);
            var productionPartId = 6;
            var assemblyId = 5;
            var quantity = 1;

            //Act
            _ = productionPartService.AddProductionPartToAssemblyAsync(productionPartId, assemblyId, quantity);
            var resultAsTask = assebmlyService.GetProductionPartListFromAssemblyAsync(assemblyId);
            var result = await assebmlyService.GetProductionPartListFromAssemblyAsync(assemblyId);
            var quantityInResultList = result.Count();

            //Assert
            resultAsTask.Should().BeOfType<Task<IEnumerable<ProductionPartViewModel>>>();
            quantityInResultList.Should().NotBe(0);
        }

        [Fact]
        public async void AssemblyService_GetWhereUsedAssembliesAsync()
        {
            //Arrange
            var databaseContext = await GetDbContext();
            var assebmlyService = new AssemblyService(databaseContext);
            var productionPartService = new ProductionPartService(databaseContext);
            var productionPartId = 6;
            var assemblyId = 5;
            var quantity = 1;
            _ = productionPartService.AddProductionPartToAssemblyAsync(productionPartId, assemblyId, quantity);

            //Act
            var resultAsTask = assebmlyService.GetWhereUsedAssembliesAsync(productionPartId);
            var result = await assebmlyService.GetWhereUsedAssembliesAsync(productionPartId);
            var fountassemblyId = result.FirstOrDefault()?.Id;

            //Assert
            resultAsTask.Should().BeOfType<Task<IEnumerable<AssemblyViewModel>>>();
            fountassemblyId.Should().Be(assemblyId);
        }

        [Fact]
        public async void AssemblyService_SetAssemblyAsWorkingAsync_ReturnsSuccess()
        {
            //Arrange
            var databaseContext = await GetDbContext();
            var assebmlyService = new AssemblyService(databaseContext);
            var assemblyId = 5;
            var userId = "a719be14-6ee5-4a10-a1b6-382fc43c4d0b";
            var user = await databaseContext.Users.FindAsync(userId);

            //Act
            _ = assebmlyService.SetAssemblyAsWorkingAsync(assemblyId, userId);

            var workingAssemblyId = user!.WorkingAssembly.FirstOrDefault()?.AssemblyId;

            //Assert
            workingAssemblyId.Should().Be(assemblyId);
        }

        [Fact]
        public async void AssemblyService_GetWorkingAssemblyAsync_ReturnsTask()
        {
            //Arrange
            var databaseContext = await GetDbContext();
            var assebmlyService = new AssemblyService(databaseContext);
            var assemblyId = 5;
            var userId = "a719be14-6ee5-4a10-a1b6-382fc43c4d0b";
            var user = await databaseContext.Users.FindAsync(userId);
            _ = assebmlyService.SetAssemblyAsWorkingAsync(assemblyId, userId);

            //Act
            var resultAsTask = assebmlyService.GetWorkingAssemblyAsync(userId);

            var result = await assebmlyService.GetWorkingAssemblyAsync(userId);

            var resultId = result.Id;

            //Assert
            resultAsTask.Should().BeOfType<Task<AssemblyViewModel>>();
            result.Should().BeOfType<AssemblyViewModel>();
            resultId.Should().Be(assemblyId);
        }

        [Fact]
        public async void AssemblyService_RemoveAssemblyFromCollectionAsync_ReturnsSuccess()
        {
            //Arrange
            var id = 6;
            var userId = "a719be14-6ee5-4a10-a1b6-382fc43c4d0b";
            var databaseContext = await GetDbContext();
            var assebmlyService = new AssemblyService(databaseContext);
            var user = await databaseContext.Users.FindAsync(userId);
            _ = assebmlyService.AddAssemblyToCollectionAsync(id, userId);
            var resultBeforRemove = user?.ApplicationUserAssemblys.Count;

            //Act
            _ = assebmlyService.RemoveAssemblyFromCollectionAsync(id, userId);

            var resultAfterRemove = user?.ApplicationUserAssemblys.Count;

            //Assert
            resultAfterRemove.Should().Be(resultBeforRemove - 1);
        }

        [Fact]
        public async void AssemblyService_GetAssemblyById_ReturnsAssembly()
        {
            //Arrange
            var databaseContext = await GetDbContext();
            var assebmlyService = new AssemblyService(databaseContext);
            var id = 6;

            //Act
            var result = await assebmlyService.GetAssemblyById(id);

            var resultId = result.Id;

            //Assert
            result.Should().BeOfType<Assembly>();
            resultId.Should().Be(id);
        }

        [Fact]
        public async void AssemblyService_GetWhereUsedPurchasedPartAssembliesAsync_ReturnsTask()
        {
            //Arrange
            var databaseContext = await GetDbContext();
            var assebmlyService = new AssemblyService(databaseContext);
            var purchasedPartService = new PurchasedPartService(databaseContext);
            var purchasedPartId = 6;
            var assemblyId = 5;
            var quantity = 1;
            _ = purchasedPartService.AddPurchasedPartToAssemblyAsync(purchasedPartId, assemblyId, quantity);

            //Act
            var resultAsTask = assebmlyService.GetWhereUsedPurchasedPartAssembliesAsync(purchasedPartId);
            var result = await assebmlyService.GetWhereUsedPurchasedPartAssembliesAsync(purchasedPartId);
            var fountassemblyId = result.FirstOrDefault()?.Id;

            //Assert
            resultAsTask.Should().BeOfType<Task<IEnumerable<AssemblyViewModel>>>();
            fountassemblyId.Should().Be(assemblyId);
        }

        [Fact]
        public async void AssemblyService_GetPurchasedPartListFromAssemblyAsync_ReturnsTask()
        {
            //Arrange
            var databaseContext = await GetDbContext();
            var assebmlyService = new AssemblyService(databaseContext);
            var purchasedPartService = new PurchasedPartService(databaseContext);
            var purchasedPartId = 6;
            var assemblyId = 5;
            var quantity = 1;

            //Act
            _ = purchasedPartService.AddPurchasedPartToAssemblyAsync(purchasedPartId, assemblyId, quantity);
            var resultAsTask = assebmlyService.GetPurchasedPartListFromAssemblyAsync(assemblyId);
            var result = await assebmlyService.GetPurchasedPartListFromAssemblyAsync(assemblyId);
            var quantityInResultList = result.Count();

            //Assert
            resultAsTask.Should().BeOfType<Task<IEnumerable<PurchasedPartViewModel>>>();
            quantityInResultList.Should().NotBe(0);
        }

        [Fact]
        public async void AssemblyService_GetWhereUsedManufacturerAssembliesAsync_ReturnsTask()
        {
            //Arrange
            var databaseContext = await GetDbContext();
            var assebmlyService = new AssemblyService(databaseContext);
            var purchasedPartService = new PurchasedPartService(databaseContext);
            var purchasedPartId = 6;
            var assemblyId = 5;
            var quantity = 1;
            _ = purchasedPartService.AddPurchasedPartToAssemblyAsync(purchasedPartId, assemblyId, quantity);
            var purchasedPart = await databaseContext.PurchasedParts.FindAsync(purchasedPartId);
            var manufacturerId = purchasedPart!.ManufacturerId;


            //Act
            var resultAsTask = assebmlyService.GetWhereUsedManufacturerAssembliesAsync(manufacturerId);
            var result = await assebmlyService.GetWhereUsedManufacturerAssembliesAsync(manufacturerId);
            var fountassemblyId = result.FirstOrDefault()?.Id;

            //Assert
            resultAsTask.Should().BeOfType<Task<IEnumerable<AssemblyViewModel>>>();
            fountassemblyId.Should().Be(assemblyId);
        }

        [Fact]
        public async void AssemblyService_GetWhereUsedSupplierAssembliesAsync_ReturnsTask()
        {
            //Arrange
            var databaseContext = await GetDbContext();
            var assebmlyService = new AssemblyService(databaseContext);
            var purchasedPartService = new PurchasedPartService(databaseContext);
            var purchasedPartId = 6;
            var assemblyId = 5;
            var quantity = 1;
            _ = purchasedPartService.AddPurchasedPartToAssemblyAsync(purchasedPartId, assemblyId, quantity);
            var purchasedPart = await databaseContext.PurchasedParts.FindAsync(purchasedPartId);
            var supplierId = purchasedPart!.SupplierId;

            //Act
            var resultAsTask = assebmlyService.GetWhereUsedSupplierAssembliesAsync(supplierId);
            var result = await assebmlyService.GetWhereUsedSupplierAssembliesAsync(supplierId);
            var fountassemblyId = result.FirstOrDefault()?.Id;

            //Assert
            resultAsTask.Should().BeOfType<Task<IEnumerable<AssemblyViewModel>>>();
            fountassemblyId.Should().Be(assemblyId);
        }

        [Fact]
        public async void AssemblyService_GetWhereUsedMaterialAssembliesAsync_ReturnsTask()
        {
            var databaseContext = await GetDbContext();
            var assebmlyService = new AssemblyService(databaseContext);
            var productionPartService = new ProductionPartService(databaseContext);
            var productionPartId = 6;
            var assemblyId = 5;
            var quantity = 1;
            _ = productionPartService.AddProductionPartToAssemblyAsync(productionPartId, assemblyId, quantity);
            var productionPart = await databaseContext.ProductionParts.FindAsync(productionPartId);
            var materialId = productionPart!.MaterialId;

            //Act
            var resultAsTask = assebmlyService.GetWhereUsedMaterialAssembliesAsync((int)materialId!);
            var result = await assebmlyService.GetWhereUsedMaterialAssembliesAsync((int)materialId!);
            var fountassemblyId = result.FirstOrDefault()?.Id;

            //Assert
            resultAsTask.Should().BeOfType<Task<IEnumerable<AssemblyViewModel>>>();
            fountassemblyId.Should().Be(assemblyId);
        }

        [Fact]
        public async void AssemblyService_GetWhereUsedTypeOfProductionPartAssembliesAsync_ReturnsTask()
        {
            var databaseContext = await GetDbContext();
            var assebmlyService = new AssemblyService(databaseContext);
            var productionPartService = new ProductionPartService(databaseContext);
            var productionPartId = 6;
            var assemblyId = 5;
            var quantity = 1;
            _ = productionPartService.AddProductionPartToAssemblyAsync(productionPartId, assemblyId, quantity);
            var productionPart = await databaseContext.ProductionParts.FindAsync(productionPartId);
            var typeOfProductionPartId = productionPart!.TypeOfProductionPartId;

            //Act
            var resultAsTask = assebmlyService.GetWhereUsedTypeOfProductionPartAssembliesAsync(typeOfProductionPartId);
            var result = await assebmlyService.GetWhereUsedTypeOfProductionPartAssembliesAsync(typeOfProductionPartId);
            var fountassemblyId = result.FirstOrDefault()?.Id;

            //Assert
            resultAsTask.Should().BeOfType<Task<IEnumerable<AssemblyViewModel>>>();
            fountassemblyId.Should().Be(assemblyId);
        }



    }
}
