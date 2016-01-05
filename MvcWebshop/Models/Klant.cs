using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcWebshop.Models
{
    public class Klant
    {
        public int id { get; set; }

        [Required]
        [MinLength(2)]
        public string voornaam { get; set; }

        [Required]
        [MinLength(2)]
        public string achternaam { get; set; }
        
        [Required]
        [MinLength(3)]
        public string adres { get; set; }

        [Required]
        [MinLength(6)]
        [MaxLength(6)]
        public string postcode { get; set; }

        [Required]
        [MinLength(2)]
        public string stad { get; set; }

        public ICollection<Order> orders { get; set; }

    }
}