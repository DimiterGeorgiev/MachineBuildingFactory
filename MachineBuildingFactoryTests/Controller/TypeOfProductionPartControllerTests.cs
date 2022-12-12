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
    public class TypeOfProductionPartControllerTests
    {
        private readonly TypeOfProductionPartController typeOfProductionPartController;
        private readonly ITypeOfProductionPartServices db;
        private readonly IAssemblyService dbAssembly;

        public TypeOfProductionPartControllerTests()
        {
            //Depen
            db = A.Fake<ITypeOfProductionPartServices>();
            dbAssembly = A.Fake<IAssemblyService>();
            typeOfProductionPartController = new TypeOfProductionPartController(db, dbAssembly);
        }

        [Fact]
        public async void TypeOfProductionPartController_AllTypeOfProductionPart_ReturnsViewResult()
        {
            //Arrange
            var model = A.Fake<IEnumerable<TypeOfProductionPartViewModel>>();
            A.CallTo(() => db.GetAllTypeOfProductionPartsAsync()).Returns(model);

            //Act
            var result = await typeOfProductionPartController.AllTypeOfProductionPart();

            //Assert
            result.Should().BeOfType<ViewResult>();
        }

        [Fact]
        public void TypeOfProductionPart_CreateNewTypeOfProductionPart_ReturnsViewResult()
        {
            //Arrange

            //Act
            var result = typeOfProductionPartController.CreateNewTypeOfProductionPart();

            //Assert
            result.Should().BeOfType<ViewResult>();
        }

        [Fact]
        public void TypeOfProductionPart_CreateNewTypeOfProductionPart_ReturnsModel()
        {
            //Arrange
            var model = A.Fake<CreateTypeOfProductionPartViewModel>();

            //Act
            var result = typeOfProductionPartController.CreateNewTypeOfProductionPart(model);

            //Assert
            result.Should().BeOfType<Task<IActionResult>>();
        }

        [Fact]
        public void TypeOfProductionPartController_EditTypeOfProductionPart_ReturnsGetSuccess()
        {
            //Arrang
            var id = 5;
            var model = A.Fake<EditTypeOfProductionPartViewModel>();
            A.CallTo(() => db.GetTypeOfProductionPartForEditAsync(id)).Returns(model);

            //Act
            var result = typeOfProductionPartController.EditTypeOfProductionPart(id);

            //Assert
            result.Should().BeOfType<Task<IActionResult>>();
        }

        [Fact]
        public void TypeOfProductionPartController_EditTypeOfProductionPart_ReturnsPostSuccess()
        {
            //Arrang
            var model = A.Fake<EditTypeOfProductionPartViewModel>();

            //Act
            var result = typeOfProductionPartController.EditTypeOfProductionPart(model);

            //Assert
            result.Should().BeOfType<Task<IActionResult>>();
        }

        [Fact]
        public async void TypeOfProductionPartController_Details_ReturnsViewModel()
        {
            //Arrange
            var id = 1;
            var model = A.Fake<EditTypeOfProductionPartViewModel>();
            A.CallTo(() => db.GetTypeOfProductionPartForEditAsync(id)).Returns(model);

            //Act
            var result = await typeOfProductionPartController.Details(id);

            //Assert
            result.Should().BeOfType<ViewResult>();
        }

        [Fact]
        public void TypeOfProductionPartController_Delete_ReturnsSuccess()
        {
            //Arrange
            var id = 1;

            //Act
            var result = typeOfProductionPartController.Delete(id);

            //Assert
            result.Should().BeOfType<Task<IActionResult>>();
        }


    }
}
