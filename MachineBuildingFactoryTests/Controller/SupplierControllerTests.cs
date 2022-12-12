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
    public class SupplierControllerTests
    {
        private readonly SupplierController supplierController;
        private readonly ISupplierServices db;
        private readonly IAssemblyService dbAssembly;

        public SupplierControllerTests()
        {
            //Depen
            db = A.Fake<ISupplierServices>();
            dbAssembly = A.Fake<IAssemblyService>();
            supplierController = new SupplierController(db, dbAssembly);
        }

        [Fact]
        public async void SupplierController_AllSupplier_ReturnsViewResult()
        {
            //Arrange
            var model = A.Fake<IEnumerable<SupplierViewModel>>();
            A.CallTo(() => db.GetAllSuppliersAsync()).Returns(model);

            //Act
            var result = await supplierController.AllSupplier();

            //Assert
            result.Should().BeOfType<ViewResult>();
        }

        [Fact]
        public void SupplierController_CreateNewSupplier_ReturnsViewResult()
        {
            //Arrange

            //Act
            var result = supplierController.CreateNewSupplier();

            //Assert
            result.Should().BeOfType<ViewResult>();
        }

        [Fact]
        public void SupplierController_CreateNewSupplier_ReturnsModel()
        {
            //Arrange
            var model = A.Fake<CreateSupplierViewModel>();

            //Act
            var result = supplierController.CreateNewSupplier(model);

            //Assert
            result.Should().BeOfType<Task<IActionResult>>();
        }

        [Fact]
        public void SupplierController_EditSupplier_ReturnsGetSuccess()
        {
            //Arrang
            var id = 13;
            var model = A.Fake<EditSupplierViewModel>();
            A.CallTo(() => db.GetSupplierForEditAsync(id)).Returns(model);

            //Act
            var result = supplierController.EditSupplier(id);

            //Assert
            result.Should().BeOfType<Task<IActionResult>>();
        }

        [Fact]
        public void SupplierController_EditSupplier_ReturnsPostSuccess()
        {
            //Arrang
            var model = A.Fake<EditSupplierViewModel>();

            //Act
            var result = supplierController.EditSupplier(model);

            //Assert
            result.Should().BeOfType<Task<IActionResult>>();
        }

        [Fact]
        public async void SupplierController_Details_ReturnsViewModel()
        {
            //Arrange
            var id = 1;
            var model = A.Fake<EditSupplierViewModel>();
            A.CallTo(() => db.GetSupplierForEditAsync(id)).Returns(model);

            //Act
            var result = await supplierController.Details(id);

            //Assert
            result.Should().BeOfType<ViewResult>();
        }

        [Fact]
        public void SupplierController_Delete_ReturnsSuccess()
        {
            //Arrange
            var id = 1;

            //Act
            var result = supplierController.Delete(id);

            //Assert
            result.Should().BeOfType<Task<IActionResult>>();
        }
    }
}
