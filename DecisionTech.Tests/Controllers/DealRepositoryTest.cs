using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using NUnit.Framework;
using DecisionTech;
using DecisionTech.Controllers;
using DecisionTech.Data.Contracts;
using DecisionTech.Data.Repositories;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DecisionTech.Tests.Controllers
{
    [TestFixture]
    public class DealRepositoryTest
    {
      
        [Test]
        public void GetDealReturnsJson()
        {
            var repository = new DealRepository();
            var result = repository.GetDeal();
            
            Assert.That(result, Is.InstanceOf<ContentResult>());
            Assert.AreEqual(result.ContentType, "application/json");
        }

        [Test]
        public void GetDealReturnsBundle()
        {
            var repository = new DealRepository();
            var result = repository.GetDeal();
            var obj =JObject.Parse((string)result.Content);
            int val;
            Assert.IsTrue(int.TryParse((string)obj["bundleId"],out val));

        }
    }
}

