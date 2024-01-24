using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ParkDataLayer.Model
{
    public class Huis
    {
        public Huis()
        {
            Huurcontracten = new List<Huurcontract>();
        }

        public Huis(string straat, int nummer, bool actief, string parkId) : this()
        {
            Straat = straat;
            Nummer = nummer;
            Actief = actief;
            ParkId = parkId;
        }

        public int Id { get; set; }

        [MaxLength(250)]
        public string Straat { get; set; }

        [Required]
        public int Nummer { get; set; }

        [Required]
        public bool Actief { get; set; }

        // Foreign key to link to the Park
        public string ParkId { get; set; }

        // Navigation property to access the associated Park
        public Park Park { get; set; }

        // Collection to hold rental contracts for this house
        public ICollection<Huurcontract> Huurcontracten { get; set; }
    }
}
