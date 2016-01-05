using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcWebshop.Models
{
    public class WinkelWagen
    {
        public List<Product> Producten { get; set; }

        public WinkelWagen()
        {
            Producten = new List<Product>();
        }

        public double Totaal()
        {
            var totaal = 0.00;
            foreach (Product p in Producten)
            {
                if (p.aanbiedingen.Count > 0)
                {
                    Aanbieding d = p.aanbiedingen.Last();
                    totaal += d.aanbiedingsprijs;
                }
                else
                {
                    totaal += p.prijs;
                }
            }
            return totaal;
        }
    }
}
