using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkDataLayer.Model
{
    public class Huurcontract
    {
        public Huurcontract(string id, DateTime startDatum, DateTime eindDatum, int aantalDagen, int huisId, int huurderId)
        {
            Id = id;
            StartDatum = startDatum;
            EindDatum = eindDatum;
            AantalDagen = aantalDagen;
            HuisId = huisId;
            HuurderId = huurderId;
        }

        [Key, MaxLength(25)]
        public string Id { get; set; }

        [Required]
        public DateTime StartDatum { get; set; }

        [Required]
        public DateTime EindDatum { get; set; }

        [Required]
        public int AantalDagen { get; set; }

        public int HuisId { get; set; }
        public Huis Huis { get; set; }

        public int HuurderId { get; set; }
        public Huurder Huurder { get; set; }
    }
}
