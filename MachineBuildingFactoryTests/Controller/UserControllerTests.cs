using FakeItEasy;
using FluentAssertions;
using MachineBuildingFactory.Controllers;
using MachineBuildingFactory.Data.Models;
using MachineBuildingFactory.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Xunit;

namespace MachineBuildingFactoryTests.Controller
{
    public class UserControllerTests
    {
        private readonly UserController userControler;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public UserControllerTests()
        {
            userManager = A.Fake<UserManager<ApplicationUser>>();
            signInManager = A.Fake<SignInManager<ApplicationUser>>();

            userControler = new UserController(userManager, signInManager);
        }

        [Fact]
        public void UserControler_Register_ReturnsIActionResult()
        {
            //Arrange

            //Act
            var result = userControler.Register();

            //Assert
            result.Should().BeOfType<ViewResult>();
        }

        [Fact]
        public void UserControler_Register_ReturnsIActionTask()
        {
            //Arrange
            var model = A.Fake<RegisterViewModel>();
            //Act
            var result = userControler.Register(model);

            //Assert
            result.Should().BeOfType<Task<IActionResult>>();
        }

        [Fact]
        public void UserControler_Login_ReturnsViewModel()
        {
            //Arrange

            //Act
            var result = userControler.Login();

            //Assert
            result.Should().BeOfType<ViewResult>();
        }

        [Fact]
        public async void UserControler_Login_ReturnsIActionTask()
        {
            //Arrange
            var model = A.Fake<LoginViewModel>();

            //Act
            var result = await userControler.Login(model);

            //Assert
            result.Should().BeOfType<ViewResult>();
        }

        [Fact]
        public async void UserControler_Logout_ReturnsSuccess()
        {
            //Arrange

            //Act
            var result = await userControler.Logout();

            //Assert
            result.Should().BeOfType<RedirectToActionResult>();
        }



    }
}
