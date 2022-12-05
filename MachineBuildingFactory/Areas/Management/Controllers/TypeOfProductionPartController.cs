using MachineBuildingFactory.Areas.Management.Contracts;
using MachineBuildingFactory.Areas.Management.Models;
using MachineBuildingFactory.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MachineBuildingFactory.Areas.Management.Controllers
{
    [Area("Management")]
    [Authorize(Roles = "Management")]
    public class TypeOfProductionPartController : Controller
    {
        private readonly ITypeOfProductionPartServices db;

        private readonly IAssemblyService dbAssembly;

        public TypeOfProductionPartController(ITypeOfProductionPartServices _db, IAssemblyService _dbAssembly)
        {
            db = _db;
            dbAssembly = _dbAssembly;
        }

        public async Task<IActionResult> AllTypeOfProductionPart()
        {
            var model = await db.GetAllTypeOfProductionPartsAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> CreateNewTypeOfProductionPart()
        {
            var model = new CreateTypeOfProductionPartViewModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewTypeOfProductionPart(CreateTypeOfProductionPartViewModel model)
        {
            var listOfAllTypePoProductionParts = await db.GetAllTypeOfProductionPartsAsync();

            if (listOfAllTypePoProductionParts.Any(m => m.Name == model.Name))
            {
                TempData["error"] = $"Type of Production Part '{model.Name}' already exist.";
                ModelState.AddModelError("Name", "The Type of Production Part already exist");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await db.CreateTypeOfProductionPartAsync(model);
                TempData["success"] = $"You have created '{model.Name}' successfuly";
                return RedirectToAction(nameof(AllTypeOfProductionPart)); // След създаване на нов Material отиваме в AllMateriala
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Something went wrong");
                TempData["error"] = "Something went wrong";
                return View(model);
            }
        }


        [HttpGet]
        public async Task<IActionResult> EditTypeOfProductionPart(int id)
        {
            var model = await db.GetTypeOfProductionPartForEditAsync(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditTypeOfProductionPart(EditTypeOfProductionPartViewModel model)
        {
            var listOfAllTypeOfProductionParts = (await db.GetAllTypeOfProductionPartsAsync()).ToList();

            var currentTypeOfProductionPart = listOfAllTypeOfProductionParts.Find(p => p.Id == model.Id); // при Edit изключваме името на текущият

            if (currentTypeOfProductionPart != null)
            {
                listOfAllTypeOfProductionParts.Remove(currentTypeOfProductionPart);
            }

            if (listOfAllTypeOfProductionParts.Any(t => t.Name == model.Name))
            {
                TempData["error"] = $"Type of Production Part '{model.Name} already exist'";
                ModelState.AddModelError("Name", "Name already exist");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await db.EditTypeOfProductionPartAsync(model);
            TempData["success"] = $"Type of Production Part '{model.Name}' is edited successfully";
            return RedirectToAction(nameof(AllTypeOfProductionPart));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var model = await db.GetTypeOfProductionPartForEditAsync(id);

            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(AllTypeOfProductionPart));
            }

            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var model = await db.GetTypeOfProductionPartForEditAsync(id);
            if (model == null)
            {
                TempData["error"] = $"Type of Production Part with id='{id}' can not found";
                return NotFound();
            }

            var name = model.Name;

            var assemblyModel = await dbAssembly.GetWhereUsedTypeOfProductionPartAssembliesAsync(id);

            if (assemblyModel.Any())
            {
                TempData["error"] = $"Type of Prouction Part :'{name}' can not be Deleted because it is currently used in somes Assemblies";
                return RedirectToAction(nameof(AllTypeOfProductionPart));
            }
            else
            {
                await db.DeleteAsync(id);
                TempData["success"] = $"You have deleted Type of Production Part:'{name}' successfully";
                return RedirectToAction(nameof(AllTypeOfProductionPart));
            }
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}
