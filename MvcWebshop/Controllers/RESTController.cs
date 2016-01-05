using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using MvcWebshop.Models;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace MvcWebshop.Controllers
{
    public class RESTController : ApiController
    {
        private WebshopDBContext db = new WebshopDBContext();

        // GET: api/Producten/GetProducten
        [Route("api/Producten/GetProducten")]
        [ResponseType(typeof(Product))]
        public IEnumerable<Product> GetProducten()
        {
            return (from p in db.Set<Product>()
                    select new
                    {
                        plaatje = p.plaatje,
                        naam = p.naam,
                        omschrijving = p.omschrijving,
                        prijs = p.prijs
                    }).ToList()
                   .Select(x => new Product
                   {
                       plaatje = x.plaatje,
                       naam = x.naam,
                       omschrijving = x.omschrijving,
                       prijs = x.prijs
                   });
        }

        // GET: api/Producten/GetProduct/5
        [Route("api/Producten/GetProduct/{id:int}")]
        [ResponseType(typeof(Product))]
        public IEnumerable<Product> GetProduct(int id)
        {
            return (from p in db.Set<Product>()
                    where p.id == id
                    select new
                    {
                        plaatje = p.plaatje,
                        naam = p.naam,
                        omschrijving = p.omschrijving,
                        prijs = p.prijs,
                        categories = p.categories
                    }).ToList()
                   .Select(x => new Product
                   {
                       plaatje = x.plaatje,
                       naam = x.naam,
                       omschrijving = x.omschrijving,
                       prijs = x.prijs,
                       categories = x.categories
                   });
        }

        // PUT: api/Producten/UpdateProduct/5
        [Route("api/Producten/UpdateProduct/{id:int}")]
        [ResponseType(typeof(Product))]
        public IHttpActionResult UpdateProduct(int id, Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != product.id)
            {
                return BadRequest();
            }

            db.Entry(product).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }


        // POST: api/Producten/MaakProduct
        [Route("api/Producten/MaakProduct")]
        [ResponseType(typeof(Product))]
        public IHttpActionResult MaakProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Producten.Add(product);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = product.id }, product);
        }

        // DELETE: api/Producten/VerwijderProduct/5
        [Route("api/Producten/VerwijderProduct/{id:int}")]
        [ResponseType(typeof(Product))]
        public IHttpActionResult VerwijderProduct(int id)
        {
            Product product = db.Producten.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            db.Producten.Remove(product);
            db.SaveChanges();

            return Ok(product);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductExists(int id)
        {
            return db.Producten.Count(e => e.id == id) > 0;
        }

    }
}