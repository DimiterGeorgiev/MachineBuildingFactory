using FakeItEasy;
using FluentAssertions;
using MachineBuildingFactory.Areas.Management.Contracts;
using MachineBuildingFactory.Areas.Management.Controllers;
using MachineBuildingFactory.Areas.Management.Models;
using MachineBuildingFactory.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace MachineBuildingFactoryTests.Controller
{
    public class ManufacturerControllerTests
    {
        private readonly ManufacturerController manufacturerController;
        private readonly IManufacturerServices db;
        private readonly IAssemblyService dbAssembly;

        public ManufacturerControllerTests()
        {
            //Depen
            db = A.Fake<IManufacturerServices>();
            dbAssembly = A.Fake<IAssemblyService>();
            manufacturerController = new ManufacturerController(db, dbAssembly);
        }

        [Fact]
        public async void ManufacturerController_AllManufacturer_ReturnsViewResult()
        {
            //Arrange
            var model = A.Fake<IEnumerable<ManufacturerViewModel>>();
            A.CallTo(() => db.GetAllManufacturersAsync()).Returns(model);

            //Act
            var result = await manufacturerController.AllManufacturer();

            //Assert
            result.Should().BeOfType<ViewResult>();
        }

        [Fact]
        public void ManufacturerController_CreateNewManufacturer_ReturnsView()
        {
            //Arrange

            //Act
            var result = manufacturerController.CreateNewManufacturer();

            //Assert
            result.Should().BeOfType<ViewResult>();
        }

        [Fact]
        public void ManufacturerController_CreateNewManufacturer_ReturnsModel()
        {
            //Arrange
            var model = A.Fake<CreateManufacturerViewModel>();
            //Act
            var result = manufacturerController.CreateNewManufacturer(model);

            //Assert
            result.Should().BeOfType<Task<IActionResult>>();
        }

        [Fact]
        public void ManufacturerController_EditManufacturer_ReturnsGetSuccess()
        {
            //Arrange
            var id = 1;
            var model = A.Fake<EditManufacturerViewModel>();
            A.CallTo(() => db.GetManufacturerForEditAsync(id)).Returns(model);

            //Act
            var result = manufacturerController.EditManufacturer(id);

            //Assert
            result.Should().BeOfType<Task<IActionResult>>();
        }

        [Fact]
        public void ManufacturerController_EditManufacturer_ReturnsPostSuccess()
        {
            //Arrange
            var model = A.Fake<EditManufacturerViewModel>();

            //Act
            var result = manufacturerController.EditManufacturer(model);

            //Assert
            result.Should().BeOfType<Task<IActionResult>>();
        }

        [Fact]
        public async void ManufacturerController_Details_ReturnsViewModel()
        {
            //Arrange
            var id = 1;
            var model = A.Fake<EditManufacturerViewModel>();
            A.CallTo(() => db.GetManufacturerForEditAsync(id)).Returns(model);

            //Act
            var result = await manufacturerController.Details(id);

            //Assert
            result.Should().BeOfType<ViewResult>();
        }


        [Fact]
        public void ManufacturerController_Delete_ReturnsSuccess()
        {
            //Arrange
            var id = 1;

            //Act
            var result = manufacturerController.Delete(id);

            //Assert
            result.Should().BeOfType<Task<IActionResult>>();
        }






    }
}
