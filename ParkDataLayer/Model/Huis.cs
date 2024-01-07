using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkDataLayer.Model
{
    public class Huis
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(250)]
        public string Straat { get; set; }

        [Required]
        public int Nummer { get; set; }

        [Required]
        public bool Actief { get; set; }
    }
}
