using MachineBuildingFactory.Contracts;
using MachineBuildingFactory.Models;
using Microsoft.AspNetCore.Mvc;

namespace MachineBuildingFactory.Controllers
{
    public class PurchasedPartController : Controller
    {
        private readonly IPurchasedPartService db;

        public PurchasedPartController(IPurchasedPartService _db)
        {
            db = _db;
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
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await db.CreatePurchasedPartAsync(model);
                return RedirectToAction(nameof(AllPurchasedPart));
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Something went wrong");
                return View(model);
            }
        }


    }
}
