using MachineBuildingFactory.Areas.Management.Contracts;
using MachineBuildingFactory.Areas.Management.Models;
using MachineBuildingFactory.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MachineBuildingFactory.Areas.Management.Controllers
{
    [Area("Management")]
    [Authorize(Roles = "Management")]
    public class MaterialController : Controller
    {
        private readonly IMaterialService db;

        private readonly IAssemblyService dbAssembly;

        public MaterialController(IMaterialService _db, IAssemblyService _dbAssembly)
        {
            db = _db;
            dbAssembly = _dbAssembly;
        }

        public async Task<IActionResult> AllMaterial()
        {
            var model = await db.GetAllMaterialsAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> CreateNewMaterial()
        {
            var model = new CreateMaterialViewModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewMaterial(CreateMaterialViewModel model)
        {
            var listOfAllMaterials = await db.GetAllMaterialsAsync();

            if (listOfAllMaterials.Any(m => m.MaterialNumber == model.MaterialNumber))
            {
                TempData["error"] = $"Material with Material Number '{model.MaterialNumber}' already exist.";
                ModelState.AddModelError("Material Number", "The Material Number already exist");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await db.CreateMaterialAsync(model);
                TempData["success"] = $"You have created '{model.MaterialNumber}' successfuly";
                return RedirectToAction(nameof(AllMaterial)); // След създаване на нов Material отиваме в AllMateriala
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Something went wrong");
                TempData["error"] = "Something went wrong";
                return View(model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> EditMaterial(int id)
        {
            var model = await db.GetMaterialForEditAsync(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditMaterial(EditMaterialViewModel model)
        {
            var listOfAllMaterilas = (await db.GetAllMaterialsAsync()).ToList();

            var currentMaterial = listOfAllMaterilas.Find(p => p.Id == model.Id); // при Edit изключваме името на текущият

            if (currentMaterial != null)
            {
                listOfAllMaterilas.Remove(currentMaterial);
            }

            if (listOfAllMaterilas.Any(p => p.MaterialNumber == model.MaterialNumber))
            {
                TempData["error"] = $"Material Number '{model.MaterialNumber} already exist'";
                ModelState.AddModelError("Material Number", "Material Number already exist");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await db.EditMaterialAsync(model);
            TempData["success"] = $"Material with Material Number '{model.MaterialNumber}' is edited successfully";
            return RedirectToAction(nameof(AllMaterial));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var model = await db.GetMaterialForEditAsync(id);

            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(AllMaterial));
            }

            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var model = await db.GetMaterialForEditAsync(id);
            if (model == null)
            {
                TempData["error"] = $"Material with id='{id}' can not found";
                return NotFound();
            }

            var materialNumber = model.MaterialNumber;

            var assemblyModel = await dbAssembly.GetWhereUsedMaterialAssembliesAsync(id);

            if (assemblyModel.Any())
            {
                TempData["error"] = $"Material with Material Number: '{materialNumber}' can not be Deleted because it is currently used in somes Assemblies";
                return RedirectToAction(nameof(AllMaterial));
            }
            else
            {
                await db.DeleteAsync(id);
                TempData["success"] = $"You have deleted Material with Material Number:'{materialNumber}' successfully";
                return RedirectToAction(nameof(AllMaterial));
            }
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
