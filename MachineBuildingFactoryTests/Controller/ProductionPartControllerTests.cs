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


    }
}
