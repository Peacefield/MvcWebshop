using MvcWebshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcWebshop.Controllers
{
    public class CatNavController : Controller
    {
        private WebshopDBContext db = new WebshopDBContext();

        public List<Categorie> Categorieen()
        {
            return db.Categorieen.ToList();
        }
    }
}