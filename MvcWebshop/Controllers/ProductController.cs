using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MvcWebshop.Models;
using System.Web.Services;

namespace MvcWebshop.Controllers
{
    public class ProductController : Controller
    {
        private WebshopDBContext db = new WebshopDBContext();

        // GET: Product
        public ActionResult Id(int? id)
        {
            //return View(db.Products.ToList());

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Producten.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
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
