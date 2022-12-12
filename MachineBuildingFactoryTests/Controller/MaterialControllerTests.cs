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
    public class MaterialControllerTests
    {
        private readonly MaterialController materialController;
        private readonly IMaterialService db;
        private readonly IAssemblyService dbAssembly;

        public MaterialControllerTests()
        {
            //Depen
            db = A.Fake<IMaterialService>();
            dbAssembly = A.Fake<IAssemblyService>();
            materialController = new MaterialController(db, dbAssembly);
        }

        [Fact]
        public async void MaterialController_AllMaterial_ReturnsViewResult()
        {
            //Arrange
            var model = A.Fake<IEnumerable<MaterialViewModel>>();
            A.CallTo(() => db.GetAllMaterialsAsync()).Returns(model);

            //Act
            var result = await materialController.AllMaterial();

            //Assert
            result.Should().BeOfType<ViewResult>();
        }

        [Fact]
        public void MaterilaController_CreateNewMaterial_ReturnsViewResult()
        {
            //Arrange

            //Act
            var result = materialController.CreateNewMaterial();

            //Assert
            result.Should().BeOfType<ViewResult>();
        }

        [Fact]
        public void MaterialController_CreateMaterial_ReturnsModel()
        {
            //Arrange
            var model = A.Fake<CreateMaterialViewModel>();

            //Act
            var result = materialController.CreateNewMaterial(model);

            //Assert
            result.Should().BeOfType<Task<IActionResult>>();
        }

        [Fact]
        public void MaterialController_EditMaterial_ReturnsGetSuccess()
        {
            //Arrang
            var id = 5;
            var model = A.Fake<EditMaterialViewModel>();
            A.CallTo(() => db.GetMaterialForEditAsync(id)).Returns(model);

            //Act
            var result = materialController.EditMaterial(id);

            //Assert
            result.Should().BeOfType<Task<IActionResult>>();
        }

        [Fact]
        public void MaterilaController_EditMaterial_ReturnsPostSuccess()
        {
            //Arrang
            var model = A.Fake<EditMaterialViewModel>();

            //Act
            var result = materialController.EditMaterial(model);

            //Assert
            result.Should().BeOfType<Task<IActionResult>>();
        }

        [Fact]
        public async void MaterialController_Details_ReturnsViewModel()
        {
            //Arrange
            var id = 1;
            var model = A.Fake<EditMaterialViewModel>();
            A.CallTo(() => db.GetMaterialForEditAsync(id)).Returns(model);

            //Act
            var result = await materialController.Details(id);

            //Assert
            result.Should().BeOfType<ViewResult>();
        }

        [Fact]
        public void MaterialController_Delete_ReturnsSuccess()
        {
            //Arrange
            var id = 1;

            //Act
            var result = materialController.Delete(id);

            //Assert
            result.Should().BeOfType<Task<IActionResult>>();
        }

    }
}
