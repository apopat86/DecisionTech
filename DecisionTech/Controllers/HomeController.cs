using DecisionTech.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Web.Mvc;

namespace DecisionTech.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDealRepository repository;

        public HomeController(IDealRepository repository)
        {
            if (repository == null) throw new ArgumentNullException("IDealRepository is required");

            this.repository = repository;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetDeal()
        {
            try
            {
                return repository.GetDeal();
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, ex.Message);
            }
            
        }
    }
}