using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkBusinessLayer.Model;
using ParkDataLayer.Model;

namespace ParkDataLayer.Mappers
{
    public class HuurderMapper
    {
        public static Huurder MapToHuurder(HuurderEntity huurder)
        {
            if (huurder == null) return null;
            Huurder h = new Huurder(huurder.Naam, huurder.Contactgegevens.Tel, huurder.Contactgegevens.Email, huurder.Contactgegevens.Adres);
            h.Id = huurder.Id;
            return h;
        }

        public static HuurderEntity MapToHuurderEntity(Huurder huurder)
        {
            if (huurder == null) return null;
            ContactgegevensEntity contact = new ContactgegevensEntity(huurder.Telefoon, huurder.Email, huurder.Adres);
            HuurderEntity h = new HuurderEntity(huurder.Id, huurder.Naam, contact);
            return h;
        }



    }
}
