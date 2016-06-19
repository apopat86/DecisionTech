using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using NUnit.Framework;
using DecisionTech;
using DecisionTech.Controllers;
using DecisionTech.Data.Contracts;
using Moq;

namespace DecisionTech.Tests.Controllers
{
    [TestFixture]
    public class HomeControllerTest
    {
        [Test]
        public void ConstructingWithoutRepositoryThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new HomeController(null));
        }

        [Test]
        public void ConstructingWithValidParametersDoesNotThrowException()
        {
            Assert.DoesNotThrow(() => CreateController());
        }

        [Test]
        public void IndexRendersView()
        {
            var controller = CreateController();

            var result = controller.Index();

            Assert.That(result, Is.InstanceOf<ViewResult>());
        }

        [Test]
        public void GetDealDelegatesToRepository()
        {
            var controller = CreateController();

            controller.GetDeal();

            mockRepository.Verify(reader => reader.GetDeal());
        }

        [Test]
        public void GetDealReturnsJsonResult()
        {
            var controller = CreateController();
            var bundle = new JsonResult();
            mockRepository.Setup(repository => repository.GetDeal()).Returns(bundle);

            var viewResult = controller.GetDeal();

            Assert.That(viewResult, Is.InstanceOf<JsonResult>());

        }

        [Test]
        public void GetDealReturnsJsonResultReturnsBadRequestStatusCodeOnError()
        {
            var controller = CreateController();

            mockRepository.Setup(repository => repository.GetDeal()).Throws(new Exception());
            var result = controller.GetDeal();

            Assert.That(result, Is.InstanceOf<HttpStatusCodeResult>());

            var httpStatusCodeResult = result as HttpStatusCodeResult;
            Assert.That(httpStatusCodeResult.StatusCode, Is.EqualTo(400));
        }

        [SetUp]
        public void SetUp()
        {
            mockRepository = new Mock<IDealRepository>();

        }

        private HomeController CreateController()
        {
            return new HomeController(mockRepository.Object);
        }

        private Mock<IDealRepository> mockRepository;
    }
}

