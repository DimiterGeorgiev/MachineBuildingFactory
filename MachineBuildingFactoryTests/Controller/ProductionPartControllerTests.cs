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
    public class ProductionPartControllerTests
    {
        private ProductionPartController productionPartController;
        private IProductionPartService db;
        private IAssemblyService dbAssembly;

        public ProductionPartControllerTests()
        {
            //Depen
            db = A.Fake<IProductionPartService>();
            dbAssembly = A.Fake<IAssemblyService>();
            //SUT
            productionPartController = new ProductionPartController(db, dbAssembly);
        }

        [Fact]
        public void AllProductionPart_ReturnsSuccess()
        {
            //Arrange
            var model = A.Fake<IEnumerable<ProductionPartViewModel>>();
            A.CallTo(() => db.GetAllProductionPartsAsync()).Returns(model);
            //Act
            var result = productionPartController.AllProductionPart();
            //Assert
            result.Should().BeOfType<Task<IActionResult>>();
        }

        [Fact]
        public void Details_ReturnsSuccess()
        {
            //Arange
            var id = 1;
            var model = A.Fake<EditProductionPartViewModel>();
            A.CallTo(() => db.GetProductionPartForEditAsync(id)).Returns(model);
            //Act
            var result = productionPartController.Details(id);
            //Assert
            result.Should().BeOfType<Task<IActionResult>>();
        }

        [Fact]
        public void CreateNewProductionPart_ReturnsModelSuccess()
        {
            //Arrange

            //Act
            var result = productionPartController.CreateNewProductionPart();

            //Assert
            result.Should().BeOfType<Task<IActionResult>>();
        }

        [Fact]
        public void CreteNewProductionPart_ReturnsSuccess()
        {
            //Arrange
            var model = new CreateProductionPartViewModel();
            //A.CallTo(() => db.CreateProductionPartAsync(model)).Returns(task);

            //Act
            var result = productionPartController.CreateNewProductionPart(model);

            //Assert
            result.Should().BeOfType<Task<IActionResult>>();
        }

        //[Fact]
        //public void AddProductionPartToAssembly_ModelSuccess()
        //{
        //    //Arrange
        //    var quantity = 1;
        //    var id = 1;
        //    //Act
        //    var result = productionPartController.AddProductionPartToAssembly(id, quantity);

        //    //Assert
        //    result.Should().BeOfType<Task<IActionResult>>();
        //}

        [Fact]
        public void AddProductionPartToAssembly_GetModel()
        {
            //Arrenge
            var id = 1;
            var quantity = 3;

            //Act
            var result = productionPartController.AddProductionPartToAssembly(id, quantity);

            //Assert
            result.Should().BeOfType<Task<IActionResult>>();
        }

        [Fact]
        public void AddProductionPartToAssembly_PostSuccess()
        {
            //Arrange
            var id = 1;
            var model = A.Fake<AddProducitonPartToAssemblyViewModel>();

            //Act
            var result = productionPartController.AddProductionPartToAssembly(id, model);

            //Assert
            result.Should().BeOfType<Task<IActionResult>>();
        }

        [Fact]
        public void Delete_DeleteSuccess()
        {
            //Arrange
            var id = 1;

            //Act
            var result = productionPartController.Delete(id);

            //Assert
            result.Should().BeOfType<Task<IActionResult>>();
        }

        [Fact]
        public void RemoveProductionPartFromAssembly_RemoveSuccess()
        {
            //Arrange
            var id = 1;

            //Act
            var result = productionPartController.RemoveProductionPartFromAssembly(id);

            //Assert
            result.Should().BeOfType<Task<IActionResult>>();
        }

        [Fact]
        public void EditQuantity_GetSuccess()
        {
            //Arrange
            var id = 1;
            var idAssembly = 2;
            var model = A.Fake<AddProducitonPartToAssemblyViewModel>();
            A.CallTo(() => db.GetForEditQuantityAsync(id, idAssembly)).Returns(model);

            //Act
            var result = productionPartController.EditQuantity(id);

            //Assert
            result.Should().BeOfType<Task<IActionResult>>();
        }

        [Fact]
        public void EditQuantity_PostSuccess()
        {
            //Arrange
            var model = A.Fake<AddProducitonPartToAssemblyViewModel>();

            //Act
            var result = productionPartController.EditQuantity(model);

            //Assert
            result.Should().BeOfType<Task<IActionResult>>();
        }

        [Fact]
        public void EditProductionPart_GetSuccess()
        {
            //Arrange
            var id = 1;
            var model = A.Fake<EditProductionPartViewModel>();
            A.CallTo(() => db.GetProductionPartForEditAsync(id)).Returns(model);

            //Act
            var result = productionPartController.EditProductionPart(id);

            //Assert
            result.Should().BeOfType<Task<IActionResult>>();
        }

        [Fact]
        public void EditProductionPart_PostSuccess()
        {
            //Arrange
            var model = A.Fake<EditProductionPartViewModel>();

            //Act
            var result = productionPartController.EditProductionPart(model);

            //Assert
            result.Should().BeOfType<Task<IActionResult>>();
        }
    }
}
