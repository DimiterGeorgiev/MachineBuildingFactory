using MachineBuildingFactory.Contracts;
using MachineBuildingFactory.Models;
using Microsoft.AspNetCore.Mvc;

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

            //IEnumerable<ProductionPart> objProductionPartList = _db.ProductionParts
            //    .Include(p => p.Material);
            //return View(objProductionPartList);
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

        public async Task<IActionResult> AddProductionPartToAssembly(int productionPartId, int assemblyId, int quantity)
        {
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

    }
}
