using MachineBuildingFactory.Contracts;
using MachineBuildingFactory.Models;
using Microsoft.AspNetCore.Mvc;

namespace MachineBuildingFactory.Controllers
{
    public class AssemblyController : Controller
    {
        private readonly IAssemblyService db;

        public AssemblyController(IAssemblyService _db)
        {
            db = _db;
        }

        [HttpGet]
        public async Task<IActionResult> AllAssemblies()
        {
            var model = await db.GetAllAssembliesAsync();

            return View(model);
        }

        [HttpGet]
        public IActionResult CreateNewAssembly()
        {
            var model = new CreateAssemblyViewModel();
            return View(model);
        }

        public async Task<IActionResult> CreateNewAssembly(CreateAssemblyViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            try
            {
                await db.CreateAssemblyAsync(model);
                return RedirectToAction(nameof(AllAssemblies)); // След добавяне на нов Assembly отиваме в AllAssemblies
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Something went wrong");
                return View(model);
            }
        }

        public async Task<IActionResult> AssemblyProductionPartList(int assemblyId)
        {
            var model = await db.GetProductionPartListFromAssemblyAsync(assemblyId);

            return View(nameof(AssemblyProductionPartList), model);
        }
    }
}
