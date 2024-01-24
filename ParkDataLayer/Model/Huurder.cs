using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkDataLayer.Model
{
    public class Huurder
    {
        public Huurder(string naam, string telefoon, string email, string adres)
        {
            Naam = naam;
            Telefoon = telefoon;
            Email = email;
            Adres = adres;
        }

        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Naam { get; set; }

        [MaxLength(100)]
        public string Telefoon { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }

        [MaxLength(100)]
        public string Adres { get; set; }
    }
}

