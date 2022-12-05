using MachineBuildingFactory.Areas.Management.Contracts;
using MachineBuildingFactory.Areas.Management.Models;
using MachineBuildingFactory.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MachineBuildingFactory.Areas.Management.Controllers
{
    [Area("Management")]
    [Authorize(Roles = "Management")]
    public class ManufacturerController : Controller
    {
        private readonly IManufacturerServices db;

        private readonly IAssemblyService dbAssembly;

        public ManufacturerController(IManufacturerServices _db, IAssemblyService _dbAssembly)
        {
            db = _db;
            dbAssembly = _dbAssembly;
        }

        public async Task<IActionResult> AllManufacturer()
        {
            var model = await db.GetAllManufacturersAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> CreateNewManufacturer()
        {
            var model = new CreateManufacturerViewModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewManufacturer(CreateManufacturerViewModel model)
        {
            var listOfAllManufacturer = await db.GetAllManufacturersAsync();

            if (listOfAllManufacturer.Any(m => m.Name == model.Name))
            {
                TempData["error"] = $"Manufacturer with Name '{model.Name}' already exist.";
                ModelState.AddModelError("Name", "The Manufacturer already exist");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await db.CreateManufacturerAsync(model);
                TempData["success"] = $"You have created '{model.Name}' successfuly";
                return RedirectToAction(nameof(AllManufacturer)); // След създаване на нов Manufacturer отиваме в AllManufacturer
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Something went wrong");
                TempData["error"] = "Something went wrong";
                return View(model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> EditManufacturer(int id)
        {
            var model = await db.GetManufacturerForEditAsync(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditManufacturer(EditManufacturerViewModel model)
        {
            var listOfAllManufacturer = (await db.GetAllManufacturersAsync()).ToList();

            var currentManufacturer = listOfAllManufacturer.Find(p => p.Id == model.Id); // при Edit изключваме името на текущият

            if (currentManufacturer != null)
            {
                listOfAllManufacturer.Remove(currentManufacturer);
            }

            if (listOfAllManufacturer.Any(p => p.Name == model.Name))
            {
                TempData["error"] = $"Name '{model.Name} already exist'";
                ModelState.AddModelError("Name", "The Name already exist");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await db.EditManufacturerAsync(model);
            TempData["success"] = $"Manufacturer '{model.Name}' is edited successfully";
            return RedirectToAction(nameof(AllManufacturer));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var model = await db.GetManufacturerForEditAsync(id);

            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(AllManufacturer));
            }

            return View(model);
        }


        public async Task<IActionResult> Delete(int id)
        {
            var model = await db.GetManufacturerForEditAsync(id);
            if (model == null)
            {
                TempData["error"] = $"Manufacturer with id='{id}' can not found";
                return NotFound();
            }

            var manufacturerName = model.Name;

            var assemblyModel = await dbAssembly.GetWhereUsedManufacturerAssembliesAsync(id);

            if (assemblyModel.Any())
            {
                TempData["error"] = $"'{manufacturerName}' can not be Deleted because it is currently used in somes Assemblies";
                return RedirectToAction(nameof(AllManufacturer));
            }
            else
            {
                await db.DeleteAsync(id);
                TempData["success"] = $"You have deleted '{manufacturerName}' successfully";
                return RedirectToAction(nameof(AllManufacturer));
            }
        }





        public IActionResult Index()
        {
            return View();
        }

    }
}
