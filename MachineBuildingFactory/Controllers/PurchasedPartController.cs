using MachineBuildingFactory.Contracts;
using MachineBuildingFactory.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MachineBuildingFactory.Controllers
{
    public class PurchasedPartController : Controller
    {
        private readonly IPurchasedPartService db;

        private readonly IAssemblyService dbAssembly;

        public PurchasedPartController(IPurchasedPartService _db, IAssemblyService _dbAssembly)
        {
            db = _db;
            dbAssembly = _dbAssembly;
        }

        [HttpGet]
        public async Task<IActionResult> AllPurchasedPart()
        {
            var model = await db.GetAllPurchasedPartsAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> CreateNewPurchasedPart()
        {
            var model = new CreatePurchasedPartViewModel
            {
                Manufacturers = await db.GetManufactursAsync(),
                Suppliers = await db.GetSuppliersAsync()
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewPurchasedPart(CreatePurchasedPartViewModel model)
        {
            var listOfAllPurchasedPart = (await db.GetAllPurchasedPartsAsync()).ToList();

            if (listOfAllPurchasedPart.Any(p => p.ItemNumber == model.ItemNumber))
            {
                TempData["error"] = $"Drawing Number '{model.ItemNumber}' already exist.";
                ModelState.AddModelError("ItemNumber", "The Item Number already exist.");
            }

            if (!ModelState.IsValid)
            {
                model.Suppliers = await db.GetSuppliersAsync();
                model.Manufacturers = await db.GetManufactursAsync();
                return View(model);
            }

            try
            {
                await db.CreatePurchasedPartAsync(model);
                TempData["success"] = $"Purchased Part '{model.Name}' is created successfully";
                return RedirectToAction(nameof(AllPurchasedPart));
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Something went wrong");
                TempData["errror"] = "Something went wrong";
                return View(model);
            }
        }


        [HttpGet]
        public async Task<IActionResult> EditPurchasedPart(int id)
        {
            var model = await db.GetPurchasedPartForEditAsync(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditPurchasedPart(EditPurchasedPartViewModel model)
        {
            var listOfAllPurchasedPart = (await db.GetAllPurchasedPartsAsync()).ToList();
            var currPurchasedPart = listOfAllPurchasedPart.Find(p => p.Id == model.Id);

            if (currPurchasedPart != null)
            {
                listOfAllPurchasedPart.Remove(currPurchasedPart);
            }

            if (listOfAllPurchasedPart.Any(p => p.ItemNumber == model.ItemNumber))
            {
                TempData["error"] = $"Drawing Number '{model.ItemNumber}' already exist.";
                ModelState.AddModelError("ItemNumber", "The Item Number already exist.");
            }

            if (!ModelState.IsValid)
            {
                model.Suppliers = await db.GetSuppliersAsync();
                model.Manufacturers = await db.GetManufactursAsync();
                return View(model);
            }

            await db.EditPurchasedPartAsync(model);
            TempData["success"] = $"Purchased Part '{model.Name}' is edited successfully";
            return RedirectToAction(nameof(AllPurchasedPart));
        }


        [HttpGet]
        public async Task<IActionResult> AddPurchasedPartToAssembly(int id, int quantity)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            try
            {
                await dbAssembly.GetWorkingAssemblyAsync(userId);
            }
            catch (Exception)
            {

                TempData["error"] = "You have no set Working Assembly yet";
                return RedirectToAction(nameof(AllPurchasedPart));
            }

            var assembly = await dbAssembly.GetWorkingAssemblyAsync(userId);

            if (assembly == null)
            {
                TempData["error"] = $"You have no Working Assembly yet";
                return RedirectToAction(nameof(AllPurchasedPart));
            }

            var assemblyParts = await dbAssembly.GetPurchasedPartListFromAssemblyAsync(assembly.Id);

            var currentPartId = id;

            if (!assemblyParts.Any(p => p.Id == currentPartId))
            {
                var model = new AddPurchasedPartToAssemblyViewModel
                {
                    Quantity = quantity
                };
                return View(model);
            }

            else
            {
                ModelState.AddModelError("", "Production Part is already added");
                var currentPartName = db.GetPurchasedPartForEditAsync(currentPartId).Result.Name;
                TempData["alreadyDone"] = $"Production Part '{currentPartName}' is already added";
                return RedirectToAction(nameof(AllPurchasedPart));
            }

        }


        [HttpPost]
        public async Task<IActionResult> AddPurchasedPartToAssembly(int id, AddPurchasedPartToAssemblyViewModel model)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            var assembly = await dbAssembly.GetWorkingAssemblyAsync(userId);

            var assemblyId = assembly.Id;

            var quantity = model.Quantity;

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await db.AddPurchasedPartToAssemblyAsync(id, assemblyId, quantity);
            }
            catch (Exception)
            {
                throw;
            }
            var workingAssemblyName = dbAssembly.GetAssemblyById(assemblyId).Result.Name;
            var currrentPartName = db.GetPurchasedPartForEditAsync(id).Result.Name;
            TempData["success"] = $"Purchsed Part '{currrentPartName}' is added  to '{workingAssemblyName}' successfully";
            return RedirectToAction(nameof(AllPurchasedPart));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var model = await db.GetPurchasedPartForEditAsync(id);

            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(AllPurchasedPart));
            }

            return View(model);
        }




        public async Task<IActionResult> Delete(int id)
        {
            var model = await db.GetPurchasedPartForEditAsync(id);
            if (model == null)
            {
                TempData["error"] = $"Part with id='{id}' can not found";
                return NotFound();
            }

            var partName = model.Name;

            var assemblyModel = await dbAssembly.GetWhereUsedPurchasedPartAssembliesAsync(id);

            if (assemblyModel.Any())
            {
                TempData["error"] = $"'{partName}' can not be Deleted because it is currently used in somes Assemblies";
                return RedirectToAction(nameof(AllPurchasedPart));
            }
            else
            {
                await db.DeleteAsync(id);
                TempData["success"] = $"You have deleted '{partName}' successfully";
                return RedirectToAction(nameof(AllPurchasedPart));
            }
        }

        public async Task<IActionResult> RemovePurchasedPartFromAssembly(int id)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            var assembly = await dbAssembly.GetWorkingAssemblyAsync(userId);

            var assemblyId = assembly.Id;

            await db.RemovePurchasedPartFromAssemblyAsync(id, assemblyId);

            var currentPartName = db.GetPurchasedPartForEditAsync(id).Result.Name;
            var workingAssemblyName = dbAssembly.GetAssemblyById(assemblyId).Result.Name;

            TempData["success"] = $"You remove '{currentPartName}' from '{workingAssemblyName}' successfully";
            return Redirect($"/Assembly/WorkingAssemblyPurchasedPartList/{assemblyId}");
        }


        [HttpGet]
        public async Task<IActionResult> EditQuantity(int id)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            var assembly = await dbAssembly.GetWorkingAssemblyAsync(userId);

            var assemblyId = assembly.Id;

            var model = await db.GetForEditQuantityAsync(id, assemblyId);

            model.currentPurchasedPartId = id;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditQuantity(AddPurchasedPartToAssemblyViewModel model)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            var assembly = await dbAssembly.GetWorkingAssemblyAsync(userId);

            var assemblyId = assembly.Id;

            var quantity = model.Quantity;

            var id = model.currentPurchasedPartId;

            var currentPart = await db.GetPurchasedPartForEditAsync(id);

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await db.EditQuantityOfPurchasedPartInAssemblyAsync(id, assemblyId, quantity);
            }
            catch (Exception)
            {
                throw;
            }

            TempData["success"] = $"You have changed Quantity of '{currentPart.Name}' successfully";
            return Redirect($"/Assembly/WorkingAssemblyPurchasedPartList/{assemblyId}");
        }




    }
}
