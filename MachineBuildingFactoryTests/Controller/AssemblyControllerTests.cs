using FakeItEasy;
using FluentAssertions;
using MachineBuildingFactory.Contracts;
using MachineBuildingFactory.Controllers;
using MachineBuildingFactory.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace MachineBuildingFactoryTests.Controller
{
    public class AssemblyControllerTests
    {
        private AssemblyController assemblyController;
        private IAssemblyService db;
        private IProductionPartService dbProductionPart;
        private IPurchasedPartService dbPurchasedPart;

        public AssemblyControllerTests()
        {
            //Depen
            db = A.Fake<IAssemblyService>();
            dbProductionPart = A.Fake<IProductionPartService>();
            dbPurchasedPart = A.Fake<IPurchasedPartService>();
            //SUT
            assemblyController = new AssemblyController(db, dbProductionPart);
        }

        [Fact]
        public void AllAssemblies_ReturnsModel()
        {
            //Arrange
            var model = A.Fake<IEnumerable<AssemblyViewModel>>();
            A.CallTo(() => db.GetAllAssembliesAsync()).Returns(model);

            //Act
            var result = assemblyController.AllAssemblies();

            //Assert
            result.Should().BeOfType<Task<IActionResult>>();
        }

        [Fact]
        public void WhereUsed_ReturnsModel()
        {
            //Arrange
            var partId = 2;
            var model = A.Fake<IEnumerable<AssemblyViewModel>>();
            A.CallTo(() => db.GetWhereUsedAssembliesAsync(partId)).Returns(model);

            //Act
            var result = assemblyController.WhereUsed(partId);

            //Assert
            result.Should().BeOfType<Task<IActionResult>>();
        }

        [Fact]
        public void WhereUsedPurchasedPart_ReturnsModel()
        {
            //Arrange
            var partId = 2;
            var model = A.Fake<IEnumerable<AssemblyViewModel>>();
            A.CallTo(() => db.GetWhereUsedPurchasedPartAssembliesAsync(partId)).Returns(model);

            //Act
            var result = assemblyController.WhereUsedPurchasedPart(partId);

            //Assert
            result.Should().BeOfType<Task<IActionResult>>();
        }

        [Fact]
        public void WhereUsedManufacturer_ReturnsModel()
        {
            //Arrange
            var manufacturerId = 2;
            var model = A.Fake<IEnumerable<AssemblyViewModel>>();
            A.CallTo(() => db.GetWhereUsedManufacturerAssembliesAsync(manufacturerId)).Returns(model);

            //Act
            var result = assemblyController.WhereUsedManufacturer(manufacturerId);

            //Assert
            result.Should().BeOfType<Task<IActionResult>>();
        }

        [Fact]
        public void WhereUsedSupplier_ReturnsModel()
        {
            //Arrange
            var supplierId = 2;
            var model = A.Fake<IEnumerable<AssemblyViewModel>>();
            A.CallTo(() => db.GetWhereUsedSupplierAssembliesAsync(supplierId)).Returns(model);

            //Act
            var result = assemblyController.WhereUsedSupplier(supplierId);

            //Assert
            result.Should().BeOfType<Task<IActionResult>>();
        }

        [Fact]
        public void WhereUsedMaterial_ReturnsModel()
        {
            //Arrange
            var materialId = 2;
            var model = A.Fake<IEnumerable<AssemblyViewModel>>();
            A.CallTo(() => db.GetWhereUsedMaterialAssembliesAsync(materialId)).Returns(model);

            //Act
            var result = assemblyController.WhereUsedMaterial(materialId);

            //Assert
            result.Should().BeOfType<Task<IActionResult>>();
        }

        [Fact]
        public void WhereUsedTypeOfProductionPart_ReturnsModel()
        {
            //Arrange
            var typeOfProductionPartId = 2;
            var model = A.Fake<IEnumerable<AssemblyViewModel>>();
            A.CallTo(() => db.GetWhereUsedTypeOfProductionPartAssembliesAsync(typeOfProductionPartId)).Returns(model);

            //Act
            var result = assemblyController.WhereUsedTypeOfProductionPart(typeOfProductionPartId);

            //Assert
            result.Should().BeOfType<Task<IActionResult>>();
        }

        [Fact]
        public void CreateNewAssembly_ReturnsModel()
        {
            //Arrange

            //Act
            var result = assemblyController.CreateNewAssembly();

            //Assert
            result.Should().BeOfType<ViewResult>();
        }

        [Fact]
        public void CreateNewAssembly_ReturnsSuccess()
        {
            //Arrange
            var model = A.Fake<CreateAssemblyViewModel>();

            //Act
            var result = assemblyController.CreateNewAssembly(model);

            //Assert
            result.Should().BeOfType<Task<IActionResult>>();
        }

        [Fact]
        public void AssemblyProductionPartList_ReturnsTask()
        {
            //Arrange
            var id = 2;

            //Act
            var result = assemblyController.AssemblyProductionPartList(id);

            //Assert
            result.Should().BeOfType<Task<IActionResult>>();
        }

        [Fact]
        public void WorkingAssemblyProductionPartList_ReturnsTask()
        {
            //Arrange
            var id = 2;

            //Act
            var result = assemblyController.WorkingAssemblyProductionPartList(id);

            //Assert
            result.Should().BeOfType<Task<IActionResult>>();
        }

        [Fact]
        public void AssemblyPurchasedPartList_ReturnsTask()
        {
            //Arrange
            var id = 2;

            //Act
            var result = assemblyController.AssemblyPurchasedPartList(id);

            //Assert
            result.Should().BeOfType<Task<IActionResult>>();
        }

        [Fact]
        public void WorkingAssemblyPurchasedPartList_ReturnsTask()
        {
            //Arrange
            var id = 2;

            //Act
            var result = assemblyController.WorkingAssemblyPurchasedPartList(id);

            //Assert
            result.Should().BeOfType<Task<IActionResult>>();
        }

        [Fact]
        public void AddAssemblyToMineCollection_ReturnsTask()
        {
            //Arrange
            var id = 2;

            //Act
            var result = assemblyController.AddAssemblyToMineCollection(id);

            //Assert
            result.Should().BeOfType<Task<IActionResult>>();
        }

        [Fact]
        public void SetAssemblyAsWorking_ReturnsTask()
        {
            //Arrange
            var id = 2;

            //Act
            var result = assemblyController.SetAssemblyAsWorking(id);

            //Assert
            result.Should().BeOfType<Task<IActionResult>>();
        }

        [Fact]
        public void WorkingAssembly_ReturnsTask()
        {
            //Arrange

            //Act
            var result = assemblyController.WorkingAssembly();

            //Assert
            result.Should().BeOfType<Task<IActionResult>>();
        }

        [Fact]
        public void RemoveAssemblyFromMineCollection_ReturnsTask()
        {
            //Arrange
            var id = 2;

            //Act
            var result = assemblyController.RemoveAssemblyFromMineCollection(id);

            //Assert
            result.Should().BeOfType<Task<IActionResult>>();
        }

        [Fact]
        public void MineAssemblies_ReturnsTask()
        {
            //Arrange

            //Act
            var result = assemblyController.MineAssemblies();

            //Assert
            result.Should().BeOfType<Task<IActionResult>>();
        }

        [Fact]
        public void EditAssembly_ReturnsModel()
        {
            //Arrenge
            var id = 7;
            var model = A.Fake<EditAssemblyViewModel>();
            A.CallTo(() => db.GetAssemblyForEditAsync(id)).Returns(model);

            //Act
            var result = assemblyController.EditAssembly(id);

            //Assert
            result.Should().BeOfType<Task<IActionResult>>();
        }

        [Fact]
        public void EditAssembly_ReturnsSuccess()
        {
            //Arrenge
            var model = A.Fake<EditAssemblyViewModel>();

            //Act
            var result = assemblyController.EditAssembly(model);

            //Asert
            result.Should().BeOfType<Task<IActionResult>>();
        }

        [Fact]
        public void Details_ReturnsTask()
        {
            //Arrenge
            var id = 7;
            var model = A.Fake<EditAssemblyViewModel>();
            A.CallTo(() => db.GetAssemblyForEditAsync(id)).Returns(model);

            //Act
            var result = assemblyController.Details(id);

            //Assert
            result.Should().BeOfType<Task<IActionResult>>();
        }

        [Fact]
        public void Delete_ReturnsTask()
        {
            //Arrenge
            var id = 7;
            var model = A.Fake<EditAssemblyViewModel>();
            A.CallTo(() => db.GetAssemblyForEditAsync(id)).Returns(model);

            //Act
            var result = assemblyController.Delete(id);

            //Assert
            result.Should().BeOfType<Task<IActionResult>>();
        }














    }
}
