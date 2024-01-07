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
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Naam { get; set; }

        [MaxLength(100)]
        public string Telefoon { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }

        [MaxLength(100)]
        public string Adres { get; set; }
    }
}
