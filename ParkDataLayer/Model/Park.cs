using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ParkDataLayer.Model
{
    public class Park
    {
        public Park()
        {
            Huizen = new List<Huis>();
        }

        public Park(string id, string naam, string locatie)
        {
            Id = id;
            Naam = naam;
            Locatie = locatie;
        }

        [Key, MaxLength(20)]
        public string Id { get; set; }

        [Required, MaxLength(250)]
        public string Naam { get; set; }

        [MaxLength(500)]
        public string Locatie { get; set; }

        // Navigation property for the houses in the park
        public ICollection<Huis> Huizen { get; set; }
    }
}
