using Microsoft.AspNetCore.Mvc;

namespace MachineBuildingFactory.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public IActionResult Index()
        {
            //ако потребителя е регистри ще виждаме директно всичк ProductionParts иначе HomePage
            if (User?.Identity?.IsAuthenticated ?? false)
            {
                return RedirectToAction("AllProductionPart", "ProductionPart");
            }
            return View();
        }

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}