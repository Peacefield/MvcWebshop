using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcWebshop.Models
{
    public class Orderregel
    {
        public int id { get; set; }
        public int aantal { get; set; }
        public virtual Product product { get; set; }
        public virtual Order order { get; set; }
    }
}