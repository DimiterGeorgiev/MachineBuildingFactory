using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MachineBuildingFactory.Areas.Management.Controllers
{
    [Area("Management")]
    [Authorize(Roles = "Management")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("AllManufacturer", "Manufacturer");
        }
    }
}
