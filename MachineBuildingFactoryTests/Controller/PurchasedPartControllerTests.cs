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
    public class PurchasedPartControllerTests
    {
        private PurchasedPartController purchasedPartController;
        private IPurchasedPartService db;
        private IAssemblyService dbAssembly;

        public PurchasedPartControllerTests()
        {
            //Depen
            db = A.Fake<IPurchasedPartService>();
            dbAssembly = A.Fake<IAssemblyService>();
            //SUT
            purchasedPartController = new PurchasedPartController(db, dbAssembly);
        }

        [Fact]
        public void AllPurchasedPart_ReturnsSucceess()
        {
            //Arrange
            var model = A.Fake<IEnumerable<PurchasedPartViewModel>>();
            A.CallTo(() => db.GetAllPurchasedPartsAsync()).Returns(model);

            //Act
            var result = purchasedPartController.AllPurchasedPart();

            //Assert
            result.Should().BeOfType<Task<IActionResult>>();
        }

        [Fact]
        public void Details_ReturnsSuccess()
        {
            //Arrange
            var id = 1;
            var model = A.Fake<EditPurchasedPartViewModel>();
            A.CallTo(() => db.GetPurchasedPartForEditAsync(id)).Returns(model);

            //Act
            var result = purchasedPartController.Details(id);

            //Assert
            result.Should().BeOfType<Task<IActionResult>>();
        }

        [Fact]
        public void CreatNewPurchasedPart_ReturnsModelSuccess()
        {
            //Arrange

            //Act
            var result = purchasedPartController.CreateNewPurchasedPart();

            //Assert
            result.Should().BeOfType<Task<IActionResult>>();
        }

        [Fact]
        public void CreateNewPurchasedPart_ReturnsSuccess()
        {
            //Arrange
            var model = new CreatePurchasedPartViewModel();

            //Act
            var result = purchasedPartController.CreateNewPurchasedPart(model);

            //Assert
            result.Should().BeOfType<Task<IActionResult>>();
        }

        [Fact]
        public void AddPurchasedPartToAssembly_GetModel()
        {
            //Arrange
            var quantity = 1;
            var id = 1;

            //Act
            var result = purchasedPartController.AddPurchasedPartToAssembly(id, quantity);

            //Assert
            result.Should().BeOfType<Task<IActionResult>>();
        }

        [Fact]
        public void AddPurchasedPartToAssembly_PostSuccess()
        {
            //Arrange
            var id = 1;
            var model = A.Fake<AddPurchasedPartToAssemblyViewModel>();

            //Act
            var result = purchasedPartController.AddPurchasedPartToAssembly(id, model);

            //Assert
            result.Should().BeOfType<Task<IActionResult>>();
        }

        [Fact]
        public void Delete_DeleteSuccess()
        {
            //Arrange
            var id = 1;

            //Act
            var result = purchasedPartController.Delete(id);

            //Assert
            result.Should().BeOfType<Task<IActionResult>>();
        }

        [Fact]
        public void RemovePurchasedPartFromAssembly_RemoveSuccess()
        {
            //Arrange
            var id = 1;

            //Act
            var result = purchasedPartController.RemovePurchasedPartFromAssembly(id);

            //Assert
            result.Should().BeOfType<Task<IActionResult>>();
        }

        [Fact]
        public void EditQuantity_GetSuccess()
        {
            //Arrange
            var id = 1;
            var idAssembly = 2;
            var model = A.Fake<AddPurchasedPartToAssemblyViewModel>();
            A.CallTo(() => db.GetForEditQuantityAsync(id, idAssembly)).Returns(model);

            //Act
            var result = purchasedPartController.EditQuantity(id);

            //Assert
            result.Should().BeOfType<Task<IActionResult>>();
        }

        [Fact]
        public void EditQuantity_PostSuccess()
        {
            //Arrange
            var model = A.Fake<AddPurchasedPartToAssemblyViewModel>();

            //Act
            var result = purchasedPartController.EditQuantity(model);

            //Assert
            result.Should().BeOfType<Task<IActionResult>>();
        }

        [Fact]
        public void EditPurchasedPart_GetSuccess()
        {
            //Arrange
            var id = 1;
            var model = A.Fake<EditPurchasedPartViewModel>();
            A.CallTo(() => db.GetPurchasedPartForEditAsync(id)).Returns(model);

            //Act
            var result = purchasedPartController.EditPurchasedPart(id);

            //Assert
            result.Should().BeOfType<Task<IActionResult>>();
        }

        [Fact]
        public void EditPurchasedPart_PostSuccess()
        {
            //Arrange
            var model = A.Fake<EditPurchasedPartViewModel>();

            //Act
            var result = purchasedPartController.EditPurchasedPart(model);

            //Assert
            result.Should().BeOfType<Task<IActionResult>>();
        }
    }
}
