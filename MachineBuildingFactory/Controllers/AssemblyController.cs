using MachineBuildingFactory.Contracts;
using MachineBuildingFactory.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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


        //още не работи
        public async Task<IActionResult> AssemblyProductionPartList(int assemblyId)
        {
            var model = await db.GetProductionPartListFromAssemblyAsync(assemblyId);

            return View(nameof(AssemblyProductionPartList), model);
        }


        public async Task<IActionResult> AddAssemblyToMineCollection(int id)
        {
            try
            {
                var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                await db.AddAssemblyToCollectionAsync(id, userId);
            }
            catch (Exception)
            {
                throw;
            }

            return RedirectToAction(nameof(AllAssemblies));
        }

        public async Task<IActionResult> SetAssemblyAsWorking(int id)
        {
            try
            {
                var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                await db.SetAssemblyAsWorkingAsync(id, userId);
            }
            catch (Exception)
            {
                throw;
            }

            return RedirectToAction(nameof(MineAssemblies));
        }

        public async Task<IActionResult> WorkingAssembly()
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            var model = await db.GetWorkingAssemblyAsync(userId);

            return View(nameof(WorkingAssembly), model);

        }

        public async Task<IActionResult> RemoveAssemblyFromMineCollection(int id)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            await db.RemoveAssemblyFromCollectionAsync(id, userId);
            return RedirectToAction(nameof(MineAssemblies));
        }



        public async Task<IActionResult> MineAssemblies()
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            var model = await db.GetMineAssembliesAsync(userId);

            return View("MineAssemblies", model);
        }

        [HttpGet]
        public async Task<IActionResult> EditAssembly(int id)
        {
            var model = await db.GetAssemblyForEditAsync(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditAssembly(EditAssemblyViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await db.EditAssemblyAsync(model);
            return RedirectToAction(nameof(AllAssemblies));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var model = await db.GetAssemblyForEditAsync(id);

            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(AllAssemblies));
            }

            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var model = await db.GetAssemblyForEditAsync(id);

            if (model == null)
            {
                return NotFound();
            }

            await db.DeleteAsync(id);
            return RedirectToAction(nameof(AllAssemblies));
        }





    }
}
