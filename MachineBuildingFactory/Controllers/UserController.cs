using MachineBuildingFactory.Data.Enums;
using MachineBuildingFactory.Data.Models;
using MachineBuildingFactory.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MachineBuildingFactory.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;

        private readonly SignInManager<ApplicationUser> signInManager;

        public UserController(
            UserManager<ApplicationUser> _userManager,
            SignInManager<ApplicationUser> _signInManager)
        {
            userManager = _userManager;
            signInManager = _signInManager;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            //нерегистрираните потребители не виждат книгите
            if (User?.Identity?.IsAuthenticated ?? false)
            {
                return RedirectToAction("All", "Parts");
            }
            var model = new RegisterViewModel();

            return View(model);
        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = new ApplicationUser()
            {
                Email = model.Email,
                UserName = model.UserName,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Title = (Title)Enum.Parse(typeof(Title), model.Title),
                Phone = model.Phone,
                Department = (Department)Enum.Parse(typeof(Department), model.Department),
                Signature = model.Signature
            };

            var result = await userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                //await signInManager.SignInAsync(user, isPersistent: false);
                // след регистрация не се логва потребителя
                //след регистрация птребителя отива на логин

                return RedirectToAction("Login", "User");
            }

            foreach (var item in result.Errors)
            {
                ModelState.AddModelError("", item.Description);
            }

            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            //не регистрираните потребители не виждат книгите
            if (User?.Identity?.IsAuthenticated ?? false)
            {
                return RedirectToAction("AllProductionPart", "ProductionPart");
            }

            var model = new LoginViewModel();

            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await userManager.FindByNameAsync(model.UserName);

            if (user != null)
            {
                var result = await signInManager.PasswordSignInAsync(user, model.Password, false, false);

                if (result.Succeeded)
                {
                    //TO DO да разменя местата след като създам "All", "Parts"
                    //return RedirectToAction("All", "Parts");
                    return RedirectToAction("Index", "Home"); // само за началото
                }
            }

            ModelState.AddModelError("", "Invalid login");

            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }



    }
}
