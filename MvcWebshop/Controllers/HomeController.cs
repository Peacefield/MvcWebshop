using MvcWebshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcWebshop.Controllers
{
    public class HomeController : Controller
    {
        private WebshopDBContext db = new WebshopDBContext();
        public ActionResult Index()
        {
            return View(db.Aanbiedingen.ToList());
        }
    }
}