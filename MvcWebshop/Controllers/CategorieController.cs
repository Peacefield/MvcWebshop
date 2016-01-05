using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MvcWebshop.Models;

namespace MvcWebshop.Controllers
{
    public class CategorieController : Controller
    {
        private WebshopDBContext db = new WebshopDBContext();

        // GET: Categorie
        public ActionResult Index()
        {
            return View(db.Categorieen.ToList());
        }

        // GET: Categorie/Details/5
        public ActionResult Id(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categorie categorie = db.Categorieen.Find(id);
            if (categorie == null)
            {
                return HttpNotFound();
            }
            return View(categorie);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
