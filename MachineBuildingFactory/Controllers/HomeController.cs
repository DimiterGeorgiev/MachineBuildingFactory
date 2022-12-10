using MachineBuildingFactory.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace MachineBuildingFactory.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //ако потребителя е регистриран ще виждаме директно всичк ProductionParts иначе HomePage
            if (User?.Identity?.IsAuthenticated ?? false)
            {
                return RedirectToAction(nameof(ProductionPartController.AllProductionPart), nameof(ProductionPart));
            }
            return View();
        }
    }
}