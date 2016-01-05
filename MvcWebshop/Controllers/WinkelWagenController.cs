using MvcWebshop.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcWebshop.Controllers
{
    public class WinkelWagenController : Controller
    {
        private WebshopDBContext db = new WebshopDBContext();

        // GET: /WinkelWagen
        public WinkelWagen Index()
        {
            var winkelWagen = new WinkelWagen();
            winkelWagen.Producten = GetProductenInWinkelwagen();

            return winkelWagen;
        }

        #region WinkelWagen
        // GET: WinkelWagen
        public List<Product> GetProductenInWinkelwagen()
        {
            var list = new List<Product>();
            try
            {
                var cart = (List<Product>)System.Web.HttpContext.Current.Session["cart"];

                foreach (var id in cart)
                {
                    var product = db.Producten.Find(id);
                    list.Add(product);
                }
            }
            catch (NullReferenceException)
            {
            }

            return list;
        }

        [HttpPost]
        public ActionResult ProductToevoegen(int ProductId, int hoeveelheid)
        {
            try
            {
                WinkelWagen ww = GetWinkelWagenFromSession();
                var product = db.Producten.Find(ProductId);
                for (int i = 0; i < hoeveelheid; i++)
                {
                    ww.Producten.Add(product);
                }
                Session["cart"] = ww;
                //}

                return WinkelWagenHtml();
            }
            catch (Exception)
            {
                return HttpNotFound();
            }
        }

        [HttpPost]
        public ActionResult ProductVerwijderen(int ProductId)
        {
            try
            {
                WinkelWagen ww = GetWinkelWagenFromSession();

                if (ww == null)
                    return RedirectToAction("Index", "Home");

                for (int i = 0; i < ww.Producten.Count; i++)
                {
                    if (ww.Producten[i].id == ProductId)
                    {
                        ww.Producten.RemoveAt(i);
                        break;
                    }
                }

                Session["cart"] = ww;

                return WinkelWagenHtml();
            }
            catch (Exception)
            {
                return HttpNotFound();
            }
        }


        public WinkelWagen GetWinkelWagenFromSession()
        {
            try
            {
                var session = (WinkelWagen)System.Web.HttpContext.Current.Session["cart"];
                return session != null ? (session) : new WinkelWagen();
            }
            catch (NullReferenceException)
            {
                return new WinkelWagen();
            }
        }
        public ActionResult WinkelWagenHtml()
        {
            var winkelwagen = (WinkelWagen)Session["cart"];

            return PartialView("_WinkelWagenPartial", winkelwagen);
        }
        #endregion

        #region afrekenen

        // GET: /WinkelWagen/Afrekenen
        public ActionResult Afrekenen()
        {
            System.Diagnostics.Debug.WriteLine("In Afrekenen");
            WinkelWagen ww = GetWinkelWagenFromSession();
            if (ww == null)
                return RedirectToAction("Index", "Home");

            if (ww.Producten.Count == 0)
                return RedirectToAction("Index", "Home");

            return View();
        }

        // GET: /Winkelwagen/Bevestig/
        [HttpPost]
        public ActionResult Bevestig(Klant klant)
        {
            System.Diagnostics.Debug.WriteLine("In Bevestig");
            try
            {
                if (!ModelState.IsValid)
                {
                    //var errors = ModelState.Values.SelectMany(v => v.Errors);
                    //foreach (var item in errors)
                    //{
                    //    System.Diagnostics.Debug.WriteLine("Error: " + item.ErrorMessage);
                    //}
                    //System.Diagnostics.Debug.WriteLine("Modelstate is not valid");
                    return RedirectToAction("Afrekenen", "WinkelWagen");
                }

                WinkelWagen ww = GetWinkelWagenFromSession();

                if (ww == null)
                    return RedirectToAction("Index", "Home");

                if (ww.Producten.Count == 0)
                    return RedirectToAction("Index", "Home");

                return View(klant);
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // POST: /Winkelwagen/Success/
        [HttpPost]
        public ActionResult Succes(Klant klant)
        {
            System.Diagnostics.Debug.WriteLine("In Succes");
            try
            {
                WinkelWagen ww = GetWinkelWagenFromSession();
                if (ww == null)
                    return RedirectToAction("Index", "Home");

                if (ww.Producten.Count == 0)
                    return RedirectToAction("Index", "Home");

                if (!ModelState.IsValid)
                {
                    System.Diagnostics.Debug.WriteLine("Modelstate is not valid");
                    return View(false);
                }

                System.Threading.Thread thread = new System.Threading.Thread(() => AddWithSoap(ww, klant));
                thread.Start();

                Session["cart"] = new WinkelWagen();

                return View(true);
            }
            catch (Exception)
            {
                return View(false);
            }
        }

        private void AddWithSoap(WinkelWagen winkelWagen, Klant klant)
        {
            SOAPService.SOAPService SoapService = new SOAPService.SOAPService();

            db.Klanten.Add(klant);

            Order order = new Order
            {
                klant = klant
            };

            var checklist = new List<int>();

            foreach (var item in winkelWagen.Producten)
            {
                if (!checklist.Contains(item.id))
                {
                    var aantal = 0;
                    foreach (var product in winkelWagen.Producten)
                    {
                        if (product.id == item.id)
                            aantal++;
                    }

                    System.Diagnostics.Debug.WriteLine("aantal: " + aantal);

                    db.Orderregels.Add(
                        new Orderregel
                        {
                            aantal = aantal,
                            product = db.Producten.Find(item.id),
                            order = order
                        }
                    );
                    checklist.Add(item.id);
                }
            }
            // GetAcceptGiro heeft de 30 seconden timer/vertraging
            order.uniekGetal = SoapService.GetAcceptGiro(klant.voornaam + " " + klant.achternaam, klant.adres, winkelWagen.Totaal());

            db.Orders.Add(order);
            db.SaveChanges();
        }

        #endregion

    }
}