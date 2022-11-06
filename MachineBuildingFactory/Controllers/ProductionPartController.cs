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
                await db.CreateProductionPartsAsync(model);
                return RedirectToAction(nameof(AllProductionPart)); // След добавяне на нов ProductionPart отиваме в AllProductionPart
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Something went wrong");
                return View(model);
            }
        }
    }
}
