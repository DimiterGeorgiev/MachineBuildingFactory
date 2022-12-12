using MachineBuildingFactory.Data.Enums;
using MachineBuildingFactory.Data.Models;
using MachineBuildingFactory.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace MachineBuildingFactory.Controllers
{
    [Authorize]
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
            //нерегистрираните потребители не виждат нищо от самият сайт
            if (User?.Identity?.IsAuthenticated ?? false)
            {
                return RedirectToAction(nameof(ProductionPartController.AllProductionPart), nameof(ProductionPart)); //"AllProductionPart", "ProductionPart"
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
                if (user.Department == Department.Management)
                {
                    await userManager.AddToRoleAsync(user, "management");
                }
                else
                {
                    await userManager.AddToRoleAsync(user, "user");
                }
                return RedirectToAction(nameof(Login), nameof(User)); //"Login", "User"
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
            //нерегистрираните потребители не виждат нищо от самият сайт
            if (User?.Identity?.IsAuthenticated ?? false)
            {
                return RedirectToAction(nameof(ProductionPartController.AllProductionPart), nameof(ProductionPart)); //"AllProductionPart", "ProductionPart"
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
                    return RedirectToAction(nameof(ProductionPartController.AllProductionPart), nameof(ProductionPart)); //"AllProductionPart", "ProductionPart"
                }
            }

            ModelState.AddModelError("", "Invalid login");

            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home"); //"Index", "Home"
        }

    }
}
