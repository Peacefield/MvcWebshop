using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcWebshop.Models
{
    public class Order
    {
        public int id { get; set; }
        public virtual Klant klant { get; set; }
        public virtual ICollection<Orderregel> orderregels { get; set; }
        public int uniekGetal { get; set; }
    }
}