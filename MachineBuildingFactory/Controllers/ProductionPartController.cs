using MachineBuildingFactory.Contracts;
using MachineBuildingFactory.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MachineBuildingFactory.Controllers
{
    public class ProductionPartController : Controller
    {
        private readonly IProductionPartService db;

        public ProductionPartController(IProductionPartService _db)
        {
            db = _db;
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
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            try
            {
                await db.CreateProductionPartAsync(model);
                return RedirectToAction(nameof(AllProductionPart)); // След добавяне на нов ProductionPart отиваме в AllProductionPart
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Something went wrong");
                return View(model);
            }
        }


        //не работи
        public async Task<IActionResult> AddProductionPartToAssembly(int productionPartId, int quantity)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            var assemblyId = 0; // трябва да намеря WorkingAssembly на User

            try
            {
                await db.AddProductionPartToAssemblyAsync(productionPartId, assemblyId, quantity);
            }
            catch (Exception)
            {
                throw;
            }

            return RedirectToAction(nameof(AllProductionPart));
        }




        //public async Task<IActionResult> AssemblyProductionPartList(int assemblyId)
        //{
        //    var model = await db.GetProductionPartListFromAssemblyAsync(assemblyId);

        //    return View(nameof(AssemblyProductionPartList), model);
        //}



        [HttpGet]
        public async Task<IActionResult> EditProductionPart(int id)
        {
            var model = await db.GetProductionPartForEditAsync(id);

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> EditProductionPart(EditProductionPartViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await db.EditProductionPartAsync(model);

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
            var model = db.GetProductionPartForEditAsync(id);
            if (model == null)
            {
                return NotFound();
            }

            await db.DeleteAsync(id);
            return RedirectToAction(nameof(AllProductionPart));
        }

        //[HttpPost]
        //public async Task<IActionResult> Delete(EditProductionPartViewModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(model);
        //    }

        //    var id = model.Id;

        //    await db.DeleteAsync(id);
        //    return RedirectToAction(nameof(AllProductionPart));

        //}

    }
}
