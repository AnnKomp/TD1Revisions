using Microsoft.VisualStudio.TestTools.UnitTesting;
using TD1Revisions.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TD1Revisions.Models;
using TD1Revisions.Models.EntityFramework;
using TD1Revisions.Models.Repository;
using Microsoft.EntityFrameworkCore;
using Moq;
using Microsoft.AspNetCore.Mvc;

namespace TD1Revisions.Controllers.Tests
{
    [TestClass()]
    public class MarquesControllerTests
    {
        private ProduitsDBContext context;

        private IDataRepository<Marque> dataRepository;


        public MarquesControllerTests()
        {
            var builder = new DbContextOptionsBuilder<ProduitsDBContext>().UseNpgsql("Server=localhost;port=5432;Database=ProdDB;uid=postgres;password=postgres;");
            context = new ProduitsDBContext(builder.Options);
            dataRepository = new ProduitsDBContext(context);
        }


        [TestMethod()]
        public void GetMarqueById_ExistingIdPassed_ReturnsRightItem_AvecMoq()
        {
            // Arrange
            Marque marque = new Marque
            {
                IdMarque = 1,
                NomMarque = "prada"
            };
            var mockRepository = new Mock<IDataRepository<Marque>>();
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(marque);

            var marqueController = new MarquesController(mockRepository.Object);

            // Act
            var actionResult = marqueController.GetMarqueById(1).Result;

            // Assert
            Assert.IsNotNull(actionResult);
            Assert.IsNotNull(actionResult.Value);
            Assert.AreEqual(marque, actionResult.Value as Marque);
        }

        [TestMethod]
        public void GetMarqueById_UnknownIdPassed_ReturnsNotFoundResult_AvecMoq()
        {
            var mockRepository = new Mock<IDataRepository<Marque>>();
            var userController = new MarquesController(mockRepository.Object);

            // Act
            var actionResult = userController.GetMarqueById(0).Result;

            // Assert
            Assert.IsInstanceOfType(actionResult.Result, typeof(NotFoundResult));
        }

        [TestMethod]
        public void PostMarque_ModelValidated_CreationOK_AvecMoq()
        {
            // Arrange
            var mockRepository = new Mock<IDataRepository<Marque>>();
            var marqueController = new MarquesController(mockRepository.Object);

            Marque marque = new Marque
            {
                NomMarque = "Adidas",
            };

            // Act
            var actionResult = marqueController.PostMarque(marque).Result;

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(ActionResult<Marque>), "Pas un ActionResult<Utilisateur>");
            Assert.IsInstanceOfType(actionResult.Result, typeof(CreatedAtActionResult), "Pas un CreatedAtActionResult");
            var result = actionResult.Result as CreatedAtActionResult;
            Assert.IsInstanceOfType(result.Value, typeof(Marque), "Pas un Utilisateur");
            marque.IdMarque = ((Marque)result.Value).IdMarque;
            Assert.AreEqual(marque, (Marque)result.Value, "Utilisateurs pas identiques");
        }

        [TestMethod]
        public void DeleteMarqueTest_AvecMoq()
        {
            // Arrange
            Marque marque = new Marque
            {
                NomMarque = "prada"
            };

            var mockRepository = new Mock<IDataRepository<Marque>>();
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(marque);
            var marqueController = new MarquesController(mockRepository.Object);

            // Act
            var actionResult = marqueController.DeleteMarque(1).Result;

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult), "Pas un NoContentResult"); // Test du type de retour
        }

        [TestMethod]
        public void PutMarque_ModelValidated_UpdateOK_AvecMoq()
        {
            // Arrange
            Marque marqueAMaJ = new Marque
            {
                NomMarque = "prada"
            };
            Marque marqueUpdated = new Marque
            {
                NomMarque = "Prada"
            };
            var mockRepository = new Mock<IDataRepository<Marque>>();
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(marqueAMaJ);
            var userController = new MarquesController(mockRepository.Object);

            // Act
            var actionResult = userController.PutMarque(marqueUpdated.IdMarque, marqueUpdated).Result;

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult), "Pas un NoContentResult"); // Test du type de retour
        }
    }
}