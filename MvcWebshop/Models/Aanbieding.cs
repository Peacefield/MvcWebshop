using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcWebshop.Models
{
    public class Aanbieding
    {
        public int id { get; set; }
        public double aanbiedingsprijs { get; set; }
        public DateTime datumVan { get; set; }
        public DateTime datumTot { get; set; }
        public string reclametekst { get; set; }
        public virtual Product product { get; set; }
    }
}