using MachineBuildingFactory.Contracts;
using MachineBuildingFactory.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language.Extensions;
using System.Security.Claims;

namespace MachineBuildingFactory.Controllers
{
    [Authorize]
    public class AssemblyController : Controller
    {
        private readonly IAssemblyService db;

        private readonly IProductionPartService productionDb;

        public AssemblyController(IAssemblyService _db, IProductionPartService _productionDb)
        {
            db = _db;
            productionDb = _productionDb;
        }

        [HttpGet]
        public async Task<IActionResult> AllAssemblies()
        {
            var model = await db.GetAllAssembliesAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> WhereUsed(int id)
        {
            var model = await db.GetWhereUsedAssembliesAsync(id);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> WhereUsedPurchasedPart(int id)
        {
            var model = await db.GetWhereUsedPurchasedPartAssembliesAsync(id);

            return View(model);
        }


        [HttpGet]
        public IActionResult CreateNewAssembly()
        {
            var model = new CreateAssemblyViewModel();
            return View(model);
        }

        public async Task<IActionResult> CreateNewAssembly(CreateAssemblyViewModel model)
        {
            var listOfAllParts = await productionDb.GetAllProductionPartsAsync();
            var listOfAssemblies = await db.GetAllAssembliesAsync();

            if (listOfAllParts.Any(p => p.DrawingNumber == model.DrawingNumber) ||
                listOfAssemblies.Any(a => a.DrawingNumber == model.DrawingNumber))
            {
                TempData["error"] = $"Drawing Number '{model.DrawingNumber}' already exist.";
                ModelState.AddModelError("DrawingNumber", "The Drawing Number already exist.");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            try
            {
                await db.CreateAssemblyAsync(model);
                TempData["success"] = "You have create new Assembly";
                return RedirectToAction(nameof(AllAssemblies)); // След добавяне на нов Assembly отиваме в AllAssemblies
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Something went wrong");
                TempData["error"] = "Something went wrong";
                return View(model);
            }
        }


        public async Task<IActionResult> AssemblyProductionPartList(int id)
        {
            var model = await db.GetProductionPartListFromAssemblyAsync(id);

            return View(nameof(AssemblyProductionPartList), model);
        }

        public async Task<IActionResult> WorkingAssemblyProductionPartList(int id)
        {
            var model = await db.GetProductionPartListFromAssemblyAsync(id);

            return View(nameof(WorkingAssemblyProductionPartList), model);
        }

        public async Task<IActionResult> AssemblyPurchasedPartList(int id)
        {
            var model = await db.GetPurchasedPartListFromAssemblyAsync(id);

            return View(nameof(AssemblyPurchasedPartList), model);
        }

        public async Task<IActionResult> WorkingAssemblyPurchasedPartList(int id)
        {
            var model = await db.GetPurchasedPartListFromAssemblyAsync(id);

            return View(nameof(WorkingAssemblyPurchasedPartList), model);
        }


        public async Task<IActionResult> AddAssemblyToMineCollection(int id)
        {
            try
            {
                var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                await db.AddAssemblyToCollectionAsync(id, userId);
            }
            catch (Exception)
            {
                var currAssembly = db.GetAssemblyForEditAsync(id).Result.Name;
                TempData["alreadyDone"] = $"You have already '{currAssembly}' in your Assemblies";
                return RedirectToAction(nameof(AllAssemblies));
            }
            var assembly = db.GetAssemblyForEditAsync(id).Result.Name;
            TempData["success"] = $"You have added '{assembly}' to your Assemblies";
            return RedirectToAction(nameof(AllAssemblies));
        }

        public async Task<IActionResult> SetAssemblyAsWorking(int id)
        {
            try
            {
                var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                await db.SetAssemblyAsWorkingAsync(id, userId);
            }
            catch (Exception)
            {
                throw;
            }

            var assembly = db.GetAssemblyForEditAsync(id).Result.Name;

            TempData["success"] = $"You have set '{assembly}' as Working Assembly";
            return RedirectToAction(nameof(MineAssemblies));
        }

        public async Task<IActionResult> WorkingAssembly()
        {
            try
            {
                var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                var model = await db.GetWorkingAssemblyAsync(userId);

                var assemblmbyId = model.Id;

                var assembly = await db.GetAssemblyById(assemblmbyId);

                var allProductionParts = await db.GetProductionPartListFromAssemblyAsync(assemblmbyId);

                double fullLaserCutLength = 0;
                double fullPaintingSurface = 0;
                double fullOxidizeSurface = 0;
                double fullElectrogalvanizedSurface = 0;
                double fullUntreatedSurface = 0;

                foreach (var item in allProductionParts)
                {
                    var quantity = assembly.AssemblyProductionParts.Where(p => p.ProductionPartId == item.Id).First().Quantity;

                    fullLaserCutLength += Convert.ToDouble(item.LaserCutLength) * quantity;

                    if (item.SurfaceTreatment == "Paint")
                    {
                        fullPaintingSurface += Convert.ToDouble(item.SurfaceArea) * quantity;
                    }
                    if (item.SurfaceTreatment == "Electrogalvanized")
                    {
                        fullElectrogalvanizedSurface += Convert.ToDouble(item.SurfaceArea) * quantity;
                    }
                    if (item.SurfaceTreatment == "Oxidize")
                    {
                        fullOxidizeSurface += Convert.ToDouble(item.SurfaceArea) * quantity;
                    }
                    if (item.SurfaceTreatment == "UntreatedSurface")
                    {
                        fullUntreatedSurface += Convert.ToDouble(item.SurfaceArea) * quantity;
                    }
                }

                model.PaintSurface = Math.Round(fullPaintingSurface, 2).ToString();
                model.ElectrogalvanizedSurface = Math.Round(fullElectrogalvanizedSurface, 2).ToString();
                model.OxidizeSurface = Math.Round(fullOxidizeSurface, 2).ToString();
                model.UntreatedSurface = Math.Round(fullUntreatedSurface, 2).ToString();
                model.LaserCutLength = Math.Round(fullLaserCutLength, 2).ToString();


                return View(nameof(WorkingAssembly), model);
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "You have no set Working Assembly yet");
                TempData["error"] = "You have no set Working Assembly yet";
                return RedirectToAction(nameof(MineAssemblies));
            }
        }

        public async Task<IActionResult> RemoveAssemblyFromMineCollection(int id)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            await db.RemoveAssemblyFromCollectionAsync(id, userId);

            var assembly = db.GetAssemblyForEditAsync(id).Result.Name;
            TempData["success"] = $"You have remove '{assembly}' from your Assemblies";
            return RedirectToAction(nameof(MineAssemblies));
        }

        public async Task<IActionResult> MineAssemblies()
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            var model = await db.GetMineAssembliesAsync(userId);

            return View(nameof(MineAssemblies), model);
        }

        [HttpGet]
        public async Task<IActionResult> EditAssembly(int id)
        {
            var model = await db.GetAssemblyForEditAsync(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditAssembly(EditAssemblyViewModel model)
        {
            var listOfAllParts = (await productionDb.GetAllProductionPartsAsync()).ToList();
            var listOfAssemblies = (await db.GetAllAssembliesAsync()).ToList();

            var currentAssembly = listOfAssemblies.Find(a => a.Id == model.Id);

            if (currentAssembly != null)
            {
                listOfAssemblies.Remove(currentAssembly);
            }

            if (listOfAllParts.Any(p => p.DrawingNumber == model.DrawingNumber) ||
                listOfAssemblies.Any(a => a.DrawingNumber == model.DrawingNumber))
            {
                TempData["error"] = $"Drawing Number '{model.DrawingNumber}' already exist.";
                ModelState.AddModelError("DrawingNumber", "The Drawing Number already exist.");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await db.EditAssemblyAsync(model);
            var assembly = model.Name;
            TempData["success"] = $"You have edited '{assembly}' successfully";
            return RedirectToAction(nameof(AllAssemblies));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var model = await db.GetAssemblyForEditAsync(id);

            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(AllAssemblies));
            }

            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var model = await db.GetAssemblyForEditAsync(id);

            if (model == null)
            {
                return NotFound();
            }

            await db.DeleteAsync(id);
            var assembly = model.Name;
            TempData["success"] = $"You have deleted '{assembly}' successfully";
            return RedirectToAction(nameof(AllAssemblies));
        }
    }
}
