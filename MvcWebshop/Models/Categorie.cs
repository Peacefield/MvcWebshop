using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcWebshop.Models
{
    public class Categorie
    {
        public int id { get; set; }
        public string plaatje { get; set; }
        public string naam { get; set; }
        public string omschrijving { get; set; }
        public virtual ICollection<Product> products { get; set; }
    }
    public class WebshopDBContext : DbContext
    {
        public DbSet<Categorie> Categorieen { get; set; }
        public DbSet<Product> Producten { get; set; }
        public DbSet<Aanbieding> Aanbiedingen { get; set; }
        public DbSet<Klant> Klanten { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Orderregel> Orderregels { get; set; }

    }
}