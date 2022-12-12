using FluentAssertions;
using MachineBuildingFactory.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace MachineBuildingFactoryTests.Controller
{
    public class HomeControllerTests
    {
        private readonly HomeController homeControler = new HomeController();

        [Fact]
        public void HomeControler_Index_ReturnsIActionResult()
        {
            //Arrange

            //Act
            var result = homeControler.Index();

            //Assert
            result.Should().BeOfType<ViewResult>();
        }
    }
}
