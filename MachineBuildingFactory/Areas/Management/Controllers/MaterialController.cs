using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MachineBuildingFactory.Areas.Management.Controllers
{
    [Area("Management")]
    [Authorize(Roles = "Management")]
    public class MaterialController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
