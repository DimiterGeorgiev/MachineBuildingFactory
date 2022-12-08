using MachineBuildingFactory.Contracts;
using MachineBuildingFactory.Controllers;
using MachineBuildingFactory.Models;
using Moq;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace MachineBuildingFactory.Tests
{
    public class UnitTestProductionPartController
    {
        private readonly Mock<IProductionPartService> productionPartService;
        private readonly Mock<IAssemblyService> assemblyServices;

        public UnitTestProductionPartController()
        {
            productionPartService = new Mock<IProductionPartService>();
            assemblyServices = new Mock<IAssemblyService>();
        }

        [Fact]
        public void GetProductionPartList_ProductionPartList()
        {
            //Arange
            var productionPartViewModelsList = GetProductionPartsData();
            productionPartService.Setup(x => x.GetAllProductionPartsAsync())
                .Returns(productionPartViewModelsList);
            var productionPartController = new ProductionPartController(productionPartService.Object, assemblyServices.Object);

            //act
            var productionPartResult = (IEnumerable<ProductionPartViewModel>)productionPartController.AllProductionPart();

            //assert
            var ala = GetProductionPartsData().Result.ToList().Count();
            var bala = productionPartResult.ToList().Count();

            Assert.NotNull(productionPartResult);
            Assert.Equal(GetProductionPartsData().Result.ToList().Count(), productionPartResult.ToList().Count());
            Assert.Equal(GetProductionPartsData().ToString(), productionPartResult.ToList().ToString());
            Assert.True(productionPartViewModelsList.Equals(productionPartResult));
        }



        private Task<IEnumerable<ProductionPartViewModel>> GetProductionPartsData()
        {
            List<ProductionPartViewModel> productsData = new List<ProductionPartViewModel>
            {
                new ProductionPartViewModel
                {
                    Id = 5,
                    Name = "Consol",
                    Description = "This is just a probe part.",
                    AuthorSignature = "PP",
                    DrawingNumber = "CL-025-001",
                },
                new ProductionPartViewModel
                {
                    Id = 6,
                    Name = "Shaft",
                    Description = "Shaft for all target.",
                    AuthorSignature = "DD",
                    DrawingNumber = "CL-025-002",
                },
                new ProductionPartViewModel
                {
                     Id = 7,
                     Name = "Base plate",
                     Description = "For all type of construction",
                     AuthorSignature = "TT",
                     DrawingNumber = "BP-080-008",
                },
            };
            return (Task<IEnumerable<ProductionPartViewModel>>)(IEnumerable)productsData;
        }


    }
}
