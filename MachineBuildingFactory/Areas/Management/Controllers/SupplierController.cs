using MachineBuildingFactory.Areas.Management.Contracts;
using MachineBuildingFactory.Areas.Management.Models;
using MachineBuildingFactory.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MachineBuildingFactory.Areas.Management.Controllers
{
    [Area("Management")]
    [Authorize(Roles = "Management")]
    public class SupplierController : Controller
    {
        private readonly ISupplierServices db;

        private readonly IAssemblyService dbAssembly;

        public SupplierController(ISupplierServices _db, IAssemblyService _dbAssembly)
        {
            db = _db;
            dbAssembly = _dbAssembly;
        }

        [HttpGet]
        public async Task<IActionResult> AllSupplier()
        {
            var model = await db.GetAllSuppliersAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> CreateNewSupplier()
        {
            var model = new CreateSupplierViewModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewSupplier(CreateSupplierViewModel model)
        {
            var listOfAllSuppliers = await db.GetAllSuppliersAsync();

            if (listOfAllSuppliers.Any(m => m.Name == model.Name))
            {
                TempData["error"] = $"Supplier with Name '{model.Name}' already exist";
                ModelState.AddModelError("Name", "The Supplier already exist");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await db.CreateSupplierAsync(model);
                TempData["success"] = $"You have created '{model.Name}' successfuly";
                return RedirectToAction(nameof(AllSupplier)); // След създаване на нов Supplier отиваме в AllManufacturer
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Something went wrong");
                TempData["error"] = "Something went wrong";
                return View(model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> EditSupplier(int id)
        {
            var model = await db.GetSupplierForEditAsync(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditSupplier(EditSupplierViewModel model)
        {
            var listOfAllSupplier = (await db.GetAllSuppliersAsync()).ToList();

            var currentSupplier = listOfAllSupplier.Find(s => s.Id == model.Id);

            if (currentSupplier != null)
            {
                listOfAllSupplier.Remove(currentSupplier);
            }

            if (listOfAllSupplier.Any(p => p.Name == model.Name))
            {
                TempData["error"] = $"Name '{model.Name} already exist'";
                ModelState.AddModelError("Name", "The Name already exist");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await db.EditSupplierAsync(model);
            TempData["success"] = $"Supplier '{model.Name}' is edited successfully";
            return RedirectToAction(nameof(AllSupplier));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var model = await db.GetSupplierForEditAsync(id);

            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(AllSupplier));
            }

            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var model = await db.GetSupplierForEditAsync(id);
            if (model == null)
            {
                TempData["error"] = $"Supplier with id='{id}' can not found";
                return NotFound();
            }

            var supplierName = model.Name;

            var assemblyModel = await dbAssembly.GetWhereUsedSupplierAssembliesAsync(id);

            if (assemblyModel.Any())
            {
                TempData["error"] = $"'{supplierName}' can not be Deleted because it is currently used in somes Assemblies";
                return RedirectToAction(nameof(AllSupplier));
            }
            else
            {
                await db.DeleteAsync(id);
                TempData["success"] = $"You have deleted '{supplierName}' successfully";
                return RedirectToAction(nameof(AllSupplier));
            }
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
