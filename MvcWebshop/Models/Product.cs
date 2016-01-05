using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcWebshop.Models
{
    public class Product
    {
        public int id { get; set; }
        public string plaatje { get; set; }
        public string naam { get; set; }
        public string omschrijving { get; set; }
        public double prijs { get; set; }
        public virtual ICollection<Categorie> categories { get; set; }
        public virtual ICollection<Aanbieding> aanbiedingen { get; set; }
        
        public double GetPrijs()
        {
            if (aanbiedingen.Count > 0)
            {
                Aanbieding a = aanbiedingen.First();
                return a.aanbiedingsprijs;
            }
            else
            {
                return this.prijs;
            }
        }
    }
}