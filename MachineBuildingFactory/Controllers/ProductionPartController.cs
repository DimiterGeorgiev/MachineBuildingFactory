using MachineBuildingFactory.Contracts;
using MachineBuildingFactory.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using System.Security.Claims;

namespace MachineBuildingFactory.Controllers
{
    [Authorize]
    public class ProductionPartController : Controller
    {
        private readonly IProductionPartService db;

        private readonly IAssemblyService dbAssembly;

        public ProductionPartController(IProductionPartService _db, IAssemblyService _dbAssembly)
        {
            db = _db;
            dbAssembly = _dbAssembly;
        }

        [HttpGet]
        public async Task<IActionResult> AllProductionPart()
        {
            var model = await db.GetAllProductionPartsAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> CreateNewProductionPart()
        {
            var model = new CreateProductionPartViewModel
            {
                Materials = await db.GetMaterialsAsync(),
                TypeOfProductionParts = await db.GetTypeOfProductionPartAsync()
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewProductionPart(CreateProductionPartViewModel model)
        {
            var listOfAllParts = await db.GetAllProductionPartsAsync();
            var listOfAssemblies = await dbAssembly.GetAllAssembliesAsync();

            if (listOfAllParts.Any(p => p.DrawingNumber == model.DrawingNumber) ||
                listOfAssemblies.Any(a => a.DrawingNumber == model.DrawingNumber))
            {
                TempData["error"] = $"Drawing Number '{model.DrawingNumber}' already exist.";
                ModelState.AddModelError("DrawingNumber", "The Drawing Number already exist.");
            }

            if (!ModelState.IsValid)
            {
                model.TypeOfProductionParts = await db.GetTypeOfProductionPartAsync();
                model.Materials = await db.GetMaterialsAsync();
                return View(model);
            }

            try
            {
                await db.CreateProductionPartAsync(model);
                TempData["success"] = $"You have created '{model.Name}' successfuly";
                return RedirectToAction(nameof(AllProductionPart)); // След създаване на нов ProductionPart отиваме в AllProductionPart
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Something went wrong");
                TempData["errror"] = "Something went wrong";
                return View(model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> AddProductionPartToAssembly(int id, int quantity)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            try
            {
                await dbAssembly.GetWorkingAssemblyAsync(userId);
            }
            catch (Exception)
            {

                TempData["error"] = "You have no set Working Assembly yet";
                return RedirectToAction(nameof(AllProductionPart));
            }

            var assembly = await dbAssembly.GetWorkingAssemblyAsync(userId);


            if (assembly == null)
            {
                TempData["error"] = $"You have no Working Assembly yet";
                return RedirectToAction(nameof(AllProductionPart));
            }

            var assemblyParts = await dbAssembly.GetProductionPartListFromAssemblyAsync(assembly.Id);

            var currentPartId = id;

            if (!assemblyParts.Any(p => p.Id == currentPartId))
            {
                var model = new AddProducitonPartToAssemblyViewModel
                {
                    Quantity = quantity
                };
                return View(model);
            }

            else
            {
                ModelState.AddModelError("", "Production Part is already added");
                var currentPartName = db.GetProductionPartForEditAsync(currentPartId).Result.Name;
                TempData["alreadyDone"] = $"Production Part '{currentPartName}' is already added";
                return RedirectToAction(nameof(AllProductionPart));
            }

        }

        [HttpPost]
        public async Task<IActionResult> AddProductionPartToAssembly(int id, AddProducitonPartToAssemblyViewModel model)
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
                await db.AddProductionPartToAssemblyAsync(id, assemblyId, quantity);
            }
            catch (Exception)
            {
                throw;
            }
            var workingAssemblyName = dbAssembly.GetAssemblyById(assemblyId).Result.Name;
            var currrentPartName = db.GetProductionPartForEditAsync(id).Result.Name;
            TempData["success"] = $"Production Part '{currrentPartName}' is added  to '{workingAssemblyName}' successfully";
            return RedirectToAction(nameof(AllProductionPart));
        }


        [HttpGet]
        public async Task<IActionResult> EditProductionPart(int id)
        {
            var model = await db.GetProductionPartForEditAsync(id);

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> EditProductionPart(EditProductionPartViewModel model)
        {
            var listOfAllParts = (await db.GetAllProductionPartsAsync()).ToList();
            var listOfAssemblies = (await dbAssembly.GetAllAssembliesAsync()).ToList();

            var currentPart = listOfAllParts.Find(p => p.Id == model.Id);

            if (currentPart != null)
            {
                listOfAllParts.Remove(currentPart);
            }

            if (listOfAllParts.Any(p => p.DrawingNumber == model.DrawingNumber) ||
                listOfAssemblies.Any(a => a.DrawingNumber == model.DrawingNumber))
            {
                TempData["error"] = $"Drawing Number '{model.DrawingNumber}' already exist.";
                ModelState.AddModelError("DrawingNumber", "The Drawing Number already exist.");
            }

            if (!ModelState.IsValid)
            {
                model.TypeOfProductionParts = await db.GetTypeOfProductionPartAsync();
                model.Materials = await db.GetMaterialsAsync();
                return View(model);
            }

            await db.EditProductionPartAsync(model);
            TempData["success"] = $"Production Part '{model.Name}' is edited successfully";
            return RedirectToAction(nameof(AllProductionPart));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var model = await db.GetProductionPartForEditAsync(id);

            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(AllProductionPart));
            }

            return View(model);
        }


        public async Task<IActionResult> Delete(int id)
        {
            var model = await db.GetProductionPartForEditAsync(id);
            if (model == null)
            {
                TempData["error"] = $"Part with id='{id}' can not found";
                return NotFound();
            }

            var partName = model.Name;

            var assemblyModel = await dbAssembly.GetWhereUsedAssembliesAsync(id);

            if (assemblyModel.Any())
            {
                TempData["error"] = $"'{partName}' can not be Deleted because it is currently used in somes Assemblies";
                return RedirectToAction(nameof(AllProductionPart));
            }
            else
            {
                await db.DeleteAsync(id);
                TempData["success"] = $"You have deleted '{partName}' successfully";
                return RedirectToAction(nameof(AllProductionPart));
            }
        }

        public async Task<IActionResult> RemoveProductionPartFromAssembly(int id)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            var assembly = await dbAssembly.GetWorkingAssemblyAsync(userId);

            var assemblyId = assembly.Id;

            await db.RemoveProductionPartFromAssemblyAsync(id, assemblyId);

            var currentPartName = db.GetProductionPartForEditAsync(id).Result.Name;
            var workingAssemblyName = dbAssembly.GetAssemblyById(assemblyId).Result.Name;

            TempData["success"] = $"You remove '{currentPartName}' from '{workingAssemblyName}' successfully";
            return Redirect($"/Assembly/WorkingAssemblyProductionPartList/{assemblyId}");
        }

        [HttpGet]
        public async Task<IActionResult> EditQuantity(int id)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            var assembly = await dbAssembly.GetWorkingAssemblyAsync(userId);

            var assemblyId = assembly.Id;

            var model = await db.GetForEditQuantityAsync(id, assemblyId);

            model.currentProductionPartId = id;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditQuantity(AddProducitonPartToAssemblyViewModel model)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            var assembly = await dbAssembly.GetWorkingAssemblyAsync(userId);

            var assemblyId = assembly.Id;

            var quantity = model.Quantity;

            var id = model.currentProductionPartId;

            var currentPart = await db.GetProductionPartForEditAsync(id);

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await db.EditQuantityOfProductionPartInAssemblyAsync(id, assemblyId, quantity);
            }
            catch (Exception)
            {
                throw;
            }

            TempData["success"] = $"You have changed Quantity of '{currentPart.Name}' successfully";
            return Redirect($"/Assembly/WorkingAssemblyProductionPartList/{assemblyId}");
        }


    }
}


