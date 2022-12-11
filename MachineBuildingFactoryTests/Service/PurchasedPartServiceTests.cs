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
    public class PurchasedPartServiceTests
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
        public async void PurchasedPartService_CreatPurchasedPart_ReturnsSuccess()
        {
            //Arrange
            var databaseContext = await GetDbContext();
            var countBefor = await databaseContext.PurchasedParts.CountAsync();

            var purchasedPartViewModel = new CreatePurchasedPartViewModel()
            {
                Name = "Pillow block bearing",
                ItemNumber = "SKF SY 35 TR",
                SupplierId = 13,
                ManufacturerId = 7,
                Description = "For material handling applications",
                Image = "https://files.fm/thumb_show.php?i=a62t5h3r2",
                Weight = 1.3,
                Standard = "ISO 55629"
            };

            var purchasedPartService = new PurchasedPartService(databaseContext);

            //Act
            _ = purchasedPartService.CreatePurchasedPartAsync(purchasedPartViewModel);

            var count = await databaseContext.PurchasedParts.CountAsync();

            //Assert
            count.Should().Be(countBefor + 1);
        }

        [Fact]
        public async void PurchasedPartService_AddProductionPartToAssembly_Success()
        {
            //Arrange
            var databaseContext = await GetDbContext();
            var purchasedPartService = new PurchasedPartService(databaseContext);
            var purchasedPartId = 6;
            var assemblyId = 5;
            var quantity = 1;
            var assembly = await databaseContext.Assemblies.FindAsync(assemblyId);
            var countBefor = assembly?.AssemblyPurchаsedParts.Count;

            //Act
            _ = purchasedPartService.AddPurchasedPartToAssemblyAsync(purchasedPartId, assemblyId, quantity);

            var currAssembly = await databaseContext.Assemblies.FindAsync(assemblyId);

            var count = currAssembly?.AssemblyPurchаsedParts.Count;

            //Assert
            count.Should().Be(countBefor + 1);
        }

        [Fact]
        public async void DeleteAsync_Success()
        {
            //Arrange
            var id = 7;
            var databaseContext = await GetDbContext();
            var purchasedPartService = new PurchasedPartService(databaseContext);
            var countBeforDelete = databaseContext.PurchasedParts.Count();

            //Act
            _ = purchasedPartService.DeleteAsync(id);

            var count = databaseContext.PurchasedParts.Count();

            //Assert
            count.Should().Be(countBeforDelete - 1);
        }

        [Fact]
        public async void EditPurchasedPartAsync_Success()
        {
            //Arrange
            var id = 8;
            var databaseContext = await GetDbContext();
            var purchasedPartService = new PurchasedPartService(databaseContext);
            var model = await databaseContext.PurchasedParts.FindAsync(id);

            var modelEdit = new EditPurchasedPartViewModel()
            {
                Id = model!.Id,
                Name = "NewName",
                Description = model.Description!,
                Image = model.Image!,
                ItemNumber = model.ItemNumber,
                SupplierId = model.SupplierId,
                ManufacturerId = model.ManufacturerId,
                Weight = model.Weight,
                Standard = model.Standard
            };

            //Act
            _ = purchasedPartService.EditPurchasedPartAsync(modelEdit);

            var purchasedPartAfterUpdate = await databaseContext.PurchasedParts.FindAsync(id);
            var name = purchasedPartAfterUpdate?.Name;

            //Assert
            name.Should().Be("NewName");
        }

        [Fact]
        public async void EditQuantityOfPurchasedPartInAssemblyAsync_Success()
        {
            //Arrange
            var purchasedPartId = 6;
            var assemblyId = 4;
            var quantity = 2;
            var databaseContext = await GetDbContext();
            var purchasedPartService = new PurchasedPartService(databaseContext);
            var assembly = await databaseContext.Assemblies.FindAsync(assemblyId);
            var model = await databaseContext.PurchasedParts.FindAsync(purchasedPartId);
            var assemblyPurchasedPart = new AssemblyPurchasedPart();

            assembly?.AssemblyPurchаsedParts.Add(assemblyPurchasedPart);

            assemblyPurchasedPart.PurchasedPartId = model!.Id;
            assemblyPurchasedPart.AssemblyId = assembly!.Id;
            assemblyPurchasedPart.Quantity = 1;

            var currQuantity = assembly?.AssemblyPurchаsedParts.FirstOrDefault(p => p.PurchasedPartId == purchasedPartId)?.Quantity;

            //Act
            _ = purchasedPartService.EditQuantityOfPurchasedPartInAssemblyAsync(purchasedPartId, assemblyId, quantity);

            var assemblyAfter = await databaseContext.Assemblies.FindAsync(assemblyId);
            var newQuantity = assemblyAfter?.AssemblyPurchаsedParts.FirstOrDefault(p => p.PurchasedPartId == purchasedPartId)?.Quantity;

            //Assert
            newQuantity.Should().Be(quantity);
        }

        [Fact]
        public async void GetAllPurchasedPartsAsync_Success()
        {
            //Arrange
            var databaseContext = await GetDbContext();
            var purchasedPartService = new PurchasedPartService(databaseContext);
            var countAll = await databaseContext.PurchasedParts.CountAsync();

            //Act
            var result = await purchasedPartService.GetAllPurchasedPartsAsync();

            var count = result.Count();

            //Assert
            count.Should().Be(countAll);
        }

        [Fact]
        public async void GetForEditQuantityAsync_AddPurchasedPartToAssemblyViewModel()
        {
            //Arrange
            var purchasedPartId = 6;
            var assemblyId = 4;
            var quantity = 2;
            var databaseContext = await GetDbContext();
            var purchasedPartService = new PurchasedPartService(databaseContext);
            var assembly = await databaseContext.Assemblies.FindAsync(assemblyId);
            var model = await databaseContext.PurchasedParts.FindAsync(purchasedPartId);
            var assemblyPurchasedPart = new AssemblyPurchasedPart();

            assembly?.AssemblyPurchаsedParts.Add(assemblyPurchasedPart);

            assemblyPurchasedPart.PurchasedPartId = model!.Id;
            assemblyPurchasedPart.AssemblyId = assembly!.Id;
            assemblyPurchasedPart.Quantity = quantity;

            //Act
            var result = await purchasedPartService.GetForEditQuantityAsync(purchasedPartId, assemblyId);

            var resulutQuantity = result.Quantity;

            //Assert
            resulutQuantity.Should().Be(quantity);
        }

        [Fact]
        public async void GetManufactursAsync_ListManufactures()
        {
            //Arrenge
            var databaseContext = await GetDbContext();
            var purchasedPartService = new PurchasedPartService(databaseContext);
            var expetedQuantityOfMaterials = await databaseContext.Manufacturers.CountAsync();

            //Act
            var manufacturesList = await purchasedPartService.GetManufactursAsync();
            var quantityOfManufactures = manufacturesList.Count();

            //Assert
            manufacturesList.Should().BeOfType<List<Manufacturer>>();
            quantityOfManufactures.Should().Be(expetedQuantityOfMaterials);
        }

        [Fact]
        public async void GetPurchasedPartForEditAsync_EditPurchasedPartViewModel()
        {
            //Arrenge
            var databaseContext = await GetDbContext();
            var purchasedPartService = new PurchasedPartService(databaseContext);
            var purchasedPartId = 8;

            //Act
            var result = await purchasedPartService.GetPurchasedPartForEditAsync(purchasedPartId);
            var resultPurchasedPartId = result.Id;

            //Assert
            result.Should().BeOfType<EditPurchasedPartViewModel>();
            resultPurchasedPartId.Should().Be(purchasedPartId);
        }

        [Fact]
        public async void GetSupplierAsync_ListSupplier()
        {
            //Arrenge
            var databaseContext = await GetDbContext();
            var purchsedPartService = new PurchasedPartService(databaseContext);
            var expetedQuantitySuppliers = await databaseContext.Suppliers.CountAsync();

            //Act
            var SupplierList = await purchsedPartService.GetSuppliersAsync();
            var quantityOfSupplier = SupplierList.Count();

            //Assert
            SupplierList.Should().BeOfType<List<Supplier>>();
            quantityOfSupplier.Should().Be(expetedQuantitySuppliers);
        }

        [Fact]
        public async void RemovePurchasedPartFromAssemblyAsync_Success()
        {
            //Arrange
            var databaseContext = await GetDbContext();
            var purchasedPartService = new PurchasedPartService(databaseContext);
            var purchsedPartId = 6;
            var assemblyId = 5;
            var quantity = 1;
            var assembly = await databaseContext.Assemblies.FindAsync(assemblyId);

            _ = purchasedPartService.AddPurchasedPartToAssemblyAsync(purchsedPartId, assemblyId, quantity);
            var currAssembly = await databaseContext.Assemblies.FindAsync(assemblyId);
            var countBeforRemovePart = currAssembly?.AssemblyPurchаsedParts.Count;

            //Act
            _ = purchasedPartService.RemovePurchasedPartFromAssemblyAsync(purchsedPartId, assemblyId);
            var countAfterRemovePart = currAssembly?.AssemblyPurchаsedParts.Count;

            //Assert
            countAfterRemovePart.Should().Be(countBeforRemovePart - 1);
        }
    }
}
